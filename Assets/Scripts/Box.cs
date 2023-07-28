using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] public GameObject box;
    [SerializeField] public GameObject roof;
    int height = 3;
    void Start() 
    {
        transform.position = new Vector3(5.48f, -0.9f, -1.3f);
        addGameObject(box); 
        addGameObject(roof); 
    } 

    void addGameObject(GameObject gameObj) 
    {
        var gameOb = Instantiate(gameObj, new Vector3(),Quaternion.identity);
        gameOb.transform.Rotate(new Vector3(0, 180, 0));
        gameOb.transform.localScale = new Vector3(3.91f, getScaleY(height), 2.4f);
        gameOb.transform.position = new Vector3(5.48f, setPositionY(height), -1.65f);
        gameOb.transform.parent = transform;
    }
    float setPositionY(int height) 
    {
        switch (height)
        {
            case 3: return -1.35f;
            case 6: return -1.63f;
            default: return -1.63f;
        }
    }
    float getScaleY(int height)
    {
        switch (height)
        {
            case 3: return 1.3f;
            case 6: return 2.5f;
            default: return 2.5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
