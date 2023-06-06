using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom_Controller : MonoBehaviour
{
    [SerializeField] private Camera cam;

    float ZoomMinBound = 10f;
    float ZoomMaxBound = 90f;
    float TouchZoomSpeed = 0.02f;
    float minScale = 26.99147f;
    private void Start()
    {
    }
    private void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);
            if(touchZero.phase == TouchPhase.Moved && touchOne.phase == TouchPhase.Moved)
            {
                Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                Vector2 touchOnePrePos = touchOne.position - touchOne.deltaPosition;
                float preMagnitude = (touchZeroPrevPos - touchOnePrePos).magnitude;
                float currentMagnitude = (touchZero.position - touchOne.position).magnitude;
                float difference = preMagnitude - currentMagnitude;
                Zoom(difference, TouchZoomSpeed);
            } 

        }
    }
    void Zoom(float deltaMagnitudeDiff, float speed)
    {
        cam.fieldOfView += deltaMagnitudeDiff * speed;
        // set min and max value of Clamp function upon your requirement 
        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, ZoomMinBound, ZoomMaxBound);
        if (cam.focalLength <= 50) cam.focalLength = 50;
   //     Debug.Log("TAG VALUE: " + 5.292 / (cam.fieldOfView));
    }
}
