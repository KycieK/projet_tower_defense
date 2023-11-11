using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject turret;

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
        if(!buildManager.CanBuild) return;

        if(turret != null)
        {
            Debug.Log("Construit pas ici coco -- TODO : display sur ecran");
            return; 
        }

        buildManager.BuildTurretOn (this);
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
