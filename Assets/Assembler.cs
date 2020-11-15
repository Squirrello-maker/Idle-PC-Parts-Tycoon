using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assembler : MonoBehaviour
{
    public bool isMachineWorking = false;
    [SerializeField] GameObject objectToMoveTo;
    [SerializeField] float timeToMove = .3f;
    private void Awake()
    { 
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Part") 
        {
            other.GetComponent<PartsMovement>().isOnMachine = true;
            GetComponent<BoxCollider>().enabled = false;
            isMachineWorking = true;
            MoveToAssembler(other);
            //Make mobo
            //Move Again
        }
    }

    private void MoveToAssembler(Collider part)
    {
        Vector3 source = part.GetComponent<PartsMovement>().GetPartPosition();
        Vector3 target = objectToMoveTo.transform.position;
        Transform partObject = part.transform;
        StartCoroutine(ProceedMoveToAssembler(source, target, timeToMove, partObject));
        
         
    }
    IEnumerator ProceedMoveToAssembler(Vector3 source, Vector3 target, float overTime, Transform partObject) 
    {
        float startTime = Time.time;
        while (Time.time < startTime + overTime) 
        {
            partObject.position = Vector3.Lerp(source, target, (Time.time - startTime) / overTime);
            yield return null;
        }
        partObject.transform.position = target;
    }
}
