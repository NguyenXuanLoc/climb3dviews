using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom_Controller : MonoBehaviour
{
    [SerializeField] private Camera cam;

    float ZoomMinBound = 10f;
    float ZoomMaxBound = 50f;
    float TouchZoomSpeed = 0.01f;
    private void Start()
    {
    }
    private void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrePos = touchOne.position - touchOne.deltaPosition;
            float preMagnitude = (touchZeroPrevPos - touchOnePrePos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;
            float difference =  preMagnitude - currentMagnitude;
            Zoom(difference, TouchZoomSpeed);

        }
    }
    void Zoom(float deltaMagnitudeDiff, float speed)
    {
        cam.fieldOfView += deltaMagnitudeDiff * speed;
        // set min and max value of Clamp function upon your requirement
        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, ZoomMinBound, ZoomMaxBound);
    }
}
