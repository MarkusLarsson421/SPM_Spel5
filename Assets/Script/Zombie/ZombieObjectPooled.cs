using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*@Author Axel Sterner
 * Klass som instansierar zombie-objekt ur poolen. Läggs på en prefab som agerar spawner
 */
public class ZombieObjectPooled : MonoBehaviour
{

    void Update()
    {
        
    }

    private void SpawnZombie()
    {
        var zombie = ZombiePool.Instance.Get();
        zombie.transform.position = transform.position;
        zombie.transform.rotation = transform.rotation;
        zombie.gameObject.SetActive(true);
    }
}
