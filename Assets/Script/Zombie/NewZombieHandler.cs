using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NewZombieHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private EnemyAI zPrefab;
    private Queue<EnemyAI> zombieContainer = new Queue<EnemyAI>();
    [SerializeField] private Generator generator;
    [SerializeField] private TMP_Text waveText;
    public static NewZombieHandler Instance { get; private set; }

    private SoundManager sM;


    private int currentWave;
    private int zombieAmount;


    private int zombieSpawned;
    private int totalZombiesOnMap;
    private float newZombieHealth;
    private bool gameStarted;
    private int spawnPicker;
    private DistanceCheck distanceCheck;
    private List<GameObject> disabledSpawner = new List<GameObject>();

    [SerializeField] private GameObject[] zombieSpawners;
    void Start()
    {
        sM = GameObject.Find("SM").GetComponent<SoundManager>();
        InvokeRepeating(nameof(WaveIncreaser), 0, 10);


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
                    gameStarted = true;
                    SpawnHere();
                    
                }
            }
        }
        Debug.Log("mängd zombies" + zombieAmount);
        
    }
    private void SpawnHere()
    {
        EnemyAI zo = Instantiate(zPrefab, zombieSpawners[spawnPicker].transform.position, Quaternion.identity);
        AddZombie();
        zombieContainer.Enqueue(zo);
        Debug.Log(spawnPicker);
    }
 
   
 
    public void DecreaseZombies()
    {
        zombieAmount--;
    }
    private void WaveIncreaser()
    {
        if (zombieAmount == 0)
        {
            currentWave++;

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
        }

        Debug.Log("detta är wavet" + currentWave);
        Debug.Log("detta är mängd zombies" + zombieAmount);

    }

}
