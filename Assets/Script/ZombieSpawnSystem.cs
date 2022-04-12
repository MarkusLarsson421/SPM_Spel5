using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnSystem : MonoBehaviour
{

    [SerializeField] private GameObject[] spawnPositions;
    private float waveDuration;
    private float timeBetweenWaves;

    bool ongoingWave



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void waveSpawn()
    {
        ongoingWave = true;


    }
}
