using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterScreen : MonoBehaviour
{
    [SerializeField] private Camera cam;

    void Start()
    {
        Bounds cameraBounds = new Bounds(cam.transform.position, Vector3.zero);
        transform.position = new Vector3(cameraBounds.center.x, cameraBounds.center.y, transform.position.z-3);
    }
}
