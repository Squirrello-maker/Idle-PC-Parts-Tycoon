using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script are mandatory part of WaypointManager.cs
/// All objects with this script will be a waypoint, where part is being moved
/// Method is used to get positions while PartsMovement.cs calculate a distance
/// </summary>
public class Waypoint : MonoBehaviour
{
    public Vector3 GetWaypointPosition() 
    {
        return transform.position;
    }

}
