using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*@Author Axel Sterner
 * Klass som instansierar zombie-objekt ur poolen. L�ggs p� en prefab som agerar spawner
 */
public class ZombieObjectPooled : MonoBehaviour
{
    private float cooldown = 5.0f;
    private float nextSpawn;
    public static int amountOfZombiesSpawned;
    private int amtSpawners = 4;
    void Update()
    {
        if (amountOfZombiesSpawned <= 0)
        {
            for(int i = 0; i < amtSpawners; i++)
            {   
                SpawnZombie();
            }
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
/*ATT G�RA
 * Zombier ska komma i v�gor. 
 * 
 * sl� ihop InstantiateZombie och AddZombies, f�rs�k att undvika tv� for-loopar
 * - Fixa s� zombies inte spawnar inuti varandra. Anv�nd OverlapSphere eller raycast f�r att kolla ifall zombies spawnar inuti varandra.
 * Eller Vector3.Distance()
 * - Fixa s� att spawners som �r l�ngt ifr�n spelaren blir avaktiverade
 * - 
 */