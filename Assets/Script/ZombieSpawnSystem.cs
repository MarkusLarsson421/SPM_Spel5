using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnSystem : MonoBehaviour
{
    
    [SerializeField] private GameObject[] spawnPositions;
    
    [SerializeField] private float timeBetweenWaves;
    
    [SerializeField] private float waveLength;


    private float waveDuration; //time a wave lasts
    private float waitDuration; //wait between 2 waves
    
    private float waveTimer;
    private float second = 1f;
    

    bool ongoingWave;



    // Start is called before the first frame update
    void Start()
    {

        ongoingWave = false;  
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
            if(waveDuration >= waveLength)
            {
                ongoingWave = false;
                Debug.Log("wave over");
                waitDuration = 0;
            }
        }
        else if(!ongoingWave)
        {
            waveTimer += Time.deltaTime;

            if(waveTimer >= second)
            {
                waitDuration++;
                Debug.Log(waitDuration);
                waveTimer = 0;
            }

            if(waitDuration >= timeBetweenWaves)
            {
                waveSpawn();
                ongoingWave = true;
                waitDuration = 0;
            }
        }
    }

    private void waveSpawn()
    {
        
        for(int i = 0; i < spawnPositions.Length; i++)
        {
            spawnPositions[i].GetComponent<ZombieSpawnPoint>().Spawn();
            Debug.Log("Spawn!");
        }


    }
}
