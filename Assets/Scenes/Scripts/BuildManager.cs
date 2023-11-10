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

    private GameObject turretToBuild;

    public GameObject GetTurretToBuild ()
    {
        return turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }
}
