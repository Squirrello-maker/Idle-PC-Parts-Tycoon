using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorkerAI : MonoBehaviour
{
    NavMeshAgent workerAgent;
    [SerializeField] Transform target;
    //[SerializeField] Transform target2;
    [SerializeField] Cluster[] clusters;
    [SerializeField] WorkerStation[] workerStations;
    // Start is called before the first frame update
    void Start()
    {
        workerAgent = GetComponent<NavMeshAgent>();
        clusters = FindObjectsOfType<Cluster>();
    }

    // Update is called once per frame
    void Update()
    {
     workerAgent.SetDestination(target.position);
     //Debug.DrawLine(transform.position, target.position, Color.red);
     Debug.Log(workerAgent.pathStatus);
            //CheckClustersAvability();      
    }


    //this is working correctly
    private void CheckClustersAvability()
    {
        foreach(Cluster checkedCluster in clusters)
        {
            if(checkedCluster.workersAssigned <= checkedCluster.maxWorkers) 
            {
                 workerStations = checkedCluster.GetComponentsInChildren<WorkerStation>();
                SelectWorkerStation(workerStations);
                //return;
            }
        }
    }

    private void SelectWorkerStation(WorkerStation[] workerStations)
    {
        foreach (WorkerStation station in workerStations)
        {

            workerAgent.SetDestination(station.transform.position);
            
            if (station.isActiveAndEnabled) 
            {
                
                Debug.DrawLine(transform.position, station.transform.position, Color.red);
                break;
            }
        }
    }
}
