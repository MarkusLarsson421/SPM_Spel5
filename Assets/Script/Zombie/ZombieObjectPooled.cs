using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/*@Author Axel Sterner 
 *@Simon Hessling Oscarson
 * Klass som instansierar zombie-objekt ur poolen. Läggs på en prefab som agerar spawner
 */
public class ZombieObjectPooled : MonoBehaviour
{
    [SerializeField] private TMP_Text waveText;
    private static int zombiesNextWave;
    private static int zombieAmount;
    private int currentWave;
    private int betweenWaves = 20;
    public static int amountOfZombiesSpawned;
    [SerializeField] private bool isAbleToSpawn = false;
    private float timeInSeconds;
    private int minutes;
    public float delay = 20.1f;
    private float newZombieHealth;
    private void Start()
    {
        NoMoreZombies();
    }
    private void Update()
    {
        CountMinutes();
    }

    private void CountMinutes()
    {
        timeInSeconds += Time.deltaTime;
        minutes = ((int)(timeInSeconds / 60)) % 60;
    }

    /*
     * @ AuthorSimon Hessling Oscarson
     * 
     * 
     */
    private void SimpleWaveIncreaser()
    {
        currentWave++;
        if(currentWave == 1)
        {
            zombiesNextWave = 7;
            newZombieHealth = 150;
        }
        if (currentWave == 2)
        {
            
            zombiesNextWave = 9;
            newZombieHealth = 200;

        }
        if (currentWave == 3)
        {
            zombiesNextWave = 15;
            newZombieHealth = 250;
        }
        if (currentWave == 4)
        {
            zombiesNextWave = 21;
        }
        if (currentWave == 5)
        {
            zombiesNextWave = 27;
            //EN HORDE SPAWNAS
        }
        if (currentWave == 6)
        {
            zombiesNextWave = 31;
            //EN HORDE SPAWNAS
        }
        if (currentWave == 7)
        {
            zombiesNextWave = 32;
            newZombieHealth = 300;
            //EN HORDE SPAWNAS
        }
        if (currentWave == 8)
        {
            zombiesNextWave = 33;
            //EN HORDE SPAWNAS
        }
        if (currentWave == 9)
        {
            zombiesNextWave = 34;
            //EN HORDE SPAWNAS
        }
        if(currentWave == 10)
        {
            zombiesNextWave = 42;
            newZombieHealth = 350;
            //EN HORDE SPAWNAS
        }
        if (currentWave == 11)
        {
            zombiesNextWave = 45;
            //EN HORDE SPAWNAS
        }
        if (currentWave >= 12)
        {
            zombiesNextWave++;
            //TVÅ HORDE SPAWNAS
        }

        waveText.text = currentWave.ToString();
    }
    /*
    * @ AuthorSimon Hessling Oscarson
    * 
    * 
    */
    private void NoMoreZombies()
    {
        InvokeRepeating(nameof(DoIT), 0, betweenWaves);
    }

    public void SetAbleToSpawn(bool value)
    {
        isAbleToSpawn = value;
    }
    /*
    * @ AuthorSimon Hessling Oscarson
    * 
    * 
    */
    private void DoIT()
    {
        int debug = 0;

        if (zombieAmount <= 0 && isAbleToSpawn)
        {
            SimpleWaveIncreaser();
             
            for (int i = 0; i < zombiesNextWave; i++)
            {

                
                SpawnZombie();
                zombieAmount++;
                debug++;
            }
            
        }
    }

   

   /*
    * 
    * 
    * @Author Simon Hessling Oscarson
    */
    public void DecreaseZombies()
    {
        zombieAmount--;
    }

    private void SpawnZombie()
    {
        var zombie = ZombiePool.Instance.Get();
        zombie.SetNewHealth(newZombieHealth); //Simon Hessling Oscarson
        zombie.gameObject.SetActive(true);
    }
    //Khaled Alraas
    public int getCurrentWave()
    {
        return currentWave;
    }
}