using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTest : MonoBehaviour
{
    public float PCRotationSpeed = 0.00000001f;
    public float MobileRotationSpeed = 0.4f;
    //Drag the camera object here
    public Camera cam;
    Vector3 prevous;
    void OnMouseDrag()
    {
        float rotX = Input.mousePosition.x * PCRotationSpeed * Mathf.Deg2Rad;
        float rotY = Input.mousePosition.y * PCRotationSpeed * Mathf.Deg2Rad;
        Debug.Log("TAG rotX: " + Input.GetAxis("Mouse X"));  
        transform.Rotate(Vector3.up, -rotX, Space.Self);
      //  transform.Rotate(Vector3.right, rotY, Space.World);
    }

    void Update()
    { 
        if (Input.GetMouseButton(0))
        {
            Debug.Log("TAG ON ROTATE");
            if (Input.mousePosition != prevous)
            {
                OnMouseDrag();
            }
            
            prevous = Input.mousePosition;
        }
      /*  // get the user touch input
        foreach (Touch touch in Input.touches)
        {
            Debug.Log("Touching at: " + touch.position);
            Ray camRay = cam.ScreenPointToRay(touch.position);
            RaycastHit raycastHit;
            if (Physics.Raycast(camRay, out raycastHit, 10))
            {
                if (touch.phase == TouchPhase.Began)
                {
                    Debug.Log("Touch phase began at: " + touch.position);
                }
                else if (touch.phase == TouchPhase.Moved 
                {
                    Debug.Log("Touch phase Moved");
                    transform.Rotate(touch.deltaPosition.y * MobileRotationSpeed,
                        -touch.deltaPosition.x * MobileRotationSpeed, 0, Space.World);
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    Debug.Log("Touch phase Ended");
                }
            }*/
     
    }
}