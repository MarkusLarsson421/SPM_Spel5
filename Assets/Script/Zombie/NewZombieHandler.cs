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
    public static NewZombieHandler Instance { get; private set; }

    private SoundManager sM;


    private static int currentWave;
    private static int zombieAmount;


    private int zombieSpawned;
    private int totalZombiesOnMap = 15;
    private float newZombieHealth;

    private int spawnPicker;
    private DistanceCheck distanceCheck;
    private List<GameObject> disabledSpawner = new List<GameObject>();

    [SerializeField] private GameObject[] zombieSpawners;
    void Start()
    {
        sM = GameObject.Find("SM").GetComponent<SoundManager>();
        
    }
    private void Awake()
    {
        Instance = this;
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
        zombieAmount++;
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
 
   
 
    public void DecreaseZombies()
    {
        zombieAmount--;
    }


}
