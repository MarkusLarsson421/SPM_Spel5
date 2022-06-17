using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewZombieHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private EnemyAI zPrefab;
    private int zombieSpawned;
    private int totalZombiesOnMap = 15;
    private int spawnPicker;
    private DistanceCheck distanceCheck;
    private List<GameObject> disabledSpawner = new List<GameObject>();

    [SerializeField] private GameObject[] zombieSpawners;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SpawnMoreZombies())
        {
            IsAbleToSpawnHere();
           // SpawnHere();
        }
    }
    private void AddZombie()
    {
         zombieSpawned++;
    }
    private bool SpawnMoreZombies()
    {
        if(zombieSpawned < totalZombiesOnMap)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void IsAbleToSpawnHere()
    {
        int zS = zombieSpawners.Length;
        spawnPicker = Random.Range(0, zS);
        for(int i = 0; i < zombieSpawners.Length; i++)
        {
            if(i == spawnPicker)
            {
                if (zombieSpawners[i].GetComponent<DistanceCheck>().isAbleToSpawn())
                {
                    SpawnHere();
                }
                else
                {
                    Debug.Log("AnotthaOne "+spawnPicker);

                }

            }
        }

    }
    private void SpawnHere()
    {
        EnemyAI zo = Instantiate(zPrefab, zombieSpawners[spawnPicker].transform.position, Quaternion.identity);
        AddZombie();
        Debug.Log(spawnPicker);


    }
}
