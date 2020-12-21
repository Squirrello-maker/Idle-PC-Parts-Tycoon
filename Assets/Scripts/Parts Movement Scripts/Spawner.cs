using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Spawner : MonoBehaviour
{
    [Tooltip("Czas respawnu")]
    [SerializeField] float spawnDelay = 5f;
    [Tooltip("Referencja do prefabu części")]
    [SerializeField] PartsMovement partReference;
    [SerializeField] MoboAssembler[] moboAssemblers;
    void Start()
    {
        UpdateMoboAssemblers();
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn() 
    {
        while (true) 
        {
            foreach (MoboAssembler assembler in moboAssemblers) 
            {
                if(assembler.isPartAssigned == false) 
                {
                    assembler.isPartAssigned = true;
                    Instantiate(partReference, new Vector3(-15f, 0.5f, -130f), Quaternion.identity);                   
                    yield return new WaitForSeconds(1f);
                }
            }
            yield return new WaitForSeconds(spawnDelay);
            //Vector3 hardcoded, change later to better option
            //Instantiate(partReference, new Vector3(-15f, 0.5f, -130f), Quaternion.identity);

        }

    }
    void SortMoboAssemblers()
    {
        moboAssemblers.OrderBy(go => go.name);
    }
    public void UpdateMoboAssemblers()
    {
        moboAssemblers = FindObjectsOfType<MoboAssembler>();
        SortMoboAssemblers();
    }
}
