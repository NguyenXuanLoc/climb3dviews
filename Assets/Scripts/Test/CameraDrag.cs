using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    public float dragSpeed = 1.1f;
    private Vector3 dragOrigin;  
    public Camera camra;
    [SerializeField]
    public Transform target;
    bool isDrag = false;
    void Update()
    {
        if (camra.focalLength >= 137) dragSpeed = 0.8f;
        else dragSpeed = 1f; 
        if (Input.touchCount == 2|| Utils.isRotate || Utils.isJoyStick) return;
        if (Input.GetMouseButtonDown(0))
        {
            isDrag = true;
            dragOrigin = Input.mousePosition;
        }
        if (!Input.GetMouseButton(0)) return;
        Vector3 pos = Camera.main.ScreenToViewportPoint(dragOrigin -Input.mousePosition);
        Vector3 move = new Vector3(pos.x * dragSpeed, pos.y * dragSpeed, 0);
        target.Translate(move, Space.Self);
        Utils.setX(move.x);
        Utils.setY(move.y);
        isDrag = false;
   
    }
}