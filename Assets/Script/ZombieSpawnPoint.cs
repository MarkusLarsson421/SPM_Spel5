using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Martin Wallmark
public class ZombieSpawnPoint : MonoBehaviour
{
    public Transform target;
    [SerializeField] private GameObject zombie;
    [SerializeField] private int maxAmountAtSpawnPoint;
    private int randomAmountOfZombies;
    private BoxCollider spawnStopper;

    private bool canSpawn;

    private void Start()
    {
        spawnStopper = gameObject.GetComponent<BoxCollider>();
    }

    public void Spawn()
    {
        if (canSpawn)
        {
            NrOfZombies();
            for (int i = 0; i < randomAmountOfZombies; i++)
            {
                GameObject go = Instantiate(zombie, this.transform);
                go.GetComponent<Zombie>().SetTarget(target);
            }
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
    /*
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Collision");
            canSpawn = false;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canSpawn = true;
        }
    }
    */

    public bool getCanSpawn()
    {
        return canSpawn;
    }


}
