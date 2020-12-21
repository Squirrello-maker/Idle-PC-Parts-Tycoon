using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cluster : MonoBehaviour
{
    public int workersAssigned = 0;
    public int maxWorkers = 4;
    [SerializeField] AssebleState.AssebmleState clusterType;
    public AssebleState.AssebmleState GetClusterType() 
    {
        return clusterType;
    }
}
