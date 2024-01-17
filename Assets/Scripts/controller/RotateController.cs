using DigitalRubyShared;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
enum SWIPE
{
    LEFT,RIGHT,TOP,BOTTOM
}
public class RotateController : MonoBehaviour
{
    [SerializeField] private Camera cam; 
    [SerializeField] private Transform target;
    [SerializeField] private float distanceToTarget = 10;
    [SerializeField] public GameObject Eatch;
    [SerializeField] private RotateGestureRecognizer rotateGesture;

    private Quaternion quaternion;
    float max = 89;
    float min = -89;
    private Vector3 previousPosition;
    private float rotationZ = 0;
    private void RotateGestureCallback(GestureRecognizer gesture)
    {
        if (gesture.State == GestureRecognizerState.Executing)
        {
            if (Input.touchCount >= 2)
            {
                var first = Input.GetTouch(0).position;
                var second = Input.GetTouch(1).position;
                float distance = Vector3.Distance(first, second);
                if (distance > 250)
                {
                    rotationZ = rotateGesture.RotationRadiansDelta * Mathf.Rad2Deg;
                    quaternion.z += rotationZ;
                }
            }
        }
    }

    private void CreateRotateGesture()
    {
        rotateGesture = new RotateGestureRecognizer();
        rotateGesture.StateUpdated += RotateGestureCallback;
        FingersScript.Instance.AddGesture(rotateGesture);
    }

    private void Start()
    {
        CreateRotateGesture();
    }

    private void Update()
    { 
        if (Input.touchCount == 2 && ((Input.GetTouch(0).phase == UnityEngine.TouchPhase.Began) || (Input.GetTouch(1).phase == UnityEngine.TouchPhase.Began)))
        {
            previousPosition = cam.ScreenToViewportPoint(Input.GetTouch(0).position);
        }
        else if (Input.touchCount == 2 && (Input.GetTouch(0).phase == UnityEngine.TouchPhase.Moved && Input.GetTouch(1).phase == UnityEngine.TouchPhase.Moved))
        {
            Utils.setRotate(true);
            Vector3 newPosition = cam.ScreenToViewportPoint(Input.GetTouch(0).position);
            Vector3 direction = previousPosition - newPosition;
            float rotationAroundYAxis = direction.x * 180;  // camera moves horizontally
            float rotationAroundXAxis = -direction.y * 180; // camera moves vertically

            quaternion.x += rotationAroundXAxis * 0.9f;
            quaternion.y += rotationAroundYAxis * 0.9f;
            quaternion.x = Mathf.Clamp(quaternion.x, min,max);
            quaternion.y = Mathf.Clamp(quaternion.y, min,max);
            target.transform.localRotation = Quaternion.Euler(quaternion.x, quaternion.y, quaternion.z);
            previousPosition = newPosition;
        }
        else
        {
            Utils.setRotate(false);
        }
        if (Input.touchCount == 0)
        {
            Utils.setTwoTouch(false);
        }
    }
}