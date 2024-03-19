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
    [SerializeField] public Transform point;
    [SerializeField] private RotateGestureRecognizer rotateGesture;

    float max = 89;
    float min = -89;
    private Vector3 previousPosition;
    private float rotationZ = 0;

    private Vector2 startPos1;
    private Vector2 startPos2;
    bool? isSameDirection = false;
    private void RotateGestureCallback(GestureRecognizer gesture)
    {
        if (gesture.State == GestureRecognizerState.Executing)
        {
            if (Input.touchCount >= 2 && Input.GetTouch(0).phase == UnityEngine.TouchPhase.Moved && Input.GetTouch(1).phase == UnityEngine.TouchPhase.Moved && isSameDirection == false)
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
        if(Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0); // Get the first touch
            Touch touch2 = Input.GetTouch(1); // Get the second touch
            if ( ((Input.GetTouch(0).phase == UnityEngine.TouchPhase.Began) || (Input.GetTouch(1).phase == UnityEngine.TouchPhase.Began)))
            {
                previousPosition = cam.ScreenToViewportPoint(Input.GetTouch(0).position);
                startPos1 = touch1.position;
                startPos2 = touch2.position;
            }
            else if ((Input.GetTouch(0).phase == UnityEngine.TouchPhase.Moved && Input.GetTouch(1).phase == UnityEngine.TouchPhase.Moved))
            {
                Vector2 endPos1 = touch1.position;
                Vector2 endPos2 = touch2.position;
                 
                bool? sameDirection = Utils.AreFingersMovingInSameDirection(startPos1, endPos1, startPos2, endPos2);
                isSameDirection = sameDirection;
                if (sameDirection == null || sameDirection == false)
                {
                    previousPosition = cam.ScreenToViewportPoint(Input.GetTouch(0).position); 
                    startPos1 = touch1.position;  
                    startPos2 = touch2.position;
                   // Debug.Log("TAG STOP ROTATE");
                    return;
                }
               // Debug.Log("TAG ROTATE");
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
                    // Step 1: Translate the game object's position to the origin
                    Vector3 objectPosition = target.transform.position;
                    Vector3 difference = objectPosition - point.position;
                     
                    // Step 2: Rotate the game object
                    Quaternion rotation = Quaternion.Euler(Utils.quaternion.x == 89 || Utils.quaternion.x == -89 ? 0: rotationAroundXAxis * 0.9f, 
                                                           Utils.quaternion.y == 89 || Utils.quaternion.y == -89 ? 0 : rotationAroundYAxis * 0.9f, 0);
                    difference = rotation * difference; 
                    // Debug.Log("TAG POINT: " + point.position.z +" ___ WALL: "+target.transform.position.z);
                    // Step 3: Translate the game object's position back to its original position
                    target.transform.position = point.position + difference;

                 /*   point.position = new Vector3(point.position.x, point.position.y, target.transform.position.z - 3);
                    cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, -47*//*cam.transform.position.z*//* + point.position.z);
                */    target.transform.localRotation = Quaternion.Euler(Utils.quaternion.x, Utils.quaternion.y, Utils.quaternion.z);
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
}