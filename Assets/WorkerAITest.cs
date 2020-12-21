using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class WorkerAITest : MonoBehaviour
{
    NavMeshAgent workerAgent;
    CollectionPoint target;
    [SerializeField] Cluster[] clusters;
    [SerializeField] WorkerStation[] workerStations;
    bool stationSelected = false;
    // Start is called before the first frame update
    void Start()
    {
        workerAgent = GetComponent<NavMeshAgent>();
        clusters = FindObjectsOfType<Cluster>();
        target = FindObjectOfType<CollectionPoint>();
        clusters = SortingScript.SortClusters(clusters);
        workerAgent.SetDestination(target.transform.position);
    }
    // Update is called once per frame
    void Update()
    {
        if(workerAgent.remainingDistance <= .1f && !stationSelected) 
        {
            CheckClustersAvability();
        }
        else if(workerAgent.remainingDistance <=.1f && stationSelected) 
        {
            Debug.LogWarning("Effects Applied");
        }
    }
    private void CheckClustersAvability()
    {
        foreach (Cluster checkedCluster in clusters)
        {
            if (checkedCluster.workersAssigned < checkedCluster.maxWorkers)
            {
                checkedCluster.workersAssigned++;
                workerStations = checkedCluster.GetComponentsInChildren<WorkerStation>();
                SelectWorkerStation(workerStations);
                return;
            }
        }
    }
    private void SelectWorkerStation(WorkerStation[] workerStations)
    {
        foreach (WorkerStation station in workerStations)
        { 
            if (station.isActiveAndEnabled)
            {  
                workerAgent.SetDestination(station.transform.position);
                station.DisableThisStation();
                stationSelected = !stationSelected;
                Debug.DrawLine(transform.position, station.transform.position, Color.red);
                break;
            }
        }
    }
    
}
