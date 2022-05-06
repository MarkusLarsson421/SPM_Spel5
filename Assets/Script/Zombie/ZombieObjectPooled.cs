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
    private int amtSpawners;
    private static int zombiesNextWave = 10;
    private static int zombieAmount;
    private int currentWave;
    private int betweenWaves = 4;
    public static int amountOfZombiesSpawned;

    private void Start()
    {
        NoMoreZombies();
        //amtSpawners = zPool.GetArraySize();
    }

    void Update()
    {


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
        Debug.Log(zombieAmount);
        /*if(zombieAmount < 0)
       {
            zombieAmount = 0;
       }*/
        if (zombieAmount <= 0)
        {
            Debug.Log($"spawned zombies now: {debug} | total zombies: {zombieAmount} | zombies next wave {zombiesNextWave}");
            for (int i = 0; i < zombiesNextWave; i++) // nu spawnas HUUUR M�NGA ZOMBIES MAN VILL 
            {
                Debug.Log(zombieAmount);
                SpawnZombie();
                zombieAmount++;
                debug++;
                
            }//spawna en zombie i varje spawner
            SimpleWaveIncreaser();
        }
        
        Debug.Log($"spawned zombies now: {debug} | total zombies: {zombieAmount} | zombies next wave {zombiesNextWave}");
    }

    public void DecreaseZombies()
    {
        zombieAmount--;
    }

    private void SpawnZombie()
    {
        var zombie = ZombiePool.Instance.Get();
       /* float randomXValue = Random.Range(1, 4);
        Vector3 distCorrection = new Vector3(randomXValue, 2.4f);
        zombie.transform.SetPositionAndRotation(distCorrection, transform.rotation);*/
        zombie.gameObject.SetActive(true);
    }
}
/*ATT G�RA
 * Zombier ska komma i v�gor
 * - Fixa denna kod
 * - Fixa s� zombies inte spawnar inuti varandra. Anv�nd OverlapSphere eller raycast f�r att kolla ifall zombies spawnar inuti varandra.
 * Eller Vector3.Distance()
 * - Fixa s� att spawners som �r l�ngt ifr�n spelaren blir avaktiverade
 * - 
 */