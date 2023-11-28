using System;
using System.Collections.Generic;
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
    private Node selectedNode;

    BuildManager buildManager;
    private int sellCost = 0;

    private int turretLevel = 0;


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
            selectedNode = this;
            buildManager.SelectNode(selectedNode);
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
        turret.transform.Translate(0f, -0.8f, 0f, Space.Self);
        turret.transform.Rotate(0f, 180f, 0f);
        this.turret = turret;

        turretBlueprint = blueprint;
        turretBlueprint.SetTurretLevel(turretLevel);
        //turret ici c'est une tourelle induite, si on a un buildeffect sur le script Turret il machera au lieu de passer par le buildmanager
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffectPrefab, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f / WorldTime.getActionSpeed());

        sellCost += (int)Mathf.Ceil(turretBlueprint.cost / 3);

        Debug.Log("Turret built");
    }

    public void UpgradeTurret()
    {
        int upgradeCost = turretBlueprint.upgradePrefabs[turretLevel].upgradeCost;
        sellCost += (int)Mathf.Ceil(upgradeCost / 4);


        if(PlayerStats.Money < upgradeCost) 
        {
            Debug.Log("trop cher pour upgrade");
            return;
        }


        PlayerStats.Money -= upgradeCost;

        //Detruit l'ancienne tourelle
        Destroy(this.turret);


        //Construit la version Upgraded
        GameObject turret = (GameObject)Instantiate(turretBlueprint.upgradePrefabs[turretLevel].upgradePrefab, GetBuildPosition(), Quaternion.identity);
        turret.transform.Translate(0f, -0.8f, 0f, Space.Self);
        turret.transform.Rotate(0f, 180f, 0f);
        this.turret = turret;
        turretLevel++;

        
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffectPrefab, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f / WorldTime.getActionSpeed());

        isUpgraded = true;

        Debug.Log("Turret upgraded");
    }



    public void SellTurret()
    {
        turretLevel = 0;
        Destroy(turret);

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffectPrefab, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f / WorldTime.getActionSpeed());

        PlayerStats.Money += sellCost;
        sellCost = 0;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    public int GetSellCost()
    {
        return sellCost;
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

    public int GetTurretLevel()
    {
        return turretLevel;
    }
}
