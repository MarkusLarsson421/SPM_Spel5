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
    private void Start()
    {
        //SpawnZombie();
        //första waven. kan behöva justeras
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SpawnZombie();
            Debug.Log("spawna");
        }
        /*cooldown -= Time.deltaTime;
        if (cooldown <= 0 && zps.amountOfZombiesSpawned <= 0) 
        {
            Debug.Log($"{zps.amountOfZombiesSpawned} {cooldown}");
            SpawnZombie();
            cooldown = 5;
        }*/
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
 * - Fixa så att zombies faktiskt spawnar vid spawners
 * - Fixa så zombies inte spawnar inuti varandra. Använd OverlapSphere eller raycast för att kolla ifall zombies spawnar inuti varandra.
 * Eller Vector3.Distance()
 * - Fixa så att spawners som är långt ifrån spelaren blir avaktiverade
 * - 
 */