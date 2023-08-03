using d;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] public GameObject box;
    [SerializeField] public GameObject roof;
    public static long height = 0;
    public static bool isExistBox = false;
    public static bool isDestroy = false;
    public static string routeStr = "";
    public static List<GameObject> lObject = new List<GameObject>();
    void Start()  
    { 
/*        string json = Resources.Load<TextAsset>("data").text;
        RecieveData(json); 
*/    }
    public static void setDestroyView(bool value)
    {
        isDestroy = value;
    }
    public static void setRoute(string value)
    {
        routeStr = value;
    }
    int count = 0;
    private void Update()
    { 
        count++;
        if(!isExistBox && routeStr != "")
        {
            RecieveData(routeStr);
            isExistBox = true; 
        }  
        if (routeStr == "") height = 0;
       // if (isDestroy) DestroyView();
    } 
    public void RecieveData(string data)
    {
        string json = data;
        GridData gridData = Newtonsoft.Json.JsonConvert.DeserializeObject<GridData>(json);
        height = gridData.Data.Height;
        transform.position = new Vector3(5.48f, -0.9f, -1.3f);
        addGameObject(box);
        addGameObject(roof); 
    } 
    private void OnApplicationFocus(bool focus) 
    { 
        print("TAG OnApplicationFocus: " + focus);
    }
    private void OnApplicationPause(bool pause)
    { 
        print("TAG ON PAUSE: "+pause);
    }
    void addGameObject(GameObject gameObj) 
    { 
        var gameOb = Instantiate(gameObj, new Vector3(),Quaternion.identity);
        gameOb.transform.Rotate(new Vector3(0, 180, 0));
        gameOb.transform.localScale = new Vector3(3.91f, getScaleY(height), setScaleX(height));  
        gameOb.transform.position = new Vector3(5.48f, setPositionY(height), setPositionZ(height));
        float positionY = setPositionY(height); 
        Utils.setDefaultPositionYBox(positionY); 
        gameOb.transform.parent = transform;
        lObject.Add(gameOb);
    }
    public static void DestroyView()
    { 
        print("TAG DestroyView BOX");
        height = 0;
        isExistBox = false;
        isDestroy = false;
        routeStr = "";
        foreach (GameObject ob in lObject)
        {
            Destroy(ob);
        }
    }

    float setScaleX(long height) 
    {
        switch (height)
        {
            case 3: return 2.3f;
            case 6: 
            case 9: 
            case 12:
                return 2.4f;
            default: return -1.63f;
        }
    }
    float setPositionZ(long height)
    {
        switch (height)
        {  
            case 3: return -2.3f;     
            case 6: return -2.01f;  
            case 9: return -1.96f;   
            case 12: return -1.96f;   
            default: return -1.63f; 
        }
    }
    float setPositionY(long height) 
    {
        switch (height)
        { 
            case 3: return -0.85f;  
            case 6:
            case 9: return -1.63f;
            case 12: return -1.63f;
            default: return -1.63f;
        }
    } 
    float getScaleY(long height)
    {  
        switch (height)
        {
            case 3: return 1.198f; 
            case 6: return 2.5f;
            case 9: return 3.65f;   
            case 12: return 4.792f;  
            default: return 3.65f; 
        }
    }
 
}
