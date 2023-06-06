using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateController : MonoBehaviour
{
    public float rotateSpeed = 0.5f;
    public float zoomSpeed = 1f;
    public float zoomThreshold = 50.0f;
    private float startDistance;

    void Update()
    {
        if (Input.touchCount == 2)
        {
            Utils.setTwoTouch(true);
            Utils.setRotate(false);
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);
        if ((touch1.phase == TouchPhase.Moved && !(touch2.phase == TouchPhase.Moved)))
            { 
                Utils.setRorationAroundY(touch1.deltaPosition.y);
            }else if ( (touch2.phase == TouchPhase.Moved && !(touch1.phase == TouchPhase.Moved)))
            {
                Utils.setRorationAroundY(touch2.deltaPosition.y);
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