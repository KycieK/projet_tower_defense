using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[System.Serializable]
public class Waypoints : MonoBehaviour
{
    WaypointsList waypointsList;
    void Awake () 
    {
        WaypointsList.waypoints.Add(this.transform);
        Debug.Log("Added " + transform + " to list");
    }
}
