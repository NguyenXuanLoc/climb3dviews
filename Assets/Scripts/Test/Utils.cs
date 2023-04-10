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
    public static void setJoyStick(bool value) {
        isJoyStick = value;
    }
    public static void setFocalLenght(float value)
    {
        focalLenght = value;
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
