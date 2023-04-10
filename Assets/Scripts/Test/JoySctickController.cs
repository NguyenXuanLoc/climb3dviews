using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoySctickController : MonoBehaviour
{
    [SerializeField]
    public FixedJoystick joyStick;
    [SerializeField]
    public Camera camera;
    [SerializeField] private Transform target;
    private Vector3 _moveVector;
    [SerializeField]
    public float moveSpeed =20f;
    [SerializeField] private float distanceToTarget = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotate();
    }
    void rotate()
    {       
        if (joyStick.Horizontal == 0) 
        {
            Utils.setJoyStick(false);
            return;
        }
        Vector3 direction = Vector3.zero;
        direction.x = joyStick.Horizontal * moveSpeed * Time.deltaTime;
        direction.y = joyStick.Vertical * moveSpeed * Time.deltaTime;
        float rotationAroundYAxis = -direction.x * 180; // camera moves horizontally
        float rotationAroundXAxis = direction.y * 180; // camera moves vertically
        Utils.setRorationAroundY(rotationAroundYAxis);
        Utils.setJoyStick(true);
    }

    void move()
    { 
        _moveVector = Vector3.zero;
        _moveVector.x = joyStick.Horizontal * moveSpeed * Time.deltaTime;
        _moveVector.y = joyStick.Vertical * moveSpeed * Time.deltaTime;
        Utils.setJoyStick(joyStick.Vertical != 0 || joyStick.Horizontal != 0);
        if(joyStick.Horizontal !=0 || joyStick.Vertical != 0)
        {
            camera.transform.Translate(_moveVector, Space.World);
            Utils.setX(camera.transform.position.x);
            Utils.setY(camera.transform.position.y);
        }
    }
}
