using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/*@Author Axel Sterner 
 *@Simon Hessling Oscarson
 * Klass som instansierar zombie-objekt ur poolen. L�ggs p� en prefab som agerar spawner
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
        }
        if (currentWave == 2)
        {
            zombiesNextWave = 9;
        }
        if (currentWave == 3)
        {
            zombiesNextWave = 15;
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
            //TV� HORDE SPAWNAS
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



        
        /*if(minutes == 1) 
        {
            for (int i = 0; i < zombiesNextWave; i++)
            {
                Debug.Log("wave startad");
                SpawnZombie();
                zombieAmount++;
                debug++;
            }
        }*/
        //att anropa spawnzombie p� det h�r s�ttet fungerar. alldeles f�r m�nga zombies spawnas dock.
    }

   

    private IEnumerator spawnaspawnaspawna(int timeToFinish)
    {

        for (int i = 0; i < zombiesNextWave; i++)
        {

            SpawnZombie();

            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(timeToFinish);
        
    }
    public void DecreaseZombies()
    {
        zombieAmount--;
    }

    private void SpawnZombie()
    {
        var zombie = ZombiePool.Instance.Get();
        zombie.gameObject.SetActive(true);
    }
}
/*ATT G�RA
 * L�s v�gor och hordes (se trello).
 * R�kna ut tid p� n�t bra s�tt, skapa d�refter logik f�r att starta ny v�g
 * - Se �ver hur jag g�r med AddZombies() och InstantiateZombie(), kanske sl� ihop dem.
 */
