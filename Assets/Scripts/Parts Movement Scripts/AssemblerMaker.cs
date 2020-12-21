using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script is responsible for returning a modified part to assembly line
/// </summary>
public class AssemblerMaker : MonoBehaviour
{
    Assembler myAssembler;
    Transform partObject;
    [Tooltip("Obiekt, z którego część ma 'zejść'")]
    [SerializeField] GameObject objectToMoveFrom;
    //variables below will be used in SciptableObject
    [Tooltip("Czas, w którym część powróci na assembler")]
    [SerializeField] [Range(0f, 1f)] float period = .5f;
    void Awake()
    {
        myAssembler = GetComponent<Assembler>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Part") 
        {
            partObject = other.transform; //store information about part to coroutine
        }
    }
    void LateUpdate()
    {
        if(myAssembler.isMachineWorking == true) 
        {
            ReturnToLine();
        }
    }
    void ReturnToLine() 
    {
        StartCoroutine(myAssembler.ProcessReturnToLine(objectToMoveFrom.transform.position, transform.position, period, partObject));
    }

}
