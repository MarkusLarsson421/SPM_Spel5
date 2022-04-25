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
    

    private bool canSpawn;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Spawn()
    {
        NrOfZombies();
        for (int i = 0; i < randomAmountOfZombies; i++)
        {
            GameObject go = Instantiate(zombie, this.transform);
            go.GetComponent<Zombie>().SetTarget(target);
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