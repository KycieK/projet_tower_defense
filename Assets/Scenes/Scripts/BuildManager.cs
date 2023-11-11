using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance; 

    void Awake ()
    {
        if(instance != null)
        {
            Debug.Log("Un seul BuildManager seulement !");
        }
        instance = this; 
    }

    public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab;

    public GameObject buildEffectPrefab;

    private TurretBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }


    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    public void BuildTurretOn(Node node)
    {
        if(PlayerStats.Money < turretToBuild.cost) 
        {
            Debug.Log("Trop cher -- Display sur écran à faire");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        GameObject effect = (GameObject)Instantiate(buildEffectPrefab, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Turret built: \nmoney left " + PlayerStats.Money);
    }
}
