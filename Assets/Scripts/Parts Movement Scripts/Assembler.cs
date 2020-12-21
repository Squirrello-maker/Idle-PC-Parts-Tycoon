using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assembler : MonoBehaviour
{
    [HideInInspector] public bool isMachineWorking = false;
    [Tooltip("Wskaż GameObject, do którego ma podążać część PO znalezieniu się w Assemblerze")]
    [SerializeField] GameObject objectToMoveTo;
    [Tooltip("Czas, w którym część znajdzie się na objectToMoveTo")]
    [SerializeField][Range(0f, 1f)] float timeToMove = .3f;
    [Tooltip("Czas, po którym włączy się ponownie collider")]
    [SerializeField] float boxColliderTime = 1f;
    [SerializeField] AssebmlerType assebmlerType;
    PartsMovement currentPart;
    BoxCollider assemblerCollider;
    private void Awake()
    {
        assemblerCollider = GetComponent<BoxCollider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        //Checking if part has same state as type of assembler
        if(other.tag == "Part" && other.GetComponent<PartData>().assebmleState != assebmlerType.typeOfAssembler) 
        {
            currentPart = other.GetComponent<PartsMovement>();
            other.GetComponent<PartData>().assebmleState = assebmlerType.typeOfAssembler; //set part state of asseblmer type
            currentPart.isOnMachine = true; //flag to disable movement in PartsMovement.cs
            assemblerCollider.enabled = false;  //disable collider to ignore other parts when this machine working         
            MoveToAssembler(other);
        }
    }

    private void MoveToAssembler(Collider part)
    {
        //-----------------Get information to coroutine----------------------------
        Vector3 source = part.GetComponent<PartsMovement>().GetPartPosition();
        Vector3 target = objectToMoveTo.transform.position;
        Transform partObject = part.transform;
        StartCoroutine(ProceedMoveToAssembler(source, target, timeToMove, partObject));
        
         
    }
    IEnumerator ProceedMoveToAssembler(Vector3 source, Vector3 target, float overTime, Transform partObject) 
    {
        float startTime = Time.time; //Get init time
        //while time of game is less than sum of startTime and overTime
        while (Time.time < startTime + overTime)
        {
            partObject.position = Vector3.Lerp(source, target, (Time.time - startTime) / overTime); //use Lerp to change position
            yield return null; //don't wait
        }
        partObject.transform.position = target; //at breaking the loop, set position to target position
        StartCoroutine(WaitToReturn());
    }
    //used in AssemblerMaker.cs, same as ProceedMoveToAssembler()
    public IEnumerator ProcessReturnToLine(Vector3 source, Vector3 target, float overTime, Transform partObject) 
    {
        float startTime = Time.time;
        while (Time.time < startTime + overTime)
        {
            partObject.position = Vector3.Lerp(source, target, (Time.time - startTime) / overTime);
            yield return null;
        }
        partObject.transform.position = target;
        isMachineWorking = false;
        StopCoroutine(WaitToReturn());
        SendAhead();
    }
    void SendAhead() 
    {
        currentPart.isOnMachine = false; //disable flag to enable movement in PartsMovement.cs
        if(assebmlerType.typeOfAssembler == AssebleState.AssebmleState.motherboard) 
        {
            GetComponent<MoboAssembler>().isPartAssigned = false;
        }
        Invoke("EnableCollider", boxColliderTime); //enable collider after boxColliderTime amount

    }
    void EnableCollider() 
    {
        assemblerCollider.enabled = true;
    }
    IEnumerator WaitToReturn() 
    {
        yield return new WaitForSeconds(3f);
        isMachineWorking = true; //set working state of machine
    }
    public AssebleState.AssebmleState GetAssebmlerType() 
    {
        return assebmlerType.typeOfAssembler;
    }
    [System.Serializable]
    private class AssebmlerType 
    {
        public AssebleState.AssebmleState typeOfAssembler; //select in Inspector assembler type
    }
}
