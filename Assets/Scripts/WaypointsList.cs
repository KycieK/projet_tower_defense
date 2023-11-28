using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;

[System.Serializable]
public  class WaypointsList : MonoBehaviour
{
    [SerializeField]
    public static List<Transform> waypoints = new List<Transform>();

}
