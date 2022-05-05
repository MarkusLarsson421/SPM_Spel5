using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*@Author Axel Sterner
 * Klass som instansierar zombie-objekt ur poolen. Läggs på en prefab som agerar spawner
 */
public class ZombieObjectPooled : MonoBehaviour
{
    private float cooldown = 5.0f;
    public ZombiePool zps;
    void Update()
    {
        if (zps.amountOfZombiesSpawned <= 0)
        {
            SpawnZombie();
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
 * Zombier ska komma i vågor. 
 * - Fixa så att zombies respawnar som de ska (alla zombies ska respawna när den sista har dött)
 * slå ihop InstantiateZombie och AddZombies, försök att undvika två for-loopar
 * - Fixa så zombies inte spawnar inuti varandra. Använd OverlapSphere eller raycast för att kolla ifall zombies spawnar inuti varandra.
 * Eller Vector3.Distance()
 * - Fixa så att spawners som är långt ifrån spelaren blir avaktiverade
 * - 
 */