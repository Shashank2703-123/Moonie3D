using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletScript : MonoBehaviour
{
    public GameObject Explosion;
    public PlayerController player;
    public int Damage = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyObj", 3f);
        player = GameObject.Find("MainCharacter").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DestroyObj()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
       
        if(collision.gameObject.tag == "Enemy")
        {

            Instantiate(Explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);

            if(collision.gameObject.GetComponent<enemyAI>().Hp <= 0)
            {
                player.Exp += 0.3f; 
                collision.gameObject.GetComponent<enemyAI>().Death();
            }
            else
            {
                player.Exp += 0.1f;
                collision.gameObject.GetComponent<enemyAI>().Hp -= Damage;
            }
       
        }
    }
}
