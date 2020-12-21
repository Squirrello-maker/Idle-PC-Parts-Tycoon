using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerStation : MonoBehaviour
{
    Cluster cluster;
    private void Awake()
    {
        cluster = GetComponentInParent<Cluster>();
    }
    public Transform GetTransformOfWorkerStation() 
    {
        return transform;
    }
    public void DisableThisStation() 
    {
        enabled = false;
    }

}
