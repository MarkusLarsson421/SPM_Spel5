using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Martin Wallmark
public class ZombieSpawnPoint : MonoBehaviour
{
    public Transform target;
    [SerializeField] private float minimunDistanceToPlayer;
    [SerializeField] private GameObject zombie;
    [SerializeField] private int maxAmountAtSpawnPoint;
    private int randomAmountOfZombies;
    private GameObject player1;

    private GameObject player2;

    private float timer;

    private bool canSpawn;
    private bool targetIsSet;

    private void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
    }

    private void Update()
    {
        if (!targetIsSet)
        {

            timer += Time.deltaTime;

            if (timer >= 20)
            {
                //player = GameObject.FindGameObjectWithTag("Player1");
                player1 = GameObject.FindGameObjectWithTag("Player1");
                player2 = GameObject.FindGameObjectWithTag("Player2");
                targetIsSet = true;
            }

        }
      
    }

    public void Spawn()
    {
      
        NrOfZombies();
        for (int i = 0; i < randomAmountOfZombies; i++)
        {
            GameObject go = Instantiate(zombie, this.transform);
            go.GetComponent<Zombie>().SetTarget(player1.transform);
        }

    }

    private void NrOfZombies()
    {
        randomAmountOfZombies = Random.Range(1, maxAmountAtSpawnPoint);
        
    }

    public void SetMaxZombies(int amount)
    {
        maxAmountAtSpawnPoint = amount;
    }
  
    

    public bool getCanSpawn()
    {
        return canSpawn;
    }

    public void setCanSpawn()
    {
        float distanceToPlayer1 = Vector3.Distance(player1.transform.position, transform.position);
        float distanceToPlayer2 = Vector3.Distance(player2.transform.position, transform.position);
        //Debug.Log(distanceToPlayer);
        if(distanceToPlayer1 <= minimunDistanceToPlayer || distanceToPlayer2 <= minimunDistanceToPlayer)
        {
            canSpawn = false;
        }
        else
        {
            canSpawn = true;
        }
    }

}
