using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpRotation : MonoBehaviour
{
    public float rotatespeed = 200f;
    private Vector2 _startingPosition;


    void Update()
    {  
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _startingPosition = touch.position;
                    break;
                case TouchPhase.Moved:
      
                    if (_startingPosition.x > touch.position.x)
                    {
                        transform.Rotate(new Vector3(0, 1, 0), -rotatespeed * Time.deltaTime);
                    }
                    else if (_startingPosition.x < touch.position.x)
                    {
                        transform.Rotate(new Vector3(0, 1, 0), rotatespeed * Time.deltaTime);
                    }
                     if (_startingPosition.y > touch.position.y)
                    {
                        transform.Rotate(new Vector3(1, 0, 0), -rotatespeed * Time.deltaTime);
                    }
                    else if (_startingPosition.y < touch.position.y)
                    {
                        transform.Rotate(new Vector3(1, 0, 0), rotatespeed * Time.deltaTime);
                    }
                    break;
                case TouchPhase.Ended:
                    Debug.Log("Touch Phase Ended.");
                    break;
            }
        }
    }
}
