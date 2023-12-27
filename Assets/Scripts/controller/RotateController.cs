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

    private Vector3 previousPosition;

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
    SWIPE swipe;
    float maxBottom = 0;
    float maxTop = 0;
    private void Update()
    {
        print("TAG getXAxis(): " + maxTop+ "maxTop: " + maxTop);
        if (Input.touchCount == 2 && ((Input.GetTouch(0).phase == UnityEngine.TouchPhase.Began) || (Input.GetTouch(1).phase == UnityEngine.TouchPhase.Began)))
        {
            previousPosition = cam.ScreenToViewportPoint(Input.GetTouch(0).position);
        }
        else if (Input.touchCount == 2 && (Input.GetTouch(0).phase == UnityEngine.TouchPhase.Moved && Input.GetTouch(1).phase == UnityEngine.TouchPhase.Moved))
        {
            Utils.setRotate(true);
            Vector3 newPosition = cam.ScreenToViewportPoint(Input.GetTouch(0).position);
            Vector3 direction = previousPosition - newPosition;
            float rotationAroundYAxis = direction.x * 180; // camera moves horizontally
            float rotationAroundXAxis = -direction.y * 180; // camera moves vertically

            if (direction.y < 0) //SWIPE BOTTOM
            {
                if (getXAxis() < 0.7)
                {
                   target.transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);
                    previousPosition = newPosition;
                }
            }

            else if (direction.y > 0) //SWIPE TOP
            {
                if (getXAxis() > -0.7)
                {
                    target.transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);
                    previousPosition = newPosition;
                }
            }

            if (direction.x > 0) //SWIPE LEFT
            {
               print("TAG SET SWIPE LEFT: " + getYAxis());
                if (getYAxis()<0.7)
                {
                    target.transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.World);
                    previousPosition = newPosition;
                } 
               
            } 
            else if (direction.x < 0) //SWIPE RIGHT  
            {
              print("TAG SET SWIPE RIGHT: " + getYAxis());
                if (getYAxis()>-0.7)
                {
                    target.transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.World);
                    previousPosition = newPosition;
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
    private static float WrapAngle(float angle)
    {
        angle %= 360;
        var result = angle - 360;
        if (angle == -80) print("TAG RESULT: " + result);
        if (angle > 180)
            return angle - 360;
        result = angle - 360; ;
        if (angle == -80) print("TAG RESULT: " + result);
        return angle;
    }

    float getYAxis()
    {
        return target.transform.localRotation.y;
      //  return target.transform.rotation.eulerAngles.y;
      //  return Convert.ToInt32(target.transform.rotation.eulerAngles.y);
    }
    float getXAxis()
    {
        return target.transform.localRotation.x;
     //   return target.transform.rotation.eulerAngles.x;
     //   return Convert.ToInt32(target.transform.rotation.eulerAngles.z);
    }

}