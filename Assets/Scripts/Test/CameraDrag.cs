using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    public float dragSpeed = 1.2f;
    private Vector3 dragOrigin;
    public bool cameraDragging = true;
   
    public Camera camra;
    public float outerLeft = -10f;
    public float outerRight = 10f;
    public float outerTop = 10f;
    public float outerBottom = 10f;

    void Update()
    {     
        if (Input.touchCount == 2|| Utils.isRotate || camra.focalLength == 50f) return;
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(0) ) return;
        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        Vector3 move = new Vector3(pos.x * dragSpeed, pos.y * dragSpeed, 0);
        camra.transform.Translate(move, Space.World);
        Utils.setX(move.x);
        Utils.setY(move.y);
       // Debug.Log("TAG transform.position.x " + camra.transform.position.x+ " transform.position.Y: " + camra.transform.position.y);
        //transform.position = move;
        return;
    }
    void test()
    {
        if (Input.touchCount == 2)
            return;
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        float left = Screen.width * 0.2f;
        float right = Screen.width - (Screen.width * 0.2f);
        float top = Screen.height * 0.2f;
        float bottom = Screen.height - (Screen.height * 0.2f);

        if (mousePosition.x < left)
        {
            //   Debug.Log("TAG MOVE TO LEFT");
            cameraDragging = true;
        }
        else if (mousePosition.x > right)
        {
            //   Debug.Log("TAG MOVE TO RIGHT");
            cameraDragging = true;
        }
        else if (mousePosition.y < top)
        {
            //     Debug.Log("TAG MOVE TO TOP");
            cameraDragging = true;
        }
        else if (mousePosition.y < bottom)
        {
            //  Debug.Log("TAG MOVE TO BOTTOM");
            cameraDragging = true;
        }
        if (cameraDragging)
        {

            if (Input.GetMouseButtonDown(0))
            {
                dragOrigin = Input.mousePosition;
                return;
            }

            if (!Input.GetMouseButton(0)) return;

            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
            Vector3 move = new Vector3(pos.x * dragSpeed, pos.y * dragSpeed, 0);

            if (move.x > 0f)
            {
                if (this.transform.position.x < outerRight)
                {
                    Debug.Log("TAG MOVE");
                    transform.Translate(move, Space.World);
                }
            }
            else
            {
                if (this.transform.position.x > outerLeft)
                {
                    Debug.Log("TAG MOVE RIGHT");
                    transform.Translate(move, Space.World);
                }
                else
                {
                    Debug.Log("TAG MOVE Y2");
                }
            }
        }
    }


}