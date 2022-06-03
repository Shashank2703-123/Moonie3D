using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyObjc", 4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyObjc()
    {
        Destroy(gameObject);
    }
}
