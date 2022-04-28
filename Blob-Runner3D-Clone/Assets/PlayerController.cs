using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Rigidbody rb;
    [SerializeField] private float _speed = 5;

    public float RotSpeed;

    public Joystick joy;
    private Vector3 _input;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = joy.Horizontal;
        float verticalInput = joy.Vertical;

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();
        transform.Translate(movementDirection * _speed * Time.deltaTime, Space.World);

        if(movementDirection != Vector3.zero)
        {
            anim.SetBool("Walking", true);
            Quaternion toRot = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRot, RotSpeed * Time.deltaTime);
        }
        else
        {
            anim.SetBool("Walking", false);
        }
    }

    private void FixedUpdate()
    {
        
    }

    void Look()
    {
      

     
    }

    public void GatherInput()
    {

    }

    private void move()
    {
     
     
    }
}
