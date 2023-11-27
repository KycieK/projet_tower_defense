using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRegister : MonoBehaviour
{
    private List<TurretNodePair> turretNodePairs = new List<TurretNodePair>();

    public void AddTurretNodePair(Node node, TurretBlueprint turretBlueprint)
    {
        TurretNodePair pair = new TurretNodePair(node, turretBlueprint);
        turretNodePairs.Add(pair);
    }
}
