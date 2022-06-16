using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*@Author Axel Sterner
 * Klass f�r att kontrollera avst�nd mellan spawner och spelarna och hindra zombies fr�n att spawna n�ra spelarna.
 */
public class DistanceCheck : MonoBehaviour
{
    private GameObject player1, player2;
    private ZombieObjectPooled spawner;
    private PlayerSpawnManager pSpawner;
    private float distanceFromSpawner = 50.0f;
    private float dist2;
    private bool playerOneIsSet;
    private bool playerTwoIsSet;
    void Start()
    {
        spawner = gameObject.GetComponentInChildren<ZombieObjectPooled>();
        pSpawner = GameObject.Find("LocalCo-opManager").GetComponent<PlayerSpawnManager>();
    }

    void Update()
    {
        if(pSpawner.playerHasJoined && !playerOneIsSet)
        {
            Debug.Log("wrara");
            player1 = GameObject.FindGameObjectWithTag("Player1");
            playerOneIsSet = true;
        }
        if (pSpawner.player2hasjoined && playerTwoIsSet)
        {
            player2 = GameObject.FindGameObjectWithTag("Player2");
            playerTwoIsSet = true;

        }
        CheckDistFromSpawner();
    }
    private void CheckDistFromSpawner()
    {
        float dist1 = Vector3.Distance(player1.transform.position, transform.position);
        if (dist1 <= distanceFromSpawner)
        {
            spawner.SetAbleToSpawn(false);
        }
        else
        {
            spawner.SetAbleToSpawn(true);
        }

        if (pSpawner.player2hasjoined)
        {
        dist2 = Vector3.Distance(player2.transform.position, transform.position);
            if (dist1 <= distanceFromSpawner || dist2 <= distanceFromSpawner)
            {
                spawner.SetAbleToSpawn(false);
            }
            else
            {
                spawner.SetAbleToSpawn(true);
            }
        }
    }
}
