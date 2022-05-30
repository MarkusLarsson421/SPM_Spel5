using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*@Author Axel Sterner
 * Klass för att kontrollera avstånd mellan spawner och spelarna och hindra zombies från att spawna nära spelarna.
 */
public class DistanceCheck : MonoBehaviour
{
    GameObject player1, player2;
    private ZombieObjectPooled spawner;
    private PlayerSpawnManager pSpawner;
    private float distanceFromSpawner = 50.0f;
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
            Debug.DrawLine(transform.position, player1.transform.position);
        }
    }
    private void CheckDistFromSpawner()
    {
        float dist1 = Vector3.Distance(player1.transform.position, transform.position);
        float dist2 = Vector3.Distance(player2.transform.position, transform.position);

        if(dist1 <= distanceFromSpawner || dist2 <= distanceFromSpawner)
        {
            spawner.SetAbleToSpawn(false);
        }
        else
        {
            spawner.SetAbleToSpawn(true);
        }
    }
}
