using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCam : MonoBehaviour
{
    public Transform TargetToFollow;
    public float zoomOutMin = 30;
    public float zoomOutMax = 60;
    public float Speed =0.1f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        test();
        if (Input.GetAxis("Mouse ScrollWheel")>0) {
            GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y - .1f, transform.position.z + .2f);
        } 
         if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y + .1f, transform.position.z - .2f);
        }
    }

    void test() {
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrePos = touchOne.position - touchOne.deltaPosition;
            float preMagnitude = (touchZeroPrevPos - touchOnePrePos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;
            float difference = currentMagnitude - preMagnitude;
            Debug.Log("TAG DIFFRENCE: " + difference + "currentMagnitude: "+ currentMagnitude+ " preMagnitude: "+ preMagnitude);
            zoom(difference * Speed);
        }

        zoom(Input.GetAxis("Mouse ScrollWheel"));
    } 
    void zoom(float increment)
    {
    Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }
}
