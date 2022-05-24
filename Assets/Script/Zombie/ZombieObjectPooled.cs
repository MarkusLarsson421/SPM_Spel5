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
    //om detta funkar f�r jag g�ra det finare 
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
            
            for (int i = 0; i < zombiesNextWave; i++) // nu spawnas HUUUR M�NGA ZOMBIES MAN VILL 
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
/*ATT G�RA
 * Zombies spawnar inte som de ska. F�rsta waven spawnar de r�tt, andra waven spawnar alla p� en och samma spawnerprefab, f�rutom en som spawnar bakom spelaren. 
 * Andra v�gen s� spawnar alla f�rutom en zombie p� en och samma prefab, den sista spawnar p� den andra prefaben. Scriptet har testats med tv� spawners aktiva i scenen.
 * 
 * 
 * - Se �ver hur jag g�r med AddZombies() och InstantiateZombie(), kanske sl� ihop dem.
 */
