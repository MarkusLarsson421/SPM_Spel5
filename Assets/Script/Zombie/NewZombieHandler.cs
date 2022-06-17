using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewZombieHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private EnemyAI zPrefab;
    private int zombieSpawned;
    private int totalZombiesOnMap = 15;
    [SerializeField] private GameObject[] zombieSpawners;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SpawnMoreZombies())
        {
            SpawnHere();
        }
    }
    public void AddZombie()
    {
         zombieSpawned++;
    }
    public bool SpawnMoreZombies()
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

    private void SpawnHere()
    {
        int zS = zombieSpawners.Length;
        int spawnPicker = Random.Range(0, zS);
        EnemyAI zo = Instantiate(zPrefab, zombieSpawners[spawnPicker].transform.position, Quaternion.identity);
        AddZombie();
        Debug.Log("DJKHALED");
        Debug.Log(spawnPicker);


    }
}
