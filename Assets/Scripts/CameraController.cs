using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 startPos;
    [SerializeField] float minZoom = 1f;
    [SerializeField] float maxZoom = 5f;
    public float clampedYMin = -50;
    public float clampedYMax = 50;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButton(0)) 
        {
            Vector3 direction = startPos - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position += direction;       
        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -50, 50), Mathf.Clamp(transform.position.y, clampedYMin, clampedYMax), transform.position.z);
        if (Input.touchCount == 2) 
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;
            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagintude = (touchZero.position - touchOne.position).magnitude;
            float diffrenceInMagnitude = currentMagintude - prevMagnitude;
            zoomCamera(diffrenceInMagnitude * .01f);
        }
        //For PC ONLY
        zoomCamera(Input.GetAxis("Mouse ScrollWheel"));
    }
    private void zoomCamera(float increment) 
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, minZoom, maxZoom);
    }
}
