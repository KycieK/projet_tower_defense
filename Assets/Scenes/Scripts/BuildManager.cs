using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance; 
    public NodeUI nodeUI;
    void Awake ()
    {
        if(instance != null)
        {
            Debug.Log("Un seul BuildManager seulement !");
        }
        instance = this; 
    }


    public GameObject buildEffectPrefab;

    private TurretBlueprint turretToBuild;
    private Node selectedNode;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }


    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        selectedNode = null;

        nodeUI.Hide();
    }


    public void SelectNode(Node node)
    {
        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
    

}
