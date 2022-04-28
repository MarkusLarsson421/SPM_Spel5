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
    private GameObject player;

    private float timer;

    private bool canSpawn;
    private bool targetIsSet;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (!targetIsSet)
        {

            timer += Time.deltaTime;

            if (timer >= 20)
            {
                player = GameObject.FindGameObjectWithTag("Player1");
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
            go.GetComponent<Zombie>().SetTarget(player.transform);
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
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        Debug.Log(distanceToPlayer);
        if(distanceToPlayer <= minimunDistanceToPlayer)
        {
            canSpawn = false;
        }
        else
        {
            canSpawn = true;
        }
    }

}
