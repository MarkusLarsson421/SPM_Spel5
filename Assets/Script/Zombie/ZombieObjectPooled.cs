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
    private static int zombiesNextWave = 7;
    private static int zombieAmount;
    private int currentWave;
    private int betweenWaves = 20;
    public static int amountOfZombiesSpawned;
    private float cooldownTime = 5.0f;
    [SerializeField]private bool isAbleToSpawn = false;

    private void Start()
    {
        NoMoreZombies();
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

    public void SetAbleToSpawnTrue()
    {
        isAbleToSpawn = true;
    }
    //om detta funkar får jag göra det finare 
    public void SetAbleToSpawnFalse()
    {
        isAbleToSpawn = false;
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
            
            for (int i = 0; i < zombiesNextWave; i++) // nu spawnas HUUUR MÅNGA ZOMBIES MAN VILL 
            {
                SpawnZombie();
                zombieAmount++;
                debug++;

            }//spawna en zombie i varje spawner
            SimpleWaveIncreaser();
        }        
    }
    public void DecreaseZombies()
    {
        zombieAmount--;
    }

    private void SpawnZombie()
    {
        var zombie = ZombiePool.Instance.Get();
        //zombie.transform.position = gameObject.transform.parent.transform.position;//cacha
        zombie.gameObject.SetActive(true);
        //zombie.gameObject.GetComponent<EnemyAI>().spawnPosition = transform.position;
    }
}
/*ATT GÖRA
 * Zombies spawnar inte som de ska. Första waven spawnar de rätt, andra waven spawnar alla på en och samma spawnerprefab, förutom en som spawnar bakom spelaren. 
 * Andra vågen så spawnar alla förutom en zombie på en och samma prefab, den sista spawnar på den andra prefaben. Scriptet har testats med två spawners aktiva i scenen.
 * 
 * 
 * - Se över hur jag gör med AddZombies() och InstantiateZombie(), kanske slå ihop dem.
 */
