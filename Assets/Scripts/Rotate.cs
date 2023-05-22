using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Rotate : MonoBehaviour, IDragHandler
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform target;
    [SerializeField] private float distanceToTarget = 10;
    [SerializeField] private float maxSize = 197;
    [SerializeField] private float minSize = 50;
    float currentIncrement = 0;


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
            float difference = currentMagnitude - preMagnitude;        
            zoom(difference);

        }
    }
    void zoom(float increment)
        {
            if (increment >= 0 && currentIncrement>=0)
            {
            if(cam.focalLength< maxSize)
                cam.focalLength += 2.2f;
            }
            else
            {
            if(cam.focalLength>minSize)
                cam.focalLength -= 2.2f;
            }
        currentIncrement = increment;
        Utils.setFocalLenght(cam.focalLength);
        Utils.setX(cam.transform.position.x);
        Utils.setY(cam.transform.position.y);
        // cam.focalLength = 100;
        // cam.orthographicSize
        // cam.orthographicSize = Mathf.Clamp(cam.orthographicSize - increment, 30, 60);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("TAG ONDRAG");
        throw new System.NotImplementedException();
    }
}
