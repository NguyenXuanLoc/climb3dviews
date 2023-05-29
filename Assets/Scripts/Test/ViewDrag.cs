using UnityEngine;

public class ViewDrag : MonoBehaviour
{
    Vector3 offset;
    public string destinationTag = "DropArea";

    void Update()
    {
        if (Utils.isJoyStick || Utils.isRotate || Input.touchCount == 2 || Utils.isTwoTouch) return;
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseDown();

        }
        if (Input.GetMouseButton(0))
        {
            OnMouseDrag();
        }
    }

    void OnMouseDown()
    {
        offset = transform.position - MouseWorldPosition();
        /*  transform.GetComponent<Collider>().enabled = false;*/
    }

    void OnMouseDrag()
    {
        transform.position = MouseWorldPosition() + offset;
    }

    void OnMouseUp()
    {
        var rayOrigin = Camera.main.transform.position;
        var rayDirection = MouseWorldPosition() - Camera.main.transform.position;
        RaycastHit hitInfo;
        if (Physics.Raycast(rayOrigin, rayDirection, out hitInfo))
        {
            if (hitInfo.transform.tag == destinationTag)
            {
                transform.position = hitInfo.transform.position;
            }
        }
        //  transform.GetComponent<Collider>().enabled = true;
    }

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
}