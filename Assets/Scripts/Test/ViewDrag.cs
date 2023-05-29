using UnityEngine;

public class ViewDrag : MonoBehaviour
{
    Vector3 offset;
    public string destinationTag = "DropArea";
    [SerializeField]
    public Camera camera;
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
    }

    void OnMouseDrag()
    {
        transform.position = MouseWorldPosition() + offset;
        var focalLength = camera.focalLength;
        limitHorizental(focalLength);
        limitVertical(focalLength);
    }

    void limitVertical(float focalLength)
    {
        if (focalLength < 60)
            checkVerticalLimit(-26f, 29);
        else if (focalLength > 60 && focalLength < 70)
            checkVerticalLimit(-24f, 27);
        else if (focalLength > 70 && focalLength < 80)
            checkVerticalLimit(-21f, 25);
        else if (focalLength > 80 && focalLength < 90)
            checkVerticalLimit(-20f, 23);
        else if (focalLength > 90 && focalLength < 100)
            checkVerticalLimit(-18f, 22);
        else if (focalLength > 100 && focalLength < 110)
            checkVerticalLimit(-17f, 21);
        else if (focalLength > 110 && focalLength < 120)
            checkVerticalLimit(-16f, 20);
        else if (focalLength > 120 && focalLength < 130)
            checkVerticalLimit(-15f, 19);
        else if (focalLength > 130 && focalLength < 150)
            checkVerticalLimit(-15.3f, 19.3f);
        else if (focalLength > 150)
            checkVerticalLimit(-15.3f, 19.3f);
    }

    void checkVerticalLimit(float min, float max)
    {
        if (transform.position.y <= min)
            setLimitVertical(min);
        else if (transform.position.y >= max)
            setLimitVertical(max);
    }
    void checkHorizentalLimit(float min, float max)
    {
        if (transform.position.x <= min)
            setLimitHorizental(min);
        else if (transform.position.x >= max)
            setLimitHorizental(max);

    }

    void limitHorizental(float focalLength)
    {
        if (focalLength < 70)
            checkHorizentalLimit(-7, 17);
        else if (focalLength > 70 && focalLength < 90)
            checkHorizentalLimit(-4, 14);
        else if (focalLength > 90 && focalLength < 110)
            checkHorizentalLimit(-3.6f, 14);
        else if (focalLength > 110 && focalLength < 130)
            checkHorizentalLimit(-2.56f, 12.99f);
        else if (focalLength > 130 && focalLength < 150)
            checkHorizentalLimit(-1.87f, 12.19f);
        else if (focalLength > 150 && focalLength < 170)
            checkHorizentalLimit(-1.35f, 11.7f);



    }

    void setLimitHorizental(float value)
    {
        transform.position = new Vector3(value, transform.position.y, transform.position.z);
    }
    void setLimitVertical(float value)
    {
        transform.position = new Vector3(transform.position.x, value, transform.position.z);
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
    }

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
}