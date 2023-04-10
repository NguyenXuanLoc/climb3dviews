using UnityEngine;
using System.IO;
using System.Collections.Generic;
using d;
using FlutterUnityIntegration;

public class Grid : MonoBehaviour
{
    [SerializeField] public GameObject cube00;
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

    public List<GameObject> lObject = new List<GameObject>();

    private void Start()
    {
        return;
        string json = Resources.Load<TextAsset>("data").text;
        GridData gridData = Newtonsoft.Json.JsonConvert.DeserializeObject<GridData>(json);
        Hold[][] hold = Newtonsoft.Json.JsonConvert.DeserializeObject<Hold[][]>(gridData.Data.Holds);
        for (int d = 0; d < hold.Length; d++)
        {
            for (int l = 0; l < hold[d].Length; l++)
            {
                Debug.Log("TAG DATA");
                var gameOb = Instantiate(hold[d][l].type == "1"
                         ? cube01
                         : hold[d][l].type == "2"
                             ? cube02
                             : hold[d][l].type == "3"
                                 ? cube01
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
                                                                                                         : cube00,
                         new Vector3(l, d),
                         Quaternion.identity);
                   gameOb.transform 
                    .Rotate(new Vector3(0, 180, hold[d][l].rotation));
                lObject.Add(gameOb);

            }
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
                var gameOb = Instantiate(hold[d][l].type == "1"
                         ? cube01
                         : hold[d][l].type == "2"
                             ? cube02
                             : hold[d][l].type == "3"
                                 ? cube01
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
                                                                                                         : cube00,
                         new Vector3(l, d),
                         Quaternion.identity);
                gameOb.transform
                 .Rotate(new Vector3(0, 180, hold[d][l].rotation));
                lObject.Add(gameOb);
            }
        }
    }
    private void Update()
    {
         
    }
    public void DestroyView(string data)
    {
        Debug.Log("TAG DESTREOY VIEW");
        foreach (GameObject ob in lObject)
        {
            Destroy(ob);
        }
    } 

     
    public void SetInfoRoute(string data)
    { 
        RecieveData(data);
    }
}