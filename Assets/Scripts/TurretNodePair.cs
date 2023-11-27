using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretNodePair
{
    public Node node; 
    public TurretBlueprint turretBlueprint; 

    public TurretNodePair(Node node, TurretBlueprint turretBlueprint)
    {
        this.node = node; 
        this.turretBlueprint = turretBlueprint;
    }

    
}
