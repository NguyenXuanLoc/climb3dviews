using UnityEngine;
using System.Collections.Generic;
using d;
using System.Threading.Tasks;
using System;
using UnityEngine.SceneManagement;

public class Grid : MonoBehaviour 
{
    [SerializeField] public List<GameObject> lHoldSet;
    [SerializeField] public Camera camera;
    [SerializeField] public GameObject wallObject;
     
    public List<GameObject> lObject = new List<GameObject>();
    float currentRotationAroundYAxis; 
    long height = 0;
    float positionY = 0;
    Vector3 refreshScale = new Vector3(0, 0, 0);
    private void Start()
    {
        Utils.setFieldOfView(camera.fieldOfView);
        return;
        string json = Resources.Load<TextAsset>("data").text;
        RecieveData(json);      
    }

    public void RecieveData(string data)
    { 
        Box.setRoute(data); 
        string json = data;  
        GridData gridData = Newtonsoft.Json.JsonConvert.DeserializeObject<GridData>(json); 
        Utils.setHeightOfWall(int.Parse(gridData.Data.Height.ToString()));
        setFocusPosition(int.Parse(gridData.Data.Height.ToString()));
        Hold[][] hold = Newtonsoft.Json.JsonConvert.DeserializeObject<Hold[][]>(gridData.Data.Holds);

        for (int d = 0; d < hold.Length; d++)
        {
            for (int l = 0; l < hold[d].Length; l++)
            {
                //ADD BACKDROUND 
                var backgroundOb = Instantiate(lHoldSet[0],new Vector3(l, d), Quaternion.identity);
                backgroundOb.transform.Rotate(new Vector3(0, 180, getRotation(hold[d][l].rotation)));
                backgroundOb.transform.parent = transform;
                lObject.Add(backgroundOb);

                //ADD HOLD SET
                if (hold[d][l].type != "Empty")
                { 
                    var gameOb = Instantiate(getHoldById(hold[d][l].type),
                             new Vector3(l, d), Quaternion.identity);
                    gameOb.transform.Rotate(new Vector3(0, 180, getRotation(hold[d][l].rotation))); 
                    gameOb.transform.position = new Vector3(gameOb.transform.position.x,gameOb.transform.position.y, -0.1f);
                    gameOb.transform.parent = transform;
                    lObject.Add(gameOb);
                }
            }
        }
        height = gridData.Data.Height;
        transform.Rotate(new Vector3(1, 0, 0), setRotateX(gridData.Data.Height));
        camera.transform.position = setPositionCamera(gridData.Data.Height); 
        Utils.setDefaultPositionCamera(setPositionCamera(gridData.Data.Height));
    }
    private float getRotation(int rotation)
    {  
        return rotation; 
        if(rotation!=0)
        switch (rotation)
        { 
            case 0: return 0;
            case 1: 
            case -1: 
                return -90;
            case 2:
            case -2: return 180; 
            case 3:  
            case -3: return 270;
            default: return 0;
        }
    }

    private GameObject getHoldById(string id)
    {
        if (id.Length == 1) id = "0"+id;
        for (int i = 0; i < lHoldSet.Count; i++)
        {
            if (id.Equals("Empty"))
            {
                return lHoldSet[0];
            }
            if (lHoldSet[i].gameObject.name==(id).ToString()) 
            {    
                try 
                {
                    return lHoldSet[i];
                } 
                catch(Exception e) 
                {

                }
              
            }
        }
        return lHoldSet[0];
    }
    private Vector3 setPositionCamera(long height)
    {
        bool isAndroid = (Application.platform == RuntimePlatform.Android);
        switch (height) 
        {  
            case 1: return new Vector3(Utils.x, 28, -50); 
            case 2: return new Vector3(Utils.x, 28, -50); 
            case 3: return new Vector3(Utils.x, 28, -50); 
            case 4: return new Vector3(Utils.x, 28, -50); 
            case 5: return new Vector3(Utils.x, 28, -50); 
            case 6: return new Vector3(Utils.x, isAndroid ?30 :27, -50);
            case 7: return new Vector3(Utils.x, isAndroid ?30 :27, -50);
            case 8: return new Vector3(Utils.x, isAndroid ?30 :27, -50);
            case 9: return new Vector3(5, isAndroid ? 30 : 27, -50);    
            case 10: return new Vector3(5, isAndroid ? 30 : 27, -50);    
            case 11: return new Vector3(5, isAndroid ? 30 : 27, -50);    
            case 12: return new Vector3(5, isAndroid ? 35 :32, -55);     
            default: return new Vector3(Utils.x, Utils.y, -30); 
        } 
    }
     
