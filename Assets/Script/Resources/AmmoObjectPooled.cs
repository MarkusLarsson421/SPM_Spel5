using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*@Author Axel Sterner
 * Klass som instansierar ammo-objekt ur poolen. Läggs på en prefab som agerar spawner
 */
public class AmmoObjectPooled : MonoBehaviour
{
    private float timer;
    private bool hasSpawned = false;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 5)
        {
            SpawnAmmo();
            timer = 0;
        }
    }

    private void SpawnAmmo()
    {
        if (!hasSpawned)
        {
            var ammo = AmmoPool.Instance.Get();
            ammo.transform.position = transform.position;
            ammo.transform.rotation = transform.rotation;
            ammo.gameObject.SetActive(true);
            hasSpawned = true;
        }
        hasSpawned = false;
    }
}

