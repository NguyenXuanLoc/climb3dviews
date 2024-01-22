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

    float max = 89;
    float min = -89;
    private Vector3 previousPosition;
    private float rotationZ = 0;
    private void RotateGestureCallback(GestureRecognizer gesture)
    {
        if (gesture.State == GestureRecognizerState.Executing)
        {
            if (Input.touchCount >= 2 && Input.GetTouch(0).phase == UnityEngine.TouchPhase.Moved && Input.GetTouch(1).phase == UnityEngine.TouchPhase.Moved)
            { 
                var first = Input.GetTouch(0).position;
                var second = Input.GetTouch(1).position;
                float distance = Vector3.Distance(first, second);
                if (distance > 250)
                {
                    rotationZ = rotateGesture.RotationRadiansDelta * Mathf.Rad2Deg;
                    Utils.quaternion.z += rotationZ;
                    Eatch.transform.Rotate(0.0f, 0.0f, rotateGesture.RotationRadiansDelta * Mathf.Rad2Deg);
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
            float distance = Vector3.Distance(newPosition, previousPosition);
            if (distance > 0.01)
            {
               // print("TAG distance:" + distance);
                float rotationAroundYAxis = direction.x * 180;  // camera moves horizontally
                float rotationAroundXAxis = -direction.y * 180; // camera moves vertically

                Utils.quaternion.x += rotationAroundXAxis * 0.9f;
                Utils.quaternion.y += rotationAroundYAxis * 0.9f;
                Utils.quaternion.x = Mathf.Clamp(Utils.quaternion.x, min, max);
                Utils.quaternion.y = Mathf.Clamp(Utils.quaternion.y, min, max);
                target.transform.localRotation = Quaternion.Euler(Utils.quaternion.x, Utils.quaternion.y, Utils.quaternion.z);
                previousPosition = newPosition;

            }
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