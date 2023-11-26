using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] 
public class UpgradeList
{

    public int upgradeCost;
    public GameObject upgradePrefab;

    public UpgradeList(int upgradeCost, GameObject upgradePrefab)
    {
        this.upgradeCost = upgradeCost;
        this.upgradePrefab = upgradePrefab;
    }

}
