using UnityEngine;
using System.IO;
using System.Collections.Generic;
using d;
using Dummiesman;
using System;

public class Grid : MonoBehaviour
{
    [SerializeField] public GameObject cube01;
    [SerializeField] public GameObject cube02;
    [SerializeField] public GameObject cube03;
    [SerializeField] public GameObject cube04;
    [SerializeField] public GameObject cube05;
    [SerializeField] public GameObject cube06;
    [SerializeField] public GameObject cube07;
    [SerializeField] public GameObject cube08;
    [SerializeField] public GameObject cube09;
    [SerializeField] public GameObject cube10;
    [SerializeField] public GameObject cube11;
    [SerializeField] public GameObject cube12;
    [SerializeField] public GameObject cube13;
    [SerializeField] public GameObject cube14;
    [SerializeField] public GameObject cube15;
    [SerializeField] public GameObject cube16;
    [SerializeField] public GameObject cube17;
    [SerializeField] public GameObject cube18;
    [SerializeField] public GameObject cube19;
    [SerializeField] public GameObject cube20;
    [SerializeField] public GameObject cube21;
    [SerializeField] public GameObject cube22;
    [SerializeField] public Camera camera;

    public List<GameObject> lObject = new List<GameObject>();
    public Dictionary<String, GameObject> mCacheObject = new Dictionary<string, GameObject>();
    private void Start()
    {
        // convertStringToObj("C:/Users/Admin/Desktop/7540ff60-dffc-11ed-ae64-7786bddc551f.dabab");
        return;
        string json = Resources.Load<TextAsset>("data").text;
        RecieveData(json);

    }
    void convertStringToObj(String threeDModel)
    {
        //  string path = Application.persistentDataPath + "/model.dabab";
        //  string path = threeDModel.filePath;
          string path = threeDModel; 
        Debug.Log("OPEN FILE" + path);
        if (File.Exists(path))
        { 
         GameObject model = OpenMesh.StrToModel(File.ReadAllText(path), "mo|");
            SendMessage("READ_FILE", File.ReadAllBytes(path)); 
         Debug.Log("TAG File.ReadAllText(path): " + File.ReadAllText(path));
            var gameObject = Instantiate(model);
            gameObject.transform
                .Rotate(new Vector3(0, 180, 0));
  /*          gameObject.transform.position = new Vector3(5, 15, -20);
            gameObject.transform.localScale =new Vector3(10,10,10);*/
            //  Destroy(model);  
            mCacheObject.Add("0", gameObject);
            gameObject.SetActive(true);
            Debug.Log("TAG CONVERT SUCCESS: SHOW UI");
        }
        else
        {
            Debug.Log("TAG file is EMPTY");
        }
    }
    public void RecieveData(string data)
    {
        string json = data;
        GridData gridData = Newtonsoft.Json.JsonConvert.DeserializeObject<GridData>(json);
        Hold[][] hold = Newtonsoft.Json.JsonConvert.DeserializeObject<Hold[][]>(gridData.Data.Holds);
        for (int d = 0; d < hold.Length; d++)
        { 
            for (int l = 0; l < hold[d].Length; l++)
            {
                var gameOb = Instantiate(hold[d][l].type == "Empty" ? cube01 : mCacheObject["0"/*hold[d][l].type*/], new Vector3(l, d),
                         Quaternion.identity);
             /*   var gameOb = Instantiate(hold[d][l].type == "1"
                         ? cube01
                         : hold[d][l].type == "2"
                             ? cube02
                             : hold[d][l].type == "3"
                                 ? cube03
                                 : hold[d][l].type == "4"
                                     ? cube04
                                     : hold[d][l].type == "5"
                                         ? cube05
                                         : hold[d][l].type == "6"
                                             ? cube06
                                             : hold[d][l].type == "7"
                                                 ? cube07
                                                 : hold[d][l].type == "8"
                                                     ? cube08
                                                     : hold[d][l].type == "9"
                                                         ? cube09
                                                         : hold[d][l].type == "10"
                                                             ? cube10
                                                             : hold[d][l].type == "11"
                                                                 ? cube11
                                                                 : hold[d][l].type == "12"
                                                                     ? cube12
                                                                     : hold[d][l].type == "13"
                                                                         ? cube13
                                                                         : hold[d][l].type == "14"
                                                                             ? cube14
                                                                             : hold[d][l].type == "15"
                                                                                 ? cube15
                                                                                 : hold[d][l].type == "16"
                                                                                     ? cube16
                                                                                     : hold[d][l].type == "17"
                                                                                         ? cube17
                                                                                         : hold[d][l].type == "18"
                                                                                             ? cube18
                                                                                             : hold[d][l].type == "19"
                                                                                                 ? cube19
                                                                                                 : hold[d][l].type == "20"
                                                                                                     ? cube20
                                                                                                     : hold[d][l].type == "21"
                                                                                                          ? cube21
                                                                                                        : hold[d][l].type == "22"
                                                                                                          ? cube22
                                                                                                         : cube01,
                         new Vector3(l, d),
                         Quaternion.identity);
             */   gameOb.transform
                 .Rotate(new Vector3(0, 180, hold[d][l].rotation));
                gameOb.transform.parent = transform;
                lObject.Add(gameOb);
            }
        }
    }
    private void Update()
    {
        if (Utils.rotationAroundYAxis != 0 && Utils.isJoyStick)
            transform.Rotate(new Vector3(0, 1, 0), Utils.rotationAroundYAxis, Space.World);
    }
    public void DestroyView(string data)
    {
        Debug.Log("TAG DESTREOY VIEW");
        foreach (GameObject ob in lObject)
        {
            Destroy(ob);
        }
    }


    public void GetFileCache(string data)
    {
        ThreeDFile[] lFile = Newtonsoft.Json.JsonConvert.DeserializeObject<ThreeDFile[]>(data);
        for (int i = 0; i < lFile.Length; i++)
        {
          //  convertStringToObj(lFile[0]);
            //   loadGameObjectByPath1(lFile[i]);
        } 
        convertStringToObj(lFile[0].filePath);
        // convertStringToObj(lFile[0]);
        //     Debug.Log("TAG mCacheObject.Count: " + mCacheObject.Count);
    }
    public void SetInfoRoute(string data)
    {
        RecieveData(data);
    }
}

