using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
/// <summary>
/// This script manages all objects with Waypoint.cs script
/// namespace System.Linq is used to sort the array of waypoints because waypoints were positioned as they want
/// Script adds waypoints to list called "waypoints" which is used in PartsMovement.cs
/// </summary>
public class WaypointManager : MonoBehaviour
{
    public List<Waypoint> waypoints = new List<Waypoint>();
    void Awake()
    {
        InitalizeWaypoints();
    }

    private void InitalizeWaypoints()
    {
        Waypoint[] waypointsCache = FindObjectsOfType<Waypoint>(); //Get all waypoints on scene and save them as temp array
        foreach(Waypoint waypoint in waypointsCache) 
        {
            waypoints.Add(waypoint); //add each waypiont to unsorted list
        }
        waypoints = waypoints.OrderBy(go => go.name).ToList(); //overwrite list by sorted list
    }
    //method used to get sorted list in PartsMovement.cs
    public List<Waypoint> GetWaypoints() 
    {
        return waypoints;
    }
}
