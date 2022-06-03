using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour
{
    public Transform[] wayPoints;
    public int speed;
    public GameObject Player;
    public int StartPointIndex;
    private int waypointIndex;
    private float dist;
    public int Hp;
    public int Range;

    public GameObject Splatter,Blood;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("MainCharacter");
        waypointIndex = StartPointIndex;
        transform.LookAt(wayPoints[waypointIndex].position);
    }

    // Update is called once per frame
    void Update()
    {
    //    Debug.LogError(Vector3.Distance(transform.position, Player.transform.position));
        if(Vector3.Distance(transform.position,Player.transform.position) > Range)
        {
            transform.LookAt(wayPoints[waypointIndex].position);
            dist = Vector3.Distance(transform.position, wayPoints[waypointIndex].position);
            if (dist < 1f)
            {
                IncreaseIndex();
            }
            Patrol();
        }
        else if (Vector3.Distance(transform.position, Player.transform.position) < Range)
        {
            MoveToEnemy();
        }

    }

    public void Death()
    {
        Instantiate(Blood,new Vector3(transform.position.x,0f,transform.position.z), Quaternion.identity);
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(Splatter, collision.gameObject.transform.position, collision.gameObject.transform.rotation);

        if(collision.gameObject.tag == "Player")
        {
            
            collision.gameObject.GetComponent<PlayerController>().Health--;
        }

        if(Hp <= 0)
        {

        }
    }
    void Patrol()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    void MoveToEnemy()
    {
        transform.LookAt(Player.transform.position);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void IncreaseIndex()
    {
        waypointIndex++;
        if(waypointIndex >= wayPoints.Length)
        {
            waypointIndex = 0;
        }
        transform.LookAt(wayPoints[waypointIndex].position);
    }
}
