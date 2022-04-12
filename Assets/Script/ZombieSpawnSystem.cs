using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnSystem : MonoBehaviour
{

    [SerializeField] private GameObject[] spawnPositions;

    private float waveDuration;
    private float timeBetweenWaves;
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
    }

    private void waveSpawn()
    {
        ongoingWave = true;


    }
}
