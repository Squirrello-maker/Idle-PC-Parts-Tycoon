using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDetection : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            CheckRaycast(touchPosition);
        }

    }
    void CheckRaycast(Vector3 touchPosition) 
    {
        RaycastHit hit;
        
        if (Input.touchCount < 2)  
        {
            if (Physics.Raycast(touchPosition, transform.forward, out hit) && hit.transform.tag != "Invicible")
            {
                Destroy(hit.transform.gameObject);
            }
        }

    }
}
