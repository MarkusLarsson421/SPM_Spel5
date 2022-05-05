using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*@Author Axel Sterner
 * Klass som instansierar zombie-objekt ur poolen. Läggs på en prefab som agerar spawner
 */
public class ZombieObjectPooled : MonoBehaviour
{
    private int amtSpawners;
    public static int amountOfZombiesSpawned;
    private float cooldownTime = 5.0f;

    private void Start()
    {
        //amtSpawners = zPool.GetArraySize();
    }

    void Update()
    {
        cooldownTime -= Time.deltaTime;
        if (amountOfZombiesSpawned <= 0 && cooldownTime <= 0)
        {
            for(int i = 0; i < 5; i++)
            {
                SpawnZombie();
            }//spawna en zombie i varje spawner
            cooldownTime = 5.0f;
        }
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
/*ATT GÖRA
 * Zombier ska komma i vågor
 * - Gör någon form av fördröjning så nästa våg inte spawnas direkt
 * - Se över hur jag gör med AddZombies() och InstantiateZombie(), kanske slå ihop dem.
 * - Fixa så zombies inte spawnar inuti varandra. Använd OverlapSphere eller raycast för att kolla ifall zombies spawnar inuti varandra.
 * Eller Vector3.Distance()
 * - Fixa så att spawners som är långt ifrån spelaren blir avaktiverade
 * - 
 */