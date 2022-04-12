using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("bombam 1");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("bombam");
            collision.gameObject.GetComponent<PlayerStats>().HitByZombie();
        }
    }
}
