using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*@Author Axel Sterner
 * Klass som instansierar zombie-objekt ur poolen. L�ggs p� en prefab som agerar spawner
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
/*ATT G�RA
 * Zombier ska komma i v�gor
 * - G�r n�gon form av f�rdr�jning s� n�sta v�g inte spawnas direkt
 * - Se �ver hur jag g�r med AddZombies() och InstantiateZombie(), kanske sl� ihop dem.
 * - Fixa s� zombies inte spawnar inuti varandra. Anv�nd OverlapSphere eller raycast f�r att kolla ifall zombies spawnar inuti varandra.
 * Eller Vector3.Distance()
 * - Fixa s� att spawners som �r l�ngt ifr�n spelaren blir avaktiverade
 * - 
 */