using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoboAssembler : MonoBehaviour
{
    Spawner spawner;
    public bool isPartAssigned = false;
    private void OnEnable()
    {
        spawner = FindObjectOfType<Spawner>();
        spawner.UpdateMoboAssemblers();
    }

}
