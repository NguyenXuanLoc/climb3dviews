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
        if (Utils.isJoyStick) return;
        transform.position = MouseWorldPosition() + offset;
        var focalLength = camera.focalLength;
      /*  Debug.Log("Utils.heightOfWall: " + Utils.heightOfWall);
        switch (Utils.heightOfWall)
        {
            case 3:
                limitHorizenta3m(focalLength);
                limitVertica3m(focalLength);
                break;
            case 6: 
                limitHorizental6m(focalLength);
                limitVertical6m(focalLength);
                break;
            case 9:
                limitHorizental9m(focalLength);
                limitVertical9m(focalLength);
                break;
            case 12:
                limitHorizental12m(focalLength);
                limitVertical12m(focalLength);
                break;
        }*/

    }

     
    void limitHorizental12m(float focalLength)
    {
        if (focalLength >= 50 && focalLength < 60)
            checkHorizentalLimit(-5.78f, 15.28f);
        else if (focalLength > 60 && focalLength < 70)
            checkHorizentalLimit(-3.69f, 14.21f);
        else if (focalLength > 70 && focalLength < 80)
            checkHorizentalLimit(-2.52f, 13.34f);
        else if (focalLength > 80 && focalLength < 90)
            checkHorizentalLimit(-2.54f, 13.57f);
        else if (focalLength > 90 && focalLength < 100)
            checkHorizentalLimit(-2.66f, 12.58f);
        else if (focalLength > 100 && focalLength < 110)
            checkHorizentalLimit(-2.34f, 11.82f); 
        else if (focalLength > 110 && focalLength < 120)
            checkHorizentalLimit(-2.45f, 12.61f); 
        else if (focalLength > 120 && focalLength < 130)
            checkHorizentalLimit(-1.95f, 12.64f);
        else if (focalLength > 130 && focalLength < 140)
            checkHorizentalLimit(-1.87f, 12.3f);
        else if (focalLength > 140 && focalLength < 150)
            checkHorizentalLimit(-1.70f, 11.82f);
        else if (focalLength > 150 && focalLength < 170)
            checkHorizentalLimit(-0.185f, 12.04f);



    }

    void limitVertical12m(float focalLength)
    {
        if (focalLength < 60)
            checkVerticalLimit(-50f, 25);
        else if (focalLength > 60 && focalLength < 70)
            checkVerticalLimit(-46.71f, 21.42f);
        else if (focalLength > 70 && focalLength < 80)
            checkVerticalLimit(-47f, 19.54f);
        else if (focalLength > 80 && focalLength < 90)
            checkVerticalLimit(-45.91f, 19.66f);
        else if (focalLength > 90 && focalLength < 100)
            checkVerticalLimit(-45.02f, 19f);
        else if (focalLength > 100 && focalLength < 110)
            checkVerticalLimit(-45.66f, 17.52f); 
        else if (focalLength > 110 && focalLength < 120)
            checkVerticalLimit(-44.84f, 19.02f); 
        else if (focalLength > 120 && focalLength < 130)
            checkVerticalLimit(-45.82f, 17.95f);
        else if (focalLength > 130 && focalLength < 150)
            checkVerticalLimit(-45.36f, 17.95f);
        else if (focalLength > 150)
            checkVerticalLimit(-44.31f, 17.32f);
    }

    void limitHorizental9m(float focalLength)
    {
        if (focalLength >= 50 && focalLength < 60)
            checkHorizentalLimit(-3.2f, 14.7f);
        else if (focalLength > 60 && focalLength < 70)
            checkHorizentalLimit(-2.47f, 12.57f);
        else if (focalLength > 70 && focalLength < 80)
            checkHorizentalLimit(-1.11f, 12.4f);
           else if (focalLength > 80 && focalLength < 90)
              checkHorizentalLimit(-2.59f, 12.72f);
          else if (focalLength > 90 && focalLength < 100)
               checkHorizentalLimit(-1.74f, 11.4f);
           else if (focalLength > 100 && focalLength < 110)
              checkHorizentalLimit(-1.6f, 11.82f);
        else if (focalLength > 110 && focalLength < 120)
              checkHorizentalLimit(-1.53f, 12.02f);
           else if (focalLength > 120 && focalLength < 130)
              checkHorizentalLimit(-1.67f, 11.7f);
        else if (focalLength > 130 && focalLength < 140)
            checkHorizentalLimit(-1.42f, 11.47f);
         else if (focalLength > 140 && focalLength < 150)
             checkHorizentalLimit(-1.48f, 11.32f);
        else if (focalLength > 150 && focalLength < 170)
            checkHorizentalLimit(-0.154f, 11.75f);



    }

    void limitVertical9m(float focalLength)
    {
        if (focalLength < 60)
            checkVerticalLimit(-34.9f, 24);
        else if (focalLength > 60 && focalLength < 70)
            checkVerticalLimit(-30.81f, 23.12f);
           else if (focalLength > 70 && focalLength < 80)
            checkVerticalLimit(-28.7f, 20);
           else if (focalLength > 80 && focalLength < 90)
                   checkVerticalLimit(-29f, 21.12f);
         else if (focalLength > 90 && focalLength < 100)
                 checkVerticalLimit(-31f, 19.6f);
           else if (focalLength > 100 && focalLength < 110)
              checkVerticalLimit(-31.28f, 19.18f);
           else if (focalLength > 110 && focalLength < 120)
              checkVerticalLimit(-30.09f, 18.8f);
           else if (focalLength > 120 && focalLength < 130)
              checkVerticalLimit(-30.59f, 18.73f);
         else if (focalLength > 130 && focalLength < 150)
             checkVerticalLimit(-29.63f, 19.39f);
        else if (focalLength > 150)
            checkVerticalLimit(-29.9f, 18.32f);
    }

    void limitHorizenta3m(float focalLength)
    {
          if (focalLength >= 50 && focalLength < 60)
              checkHorizentalLimit(-4f, 15.4f);
           else if (focalLength > 60 && focalLength < 70)
               checkHorizentalLimit(-1.36f, 12.19f);
          else if (focalLength > 70 && focalLength < 80)
               checkHorizentalLimit(-1.4f, 11.05f);
              else if (focalLength > 80 && focalLength < 90)
                 checkHorizentalLimit(-1.32f, 11.17f);
         else if (focalLength > 90 && focalLength < 100)
                checkHorizentalLimit(-0.58f, 11.15f);
            else if (focalLength > 100 && focalLength < 110)
              checkHorizentalLimit(-0.2f, 11.4f);
           else if (focalLength > 110 && focalLength < 120)
              checkHorizentalLimit(-0.52f, 9.11f);
          else if (focalLength > 120 && focalLength < 130)
              checkHorizentalLimit(-1.16f, 11.54f);
          else if (focalLength > 130 && focalLength < 140)
              checkHorizentalLimit(-0.28f, 10.94f);
      else if (focalLength > 140 && focalLength < 150)
              checkHorizentalLimit(-0.64f, 10.08f);
        else if (focalLength > 150 && focalLength < 170)
            checkHorizentalLimit(-0.295f, 10.6f);



    }
    void limitVertica3m(float focalLength)
    {
           if (focalLength < 60)
               checkVerticalLimit(-3.21f, 21.88f);
           else if (focalLength > 60 && focalLength < 70)
               checkVerticalLimit(-0.95f, 17.8f);
       else if (focalLength > 70 && focalLength < 80)
              checkVerticalLimit(-2.85f, 21.26f);
            else if (focalLength > 80 && focalLength < 90)
             checkVerticalLimit(-0.87f, 19.78f);
          else if (focalLength > 90 && focalLength < 100)
              checkVerticalLimit(-0.579f, 19.43f);
          else if (focalLength > 100 && focalLength < 110)
               checkVerticalLimit(-0.54f, 18.9f);
             else if (focalLength > 110 && focalLength < 120)
                checkVerticalLimit(-0.86f, 19.5f);
            else if (focalLength > 120 && focalLength < 130)
                checkVerticalLimit(-0.15f, 18.94f);
           else if (focalLength > 130 && focalLength < 150)
               checkVerticalLimit(-0.05f, 17.59f);
    else if (focalLength > 150)
            checkVerticalLimit(-0.05f, 17.59f);
    }

    void limitVertical6m(float focalLength)
    {
        if (focalLength < 60)
            checkVerticalLimit(-14f, 20);
        else if (focalLength > 60 && focalLength < 70)
            checkVerticalLimit(-11f, 16);
        else if (focalLength > 70 && focalLength < 80)
            checkVerticalLimit(-10f, 15);
        else if (focalLength > 80 && focalLength < 90)
            checkVerticalLimit(-10f, 14);
        else if (focalLength > 90 && focalLength < 100)
            checkVerticalLimit(-11f, 13);
        else if (focalLength > 100 && focalLength < 110)
            checkVerticalLimit(-12f, 15);
        else if (focalLength > 110 && focalLength < 120) 
            checkVerticalLimit(-12f, 16); 
        else if (focalLength > 120 && focalLength < 130) 
            checkVerticalLimit(-12f, 15);
        else if (focalLength > 130 && focalLength < 150)
            checkVerticalLimit(-13.9f, 17.59f);
        else if (focalLength > 150) 
            checkVerticalLimit(-11f, 16f);
    }
    void limitHorizental6m(float focalLength)
    {
         if (focalLength >= 50 && focalLength < 60)
            checkHorizentalLimit(-2.8f, 15.7f);
        else if (focalLength > 60 && focalLength < 70)
            checkHorizentalLimit(-1.58f, 12.2f);
        else if (focalLength > 70 && focalLength < 80)
            checkHorizentalLimit(0.14f, 11);
        else if (focalLength > 80 && focalLength < 90)
            checkHorizentalLimit(0.14f, 11);
        else if (focalLength > 90 && focalLength < 100)
            checkHorizentalLimit(0.14f, 11);
        else if (focalLength > 100 && focalLength < 110)
            checkHorizentalLimit(-0.8f, 11.23f);
        else if (focalLength > 110 && focalLength < 120)
            checkHorizentalLimit(-0.63f, 11.34f);
        else if (focalLength > 120 && focalLength < 130)
            checkHorizentalLimit(-0.54f, 11.24f);
        else if (focalLength > 130 && focalLength < 140)
            checkHorizentalLimit(-0.28f, 10.94f);
        else if (focalLength > 140 && focalLength < 150)
            checkHorizentalLimit(-0.28f, 10.94f);
        else if (focalLength > 150 && focalLength < 170)
            checkHorizentalLimit(-0.14f, 11.18f);



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
    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
}