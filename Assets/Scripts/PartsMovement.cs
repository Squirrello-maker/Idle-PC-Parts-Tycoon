using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsMovement : MonoBehaviour
{
    
    Queue<Waypoint> queueofWaypoints = new Queue<Waypoint>();
    List<Waypoint> testlist = new List<Waypoint>();
    [SerializeField] WaypointManager waypointManager;
    Waypoint[] arrayedQueue;
    Vector3 direction;
    float distance;
    void Start()
    {
        var waypoints = waypointManager.waypoints;
        EnqueueWaypoints(waypoints);
    }

    private float CalculateDistance()
    {
        arrayedQueue = queueofWaypoints.ToArray();
        distance = Vector3.Distance(transform.position, arrayedQueue[1].GetWaypointPosition());
        return distance;
    }

    private void EnqueueWaypoints(List<Waypoint> waypoints)
    {
        foreach(Waypoint waypoint in waypoints) 
        {
            queueofWaypoints.Enqueue(waypoint);
        }
        
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        float distance = CalculateDistance();
        direction = (transform.position - arrayedQueue[1].GetWaypointPosition());
        //print(distance);
        print(direction);
        if(distance <= 0.01f) 
        {
            queueofWaypoints.Dequeue();
            

        }
        else 
        {
            transform.position -= direction * Time.deltaTime;
        }
    }
    //
}
