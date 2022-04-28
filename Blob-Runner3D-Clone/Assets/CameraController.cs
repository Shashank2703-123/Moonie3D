using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float panSpeed = 20f;
    public Joystick joy;
    public Transform player;
    public Vector3 offset;

  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 pos = transform.position;

        //Vector3 playerpos = player.position;
   

        //if (joy.Horizontal > 0)
        //{
        //    pos.x += panSpeed * Time.deltaTime;
        //}

        //if(joy.Horizontal < 0)
        //{
        //    pos.x -= panSpeed * Time.deltaTime;
        //}

        //if(joy.Vertical > 0)
        //{
        //    pos.z += panSpeed * Time.deltaTime;
        //}

        //if(joy.Vertical < 0)
        //{
        //    pos.z -= panSpeed * Time.deltaTime;
        //}

        transform.position = player.position + offset;
    }
}
