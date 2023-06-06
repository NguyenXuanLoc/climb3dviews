using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils {
   public static  float minFocalLenght = 50f;
   public static bool isRotate = false;
   public static float x = 5f;
   public static float y = 15f;
   public static bool isJoyStick = false;
   public static float focalLenght = 50f;
   public static float rotationAroundYAxis = 0f;
   public static float fieldOfView = 0f;
   public static bool isResetGrid = false;
   public static bool isTwoTouch;
   public static int heightOfWall = 0;
    

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

    public static void setRorationAroundY(float y)
    {
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