    private float setRotateX(long height)
    {
        switch (height)
        {
            case 1: return -17f;   
            case 2: return -9.5f;    
            case 3: return -4.2f;
            case 4: return -4.2f;   
            case 5: return -4.2f;   
            case 6: return -4f;   
            case 7: return -4f;   
            case 8: return -3.1f;   
            case 9: return -1.8f; 
            case 10: return -1.8f;
            case 11: return -1.8f; 
            case 12: return -1.9f; 
            default: return -2f;

        } 
    }                


    private void Update() 
    { 


        if (Utils.isResetGrid) refreshUI();     
         if(Utils.rotationAroundYAxis != 0 && currentRotationAroundYAxis!=Utils.rotationAroundYAxis && Input.touchCount == 2)
        { 
            currentRotationAroundYAxis = Utils.rotationAroundYAxis;
        }
         if(refreshScale.x ==0)
         refreshScale = wallObject.transform.localScale;
    }


    void refreshUI()
    {
        camera.fieldOfView = Utils.fieldOfView;
        Utils.setRorationAroundXY(0,0);  
        Vector3 move = new Vector3(Utils.x,Utils.y, Utils.z);
        camera.transform.position = move;  
        Vector3 moveGrid = new Vector3(5.63f,getDefaultPositionBox(height), 0);
        wallObject.transform.position = moveGrid;
        wallObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
        wallObject.transform.localScale = refreshScale;
        refreshScale = new Vector3(0, 0, 0);
    }

    float getDefaultPositionBox(long height)
    {
        switch (height)
        {
            case 1: return 2;
            case 2: return 4;
            case 3: return 6;
            case 4: return 8;
            case 5: return 10;
            case 6: return 12;
            case 7: return 14;
            case 8: return 16;
            case 9: return 18;
            case 10: return 20;
            case 11: return 22;
            case 12: return 24; 
            default: return 18;
        }
    }

    void setFocusPosition(int height) 
    {
        float value = 0;
        switch (height)
        { 
            case 1:
                value = 2.1f;
                break;
            case 2:
            case 3:
            case 4:
            case 5:
                value = 2;
                break;      
            case 6:
            case 7: 
            case 8:
                value = 14; break;
            case 9:
            case 10:
            case 11:
                value = 21;
                break;
            case 12: 
                value = 28;
                break; 
        }
        positionY = value;
       gameObject.transform.position = new Vector3(5, value, 0);
    }

    public void DestroyView(string data)
    {  
        Box.DestroyView(); 
        Debug.Log("TAG DESTREOY VIEW");
        refreshUI();  
        foreach (GameObject ob in lObject)
        {
            Destroy(ob);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void GetFileCache(string data)
    {
        ThreeDFile[] lFile = Newtonsoft.Json.JsonConvert.DeserializeObject<ThreeDFile[]>(data);
        for (int i = 0; i < lFile.Length; i++)
        {
         //   loadGameObjectByPath1(lFile[i]);
        }
    //    Debug.Log("TAG mCacheObject.Count: " + mCacheObject.Count);
    }

/*    public void loadGameObjectByPath(ThreeDFile model)
    {

        if (File.Exists(model.filePath))
        {
            var path = new Uri("file:///C:/whatever.txt");

            Debug.Log("TAG FILE EXISTS, Start convert TO MODEL: " + model.filePath);
            try
            {
                string fullPath = Path.Combine(Application.temporaryCachePath, "as");
                Debug.Log("TAG PATH TEST: " + fullPath);
                string fileContents = File.ReadAllText(model.filePath);
                GameObject loadedObject = Resources.Load<GameObject>(fileContents);


                var gameObject = new OBJLoader().Load(model.filePath);
                if (gameObject != null)
                    Debug.Log("TAG GAME OBJECT != NULL => SUCCEESS");
                else Debug.Log("TAG GAME OBJECT NULL");
              //  mCacheObject.Add(model.id.ToString(), gameObject);
            }
            catch (Exception e)
            {
                Debug.Log("TAG EXCEPTION: %%: " + e.Message);
            }
        }
        else
        {
            Debug.LogError("File not found: " + model.filePath);
        }
    }
*/
    public void SetInfoRoute(string data)
    {
        RecieveData(data);
    }

}

