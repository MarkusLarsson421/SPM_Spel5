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
    private int amtSpawners;
    private static int zombiesNextWave = 15;
    private static int zombieAmount;
    private int currentWave;
    private int betweenWaves = 4;
    public static int amountOfZombiesSpawned;
    private float cooldownTime = 5.0f;
    public bool isAbleToSpawn = true;

    private void Start()
    {
        NoMoreZombies();
        //amtSpawners = zPool.GetArraySize();
    }

    /*
     * @ AuthorSimon Hessling Oscarson
     * 
     * 
     */
    private void SimpleWaveIncreaser()
    {
        zombiesNextWave++;
        currentWave++;
        waveText.text = currentWave.ToString();
    }
    /*
    * @ AuthorSimon Hessling Oscarson
    * 
    * 
    */
    private void NoMoreZombies()
    {
        {
            InvokeRepeating("DoIT", 0, betweenWaves);
        }
    }
    /*
    * @ AuthorSimon Hessling Oscarson
    * 
    * 
    */
    private void DoIT()
    {
        int debug = 0;
        /*if(zombieAmount < 0)
       {
            zombieAmount = 0;
       }*/
       // DistanceFromPlayer();
        if (zombieAmount <= 0 && isAbleToSpawn)
        {
            Debug.Log($"spawned zombies now: {debug} | total zombies: {zombieAmount} | zombies next wave {zombiesNextWave}");
            for (int i = 0; i < zombiesNextWave; i++) // nu spawnas HUUUR MÅNGA ZOMBIES MAN VILL 
            {
                SpawnZombie();
                zombieAmount++;
                debug++;

            }//spawna en zombie i varje spawner
            SimpleWaveIncreaser();
        }

        Debug.Log($"spawned zombies now: {debug} | total zombies: {zombieAmount} | zombies next wave {zombiesNextWave}");
    }
    
    /*private void DistanceFromPlayer()
    {
        if(Vector3.Distance(gameObject.transform.position, GameObject.FindGameObjectWithTag("Player1").transform.position) > 40 || Vector3.Distance(gameObject.transform.position, GameObject.FindGameObjectWithTag("Player2").transform.position) > 40)
        {
            gameObject.SetActive(false);
            
        }
        else
        {
            gameObject.SetActive(true);
        }
        
    }*/
    public void DecreaseZombies()
    {
        zombieAmount--;
    }

    private void SpawnZombie()
    {
        var zombie = ZombiePool.Instance.Get();
        /* float randomXValue = Random.Range(1, 4);
         * Vector3 distCorrection = new Vector3(randomXValue, 2.4f);
         * zombie.transform.SetPositionAndRotation(distCorrection, transform.rotation);*/
        zombie.gameObject.SetActive(true);   
    }
}
/*ATT GÖRA
 * Zombier ska komma i vågor
 * - Se över hur jag gör med AddZombies() och InstantiateZombie(), kanske slå ihop dem.
 * - Fixa så zombies inte spawnar inuti varandra. Använd OverlapSphere eller raycast för att kolla ifall zombies spawnar inuti varandra.
 * Eller Vector3.Distance()
 */
