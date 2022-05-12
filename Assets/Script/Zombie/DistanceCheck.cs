using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*@Author Axel Sterner
 * Klass för att kontrollera avstånd mellan spawner och spelarna och hindra zombies från att spawna nära spelarna.
 */
public class DistanceCheck : MonoBehaviour
{
    RaycastHit hit;
    GameObject player1, player2;
    private ZombieObjectPooled spawner;
    private PlayerSpawnManager pSpawner;

    void Start()
    {
        spawner = gameObject.GetComponentInChildren<ZombieObjectPooled>();
        pSpawner = GameObject.Find("LocalCo-opManager").GetComponent<PlayerSpawnManager>();
    }

    void Update()
    {
        if(pSpawner.playerHasJoined)
        {
            player1 = GameObject.FindGameObjectWithTag("Player1");
            player2 = GameObject.FindGameObjectWithTag("Player2");
            CheckDistFromSpawner();
        }
    }

   /* private void RaycastTowardPlayers(GameObject p, GameObject p2)
    {
        Vector3 raycastDir = p.transform.position - transform.position;
        if(Physics.Raycast(transform.position,raycastDir, out hit, 10.0f))
        {
            if (hit.collider.CompareTag("Player1") || hit.collider.CompareTag("Player2"))
            {
                spawner.isAbleToSpawn = false;
            }
        }
        else
        {
            spawner.isAbleToSpawn = true;
        }
    }*/

    private void CheckDistFromSpawner()
    {
        float dist1 = Vector3.Distance(player1.transform.position, transform.position);
        float dist2 = Vector3.Distance(player2.transform.position, transform.position);

        if(dist1 <= 10.0f || dist2 <= 10.0f)
        {
            spawner.SetAbleToSpawnFalse();
            Debug.Log("borde vara false");
        }
        else
        {
            spawner.SetAbleToSpawnTrue();
        }
    }
}
