using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyMaker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
