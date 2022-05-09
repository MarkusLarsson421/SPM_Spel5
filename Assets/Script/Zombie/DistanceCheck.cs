using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*@Author Axel Sterner
 * Klass f�r att kontrollera avst�nd mellan spawner och spelarna och hindra zombies fr�n att spawna n�ra spelarna.
 */
public class DistanceCheck : MonoBehaviour
{
    RaycastHit hit;
    GameObject player;
    private ZombieObjectPooled spawner;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spawner = gameObject.GetComponent<ZombieObjectPooled>();
    }

    void Update()
    {
        RaycastTowardPlayers(player);
    }

    private void RaycastTowardPlayers(GameObject p)
    {
        Vector3 raycastDir = p.transform.position - transform.position;
        if(Physics.Raycast(transform.position,raycastDir, out hit, 10.0f))
        {
            if (hit.collider.CompareTag("Player"))
            {
                spawner.isAbleToSpawn = false;
            }
        }
        else
        {
            spawner.isAbleToSpawn = true;
        }
    }
}
