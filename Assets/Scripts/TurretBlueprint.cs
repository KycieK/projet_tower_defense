using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //Pour que ce soit affiché dans l'inspecteur
public class TurretBlueprint
{
    public GameObject prefab; 
    public int cost;



    private int turretLevel;

    public List<UpgradeList> upgradePrefabs = new List<UpgradeList>();
    public TurretBlueprint()
    {
        // Initialize upgradePrefabs with default values or leave it empty
        upgradePrefabs.Add(new UpgradeList(0, null));
        upgradePrefabs.Add(new UpgradeList(0, null));

        turretLevel = 0;
    }

    public void SetTurretLevel(int turretLevel)
    {
        this.turretLevel = turretLevel;
    }

    public int GetTurretLevel()
    {
        return turretLevel;
    }


}
