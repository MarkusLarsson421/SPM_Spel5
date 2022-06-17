using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NewZombieHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private EnemyAI zPrefab;
    [SerializeField] private Generator generator;
    [SerializeField] private TMP_Text waveText;
    private SoundManager sM;


    private static int currentWave;

    private int zombieSpawned;
    private int totalZombiesOnMap;
    private float newZombieHealth;

    private int spawnPicker;
    private DistanceCheck distanceCheck;
    private List<GameObject> disabledSpawner = new List<GameObject>();

    [SerializeField] private GameObject[] zombieSpawners;
    void Start()
    {
        sM = GameObject.Find("SM").GetComponent<SoundManager>();
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



    private void SimpleWaveIncreaser()
    {
        waveText.text = currentWave.ToString();
        IncreaseWaveEvent increaseWaveEvent = new IncreaseWaveEvent();
        increaseWaveEvent.currentWave = currentWave;
        increaseWaveEvent.FireEvent();
        sM.SoundPlaying("newWave");
        if (currentWave == 1)
        {
            totalZombiesOnMap = 7;
            newZombieHealth = 80;
        }
        if (currentWave == 2)
        {
            totalZombiesOnMap = 9;
            newZombieHealth = 150;
            generator.SetFuel(0);
            sM.SoundPlaying("generatorOff");
        }
        if (currentWave == 3)
        {
            totalZombiesOnMap = 15;
            newZombieHealth = 200;
        }
        if (currentWave == 4)
        {
            totalZombiesOnMap = 21;
            generator.SetFuel(0);
            sM.SoundPlaying("generatorOff");

        }
        if (currentWave == 5)
        {
            totalZombiesOnMap = 27;
        }
        if (currentWave == 6)
        {
            totalZombiesOnMap = 31;
        }
        if (currentWave == 7)
        {
            totalZombiesOnMap = 32;
            newZombieHealth = 250;
            generator.SetFuel(0);
            sM.SoundPlaying("generatorOff");

        }
        if (currentWave == 8)
        {
            totalZombiesOnMap = 33;
        }
        if (currentWave == 9)
        {
            totalZombiesOnMap = 34;
            generator.SetFuel(0);
            sM.SoundPlaying("generatorOff");

        }
        if (currentWave == 10)
        {
            totalZombiesOnMap = 42;
            newZombieHealth = 275;
        }
        if (currentWave == 11)
        {
            totalZombiesOnMap = 45;
            newZombieHealth = 300;
        }
        if (currentWave >= 12)
        {
            totalZombiesOnMap++;
        }
        

    }


}
