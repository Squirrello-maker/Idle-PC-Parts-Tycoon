using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class TestLerpScript : MonoBehaviour
{
    [SerializeField] Transform startPos;
    [SerializeField] Transform endPos;
    [SerializeField] [Range(0f, 1f)] float progrees = 0f;
    void Update()
    {
        transform.position = Vector3.Lerp(startPos.position, endPos.position, progrees);
    }
}
