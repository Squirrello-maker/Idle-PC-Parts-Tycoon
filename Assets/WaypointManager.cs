using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    public List<Waypoint> waypoints = new List<Waypoint>();
    // Start is called before the first frame update
    void Awake()
    {
        InitalizeWaypoints();
    }

    private void InitalizeWaypoints()
    {
        Waypoint[] waypointsCache = FindObjectsOfType<Waypoint>();
        foreach(Waypoint waypoint in waypointsCache) 
        {
            waypoints.Add(waypoint);
        }
        waypoints.Reverse();
    }
    public List<Waypoint> GetWaypoints() 
    {
        return waypoints;
    }
}
