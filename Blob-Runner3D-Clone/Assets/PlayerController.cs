using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("MOVEMENT...")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float _speed = 5;
    public float RotSpeed;
    public Joystick joy;
    private Vector3 _input;
    public Animator anim;

    [Header("SHOOTING...")]
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    public float BulletSpeed;
    public GameObject ClosestEnemy;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
    }


    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    // Update is called once per frame
    void Update()
    {
        ClosestEnemy = FindClosestEnemy();
        float horizontalInput = joy.Horizontal;
        float verticalInput = joy.Vertical;

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();
        transform.Translate(movementDirection * _speed * Time.deltaTime, Space.World);


        if(ClosestEnemy != null)
        {
            if (Vector3.Distance(transform.position, ClosestEnemy.transform.position) > 5)
            {
                if (movementDirection != Vector3.zero)
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
            else
            {
                if (movementDirection != Vector3.zero)
                {
                    anim.SetBool("Walking", true);

                }
                else
                {
                    anim.SetBool("Walking", false);
                }

                transform.LookAt(ClosestEnemy.transform.position);

            }
        }

        else
        {
            if (movementDirection != Vector3.zero)
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
        

     
    }

    public IEnumerator Shoot()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawn.forward * BulletSpeed;

        yield return new WaitForSeconds(1f);

        StartCoroutine(Shoot());
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
