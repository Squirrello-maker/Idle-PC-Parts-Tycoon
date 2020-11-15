using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float spawnDelay = 5f;
    [SerializeField] PartsMovement partReference;
    // Update is called once per frame
    void Start()
    {
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn() 
    {
        while (true) 
        {
            yield return new WaitForSeconds(spawnDelay);
            //Vector3 hardcoded, change later to better option
            Instantiate(partReference, new Vector3(-15f, 0.5f, -129f), Quaternion.identity);
        }

    }

}
