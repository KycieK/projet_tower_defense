using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //Pour que ce soit affiché dans l'inspecteur
public class TurretBlueprint
{
    public GameObject prefab; 
    public int cost;

    public GameObject upgradedPrefab;
    public int upgradeCost;
}
