using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Martin Wallmark
public class DamagePlayer : MonoBehaviour
{


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("bombam");
            collision.gameObject.GetComponent<PlayerStats>().HitByZombie();
        }
    }
    //solution 1
    /*
     * Put this script on the Zombies. 
     * Benefits: Every type of zombie can have his own damage.
     * Variables: layer mask = player, player object.
     * Methods: we need to activate script when a zombie collides with the player. The code needed is to take a set amount of health from the player.
     */


    //solution 2
    /* 
     * Put this script on the Players. 
     * Benefits: more effecient.
     * Variables: layer mask.
     * Methods: we need to see which zombie type collider we hit. Then decrease the players health according to it.
     */
}
