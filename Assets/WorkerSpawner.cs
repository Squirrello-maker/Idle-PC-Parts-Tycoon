using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerSpawner : MonoBehaviour
{
    [SerializeField] GameObject workerPrefab;
    public void SpawnNewWorker() 
    {
        Instantiate(workerPrefab, new Vector3(-15f, 0.04f, -135f), Quaternion.identity);
    }
}
