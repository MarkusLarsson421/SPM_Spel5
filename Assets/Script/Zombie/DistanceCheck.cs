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
    private float distaneFromSpawner = 50.0f;
    private bool isPlayerOneSet;
    private bool isPlayerTwoSet;

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
    private void CheckDistFromSpawner()
    {
        float dist1 = Vector3.Distance(player1.transform.position, transform.position);
        float dist2 = Vector3.Distance(player2.transform.position, transform.position);

        if(dist1 <= distaneFromSpawner || dist2 <= distaneFromSpawner)
        {
            gameObject.transform.Find("GameObject").gameObject.SetActive(false);
           
        }
        else
        {
            gameObject.transform.Find("GameObject").gameObject.SetActive(true);
        }
    }
}
