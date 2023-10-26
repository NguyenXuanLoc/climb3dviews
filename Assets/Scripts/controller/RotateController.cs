using DigitalRubyShared;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform target;
    [SerializeField] private float distanceToTarget = 10;
    [SerializeField] public GameObject Eatch;
    [SerializeField] private RotateGestureRecognizer rotateGesture;

    private Vector3 previousPosition;

    private void RotateGestureCallback(GestureRecognizer gesture)
    {
        if (gesture.State == GestureRecognizerState.Executing)
        {
            Eatch.transform.Rotate(0.0f, 0.0f, rotateGesture.RotationRadiansDelta * Mathf.Rad2Deg);
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
        if(Input.touchCount == 2 && ((Input.GetTouch(0).phase == UnityEngine.TouchPhase.Began) || (Input.GetTouch(1).phase == UnityEngine.TouchPhase.Began)))
        {
            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.touchCount == 2 && (Input.GetTouch(0).phase == UnityEngine.TouchPhase.Moved || Input.GetTouch(1).phase == UnityEngine.TouchPhase.Moved))
        {
            Utils.setRotate(true);
            Vector3 newPosition = cam.ScreenToViewportPoint(Input.mousePosition);
            Vector3 direction = previousPosition - newPosition;
            float rotationAroundYAxis = direction.x * 180; // camera moves horizontally
            float rotationAroundXAxis = -direction.y * 180; // camera moves vertically
            
            if (direction.y < 0) //SWIPE BOTTOM
            {
                if ((getXAxis() >= 0 && getXAxis() < 90) || (getXAxis() > 250 && getXAxis() <= 360))
                {
                    target.transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);
                    previousPosition = newPosition;
                    if (getXAxis() >= 90 && !(getXAxis() >= 270 && getXAxis() <= 360))
                    { 
                        target.transform.localEulerAngles = new Vector3(90, target.transform.eulerAngles.y, target.transform.eulerAngles.z);
                    }
                }
            } 

            else if (direction.y > 0) //SWIPE TOP
            {
                if (getXAxis() <= 90 || (getXAxis() > 270 && getXAxis() <= 360))
                {
                    target.transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);
                    previousPosition = newPosition;
                    if (getXAxis() <= 270 && !(getXAxis() >= 0 && getXAxis() <= 90))
                    {
                        target.transform.localEulerAngles = new Vector3(270, target.transform.eulerAngles.y, target.transform.eulerAngles.z);
                    }
                }

            }  
             
            if (direction.x > 0) //SWIPE LEFT
            {
                if ((getYAxis() >= 0 && getYAxis() <= 90) || (getYAxis() >= 250 && getYAxis() <= 360))
                {
                    target.transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.World);
                    previousPosition = newPosition;
                    if (getYAxis() > 90 && !(getYAxis() >= 270 && getYAxis() <= 360))
                    {
                        target.transform.localEulerAngles = new Vector3(target.transform.eulerAngles.x, 90, target.transform.eulerAngles.z);
                    }
                }  
            }
            else if (direction.x < 0) //SWIPE RIGHT  
            {
                if (getYAxis() <= 90 || (getYAxis() > 270 && getYAxis() <= 360))
                {
                    target.transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.World);
                    previousPosition = newPosition;
                }
                if (getYAxis() <= 270 && !(getYAxis() >= 0 && getYAxis() <= 90))
                {
                    target.transform.localEulerAngles = new Vector3(target.transform.eulerAngles.x, 270, target.transform.eulerAngles.z);
                }
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
    int getYAxis()
    {
        return Convert.ToInt32(target.transform.rotation.eulerAngles.y);
    }
    int getXAxis()
    { 
        return Convert.ToInt32(target.transform.rotation.eulerAngles.z);
    }

}