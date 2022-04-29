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
        if(Vector3.Distance(transform.position,Player.transform.position) > 6)
        {
            transform.LookAt(wayPoints[waypointIndex].position);
            dist = Vector3.Distance(transform.position, wayPoints[waypointIndex].position);
            if (dist < 1f)
            {
                IncreaseIndex();
            }
            Patrol();
        }
        else if (Vector3.Distance(transform.position, Player.transform.position) < 6)
        {
            MoveToEnemy();
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
