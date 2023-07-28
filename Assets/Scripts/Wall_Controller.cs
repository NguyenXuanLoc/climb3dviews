using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Controller : MonoBehaviour
{
    [SerializeField] private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target.transform.localScale = new Vector3(10f, 2.5f, 1.88f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
