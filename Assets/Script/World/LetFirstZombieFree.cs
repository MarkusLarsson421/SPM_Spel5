using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetFirstZombieFree : MonoBehaviour
{
 
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2")
        {
            Destroy(gameObject);
        }
    }
}
