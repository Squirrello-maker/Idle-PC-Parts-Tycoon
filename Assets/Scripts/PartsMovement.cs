using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsMovement : MonoBehaviour
{
<<<<<<< Updated upstream
    
    Queue<Waypoint> queueofWaypoints = new Queue<Waypoint>();
    List<Waypoint> testlist = new List<Waypoint>();
    [SerializeField] WaypointManager waypointManager;
    Waypoint[] arrayedQueue;
    Vector3 direction;
    float distance;
=======
    public bool isOnMachine = false;
    Queue<Waypoint> queueofWaypoints = new Queue<Waypoint>();
    WaypointManager waypointManager;
    Waypoint[] arrayedQueue;
    Assembler assembler;
    GlobalVars varsG;
    Vector3 direction;
    float distance;
    float speed = 1;
    bool nextPointLoaded = false;
    private void Awake()
    {
        assembler = FindObjectOfType<Assembler>();
        waypointManager = FindObjectOfType<WaypointManager>();
    }
>>>>>>> Stashed changes
    void Start()
    {
        var waypoints = waypointManager.waypoints;
        EnqueueWaypoints(waypoints);
<<<<<<< Updated upstream
=======
        arrayedQueue = queueofWaypoints.ToArray();
        direction = GetDirection();
>>>>>>> Stashed changes
    }

    private float CalculateDistance()
    {
<<<<<<< Updated upstream
        arrayedQueue = queueofWaypoints.ToArray();
        distance = Vector3.Distance(transform.position, arrayedQueue[1].GetWaypointPosition());
=======
        distance = Vector3.Distance(transform.position, arrayedQueue[0].GetWaypointPosition());
>>>>>>> Stashed changes
        return distance;
    }

    private void EnqueueWaypoints(List<Waypoint> waypoints)
    {
        foreach(Waypoint waypoint in waypoints) 
        {
            queueofWaypoints.Enqueue(waypoint);
        }
        
<<<<<<< Updated upstream
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
=======
       
    }
    void Update()
    {
        Move(direction);
    }

    private void Move(Vector3 desiredDirection)
    {
        float distance = CalculateDistance();
        if (distance <= 0.1f) 
        {
            DequeueWaypoint();     
        }
        else if (isOnMachine)
        {
            return;
        }  
        else if(assembler.isMachineWorking)
        {
                transform.position -= desiredDirection * speed * Time.deltaTime;
        }  
        else 
        {
                transform.position -= desiredDirection * speed * Time.deltaTime;
        }    
    }

    private void DequeueWaypoint()
    {
        if (!nextPointLoaded) 
        {
            queueofWaypoints.Dequeue();
            nextPointLoaded = true;
            LoadNextWaypoint();
        }
        
    }

    private void LoadNextWaypoint()
    {
        arrayedQueue = queueofWaypoints.ToArray();
        CalculateDistance();
        direction = GetDirection();
        nextPointLoaded = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Machine") 
        {
            varsG = other.gameObject.GetComponent<GlobalVars>();
        }
    }
    Vector3 GetDirection() 
    {

        Vector3  desiredDirection = transform.position - arrayedQueue[0].GetWaypointPosition();
        return desiredDirection;
    }
    public Vector3 GetPartPosition() 
    {
        return transform.position;
    }
>>>>>>> Stashed changes
}
