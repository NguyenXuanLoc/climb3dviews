using UnityEngine;

public class ViewDrag : MonoBehaviour
{
    Vector3 offset;
    public string destinationTag = "DropArea";
    [SerializeField]
    public Camera camera;
    int touchCount = 0;
    void Update()
    {
        if (Input.touchCount == 2) touchCount = 2;
        if (Utils.isJoyStick || Utils.isRotate || Input.touchCount == 2 || Utils.isTwoTouch) return;
        if (Input.GetMouseButtonDown(0) || touchCount ==2)
        {
            OnMouseDown(); 
            touchCount = 0;
        } 
        if (Input.GetMouseButton(0))
        {
            OnMouseDrag();
        }
    }

    void OnMouseDown()
    {
        offset = transform.position - MouseWorldPosition();
    }
     
    void OnMouseDrag()
    { 
        if (Utils.isJoyStick || Utils.isRotate) return;
        transform.position = MouseWorldPosition() + offset;
    }

    Vector3 MouseWorldPosition()
    { 
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
}