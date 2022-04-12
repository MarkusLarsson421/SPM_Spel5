using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnSystem : MonoBehaviour
{

    [SerializeField] private GameObject[] spawnPositions;
    //[SerializeField] private float timeBetweenWavesLong;
    [SerializeField] private float timeBetweenWavesShort;



    private float waveDuration;
    private float waitDuration;
    
    private float waveTimer;
    private float second = 1f;
    

    bool ongoingWave;



    // Start is called before the first frame update
    void Start()
    {
        
         
    }

    // Update is called once per frame
    void Update()
    {
        if (ongoingWave)
        {
            waveTimer += Time.deltaTime;

            if (waveTimer >= second)
            {
                waveDuration++;
                waveTimer = 0;
            }
        }
        else
        {
            waveTimer += Time.deltaTime;

            if(waveTimer >= second)
            {
                waitDuration++;
                waveTimer = 0;
            }

            if(waitDuration >= timeBetweenWavesShort)
            {
                waveSpawn();
            }
        }
    }

    private void waveSpawn()
    {
        ongoingWave = true;
        for(int i = 0; i < spawnPositions.Length; i++)
        {
            spawnPositions[i].GetComponent<ZombieSpawnPoint>().Spawn();
        }


    }
}
