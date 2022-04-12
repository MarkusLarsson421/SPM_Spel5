using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{


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
