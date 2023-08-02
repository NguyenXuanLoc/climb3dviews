using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils {
   public static  float minFocalLenght = 50f;
   public static bool isRotate = false;
   public static float x = 5f;
   public static float y = 15f;
   public static float z = -30f;
   public static bool isJoyStick = false;
   public static float focalLenght = 50f;
   public static float rotationAroundYAxis = 0f;
   public static float rotationAroundXAxis = 0;
    public static float positionYBox = 0f;
    public static float fieldOfView = 0f;
   public static bool isResetGrid = false;
   public static bool isTwoTouch;
   public static int heightOfWall = 0;

 


    public static void setDefaultPositionYBox(float y)
    { 
        positionYBox = y; 
    }
    
    public static void setDefaultPositionCamera(Vector3 vector3)
    {
        x = vector3.x;
        y = vector3.y;
        z = vector3.z;
    }
    
    public static void setLimitCamera(long height)
    {
        switch (height)
        {
            case 3:
                y = 22f;
                z = -40f;
                return;
            case 6: 
                y = 30f;
                z = -45f;
                return;
            case 9:
                y = 30f;
                z = -50f;
                return;
            case 12:
                y = 35f;
                z = -55f;
                return;
        }
    }
/*       case 3: return new Vector3(Utils.x, Utils.y, -30);
            case 6: return new Vector3(Utils.x,30, -45);
            case 9: return new Vector3(5, 30, -50);   
            case 12: return new Vector3(5, 35, -55);     
            default: return new Vector3(Utils.x, Utils.y, -30);*/
    public static void setHeightOfWall(int value)
    {
        heightOfWall = value;
    }

    public static void setTwoTouch(bool value)
    {
        isTwoTouch = value;
    }

    public static void setFieldOfView(float value) //rollback to start position when open 3d view
    {
       fieldOfView = value;
    }

    public static void setRorationAroundXY(float x,float y)
    {
        rotationAroundXAxis = x;
        rotationAroundYAxis = y;
    }

    public static void setJoyStick(bool value) {
        isJoyStick = value;
    }
    public static void setFocalLenght(float value)
    {
        focalLenght = value;
    }

    public static void setRefreshUi(bool value)
    {
        isResetGrid = value;
    }

    public static void setRotate(bool value)
    {
        isRotate = value;
    }
    public static void setX(float value)
    {
        x = value;
    }
    public static void setY(float value)
    {
        y = value;
    }
}
