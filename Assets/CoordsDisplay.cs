using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[ExecuteInEditMode]
public class CoordsDisplay : MonoBehaviour
{
    //Display Waypoint Coords
    //REMOVE THIS SCRIPT FROM GAMEOBJECT WHEN GAME IS FINISHED
    [SerializeField] TextMeshPro coordsLabel;
    private void Update()
    {
        float xPos = transform.position.x;
        float zPos = transform.position.z;
        xPos = Mathf.RoundToInt(xPos);
        zPos = Mathf.RoundToInt(zPos);
        coordsLabel.text = xPos.ToString() + " , " + zPos.ToString();

    }
}
