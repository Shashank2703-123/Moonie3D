using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyObj", 3f);
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
            Destroy(gameObject);

            if(collision.gameObject.GetComponent<enemyAI>().Hp <= 0)
            {
                Destroy(collision.gameObject);
            }
            else
            {
                collision.gameObject.GetComponent<enemyAI>().Hp--;
            }
       
        }
    }
}
