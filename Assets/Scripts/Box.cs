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
            case 1: return 2.3f;
            case 2: return 2.3f;
            case 3: return 2.3f;
            case 4: return 2.3f;
            case 5: return 2.3f;
            case 6:  
            case 7:  
            case 8:  
            case 9: 
            case 10: 
            case 11: 
            case 12:
                return 2.4f;
            default: return -1.63f;
        }
    }
    float setPositionZ(long height)
    {
        switch (height)
        {  
            case 1: return -2f;     
            case 2: return -2.1f;     
            case 3: return -2.3f;     
            case 4: return -2.3f;     
            case 5: return -2.3f;     
            case 6: return -2.01f;  
            case 7: return -2.01f;  
            case 8: return -2.01f;  
            case 9: return -1.96f;   
            case 10: return -1.96f;   
            case 11: return -1.96f;   
            case 12: return -1.96f;   
            default: return -1.63f; 
        }
    }
    float setPositionY(long height) 
    {
        switch (height)
        {  
            case 1: return -0.7f;  
            case 2: return -0.85f;   
            case 3: return -0.85f;  
            case 4: return -0.85f;  
            case 5: return -0.85f;  
            case 6: return -0.85f;  
            case 7: return -0.85f;  
            case 8: return -0.85f;  
            case 9: return -1.63f;
            case 10: return -1.63f;
            case 11: return -1.63f;
            case 12: return -1.63f;
            default: return -1.63f;
        }
    } 
    float getScaleY(long height)                                
    {  
        switch (height)                    
        {  
            case 1: return 0.41f; 
            case 2: return 0.68f;   
            case 3: return 1f; 
            case 4: return 1.33f; 
            case 5: return 1.66f; 
            case 6: return 1.99f; 
            case 7: return 2.32f;
            case 8: return 2.65f;
            case 9: return 2.98f;     
            case 10: return 3.31f;     
            case 11: return 3.64f;      
            case 12: return 3.97f;  
            default: return 3.65f; 
        }
    }
 
}
