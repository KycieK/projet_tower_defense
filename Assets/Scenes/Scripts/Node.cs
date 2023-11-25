using System.ComponentModel.Design;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [HideInInspector]
    public GameObject turret;

    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;
    private Color startColor; 

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color; 

        buildManager = BuildManager.instance;
    }

    void OnMouseDown()
    {

        if(turret != null)
        {
            buildManager.SelectNode(this);
            return; 
        }

        if(!buildManager.CanBuild) return;

        BuildTurret(buildManager.GetTurretToBuild());
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if(PlayerStats.Money < blueprint.cost) 
        {
            Debug.Log("Trop cher -- Display sur écran à faire");
            return;
        }

        PlayerStats.Money -= blueprint.cost;

        GameObject turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        this.turret = turret;

        turretBlueprint = blueprint;
        //Ici on peut remplacer le buildManager.buildEffectPrefab en gerant le build effect dans turret pour choisir un effet different pour chaque tourelle
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffectPrefab, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f / WorldTime.getActionSpeed());

        Debug.Log("Turret built");
    }

    public void UpgradeTurret()
    {
        if(PlayerStats.Money < turretBlueprint.upgradeCost) 
        {
            Debug.Log("trop cher pour upgrade");
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost;

        //Detruit l'ancienne tourelle
        Destroy(this.turret);


        //Construit la version Upgraded
        GameObject turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        this.turret = turret;


        
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffectPrefab, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f / WorldTime.getActionSpeed());

        isUpgraded = true;

        Debug.Log("Turret upgraded");
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseEnter()
    {
        if(EventSystem.current.IsPointerOverGameObject()) return;
        if(!buildManager.CanBuild) return;

        if(buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        } else 
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    void OnMouseExit() 
    {
        rend.material.color = startColor; 
    }
}
