using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script manages earning in-game currency
/// </summary>
public class MoneyMaker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
