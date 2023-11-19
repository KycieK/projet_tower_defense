using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    
    GameObject OverLayCanvas;
    public TurretBlueprint standardTurret; 
    public TurretBlueprint missileLauncher; 
    public TurretBlueprint laserBeamer;
    

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        Debug.Log("Tourelle standard choisie");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileLauncher()
    {
        Debug.Log("Tourelle lance missile choisie");
        buildManager.SelectTurretToBuild(missileLauncher);
    }

    public void SelectLaserBeamerTurret()
    {
        Debug.Log("Tourelle laser choisie");
        buildManager.SelectTurretToBuild(laserBeamer);
    }
}
