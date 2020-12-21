using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartData : MonoBehaviour
{
    [Tooltip("Wskaż ScriptableObject, z którego część otrzyma dane. Domyślnie: Part Assemble Status")]
    public AssebleState assebleState;
    public AssebleState.AssebmleState assebmleState;
    void Start()
    {
        assebmleState = AssebleState.AssebmleState.none;
    }
}
