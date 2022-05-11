using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*@Author Axel Sterner
 * Klass som instansierar scrap-objekt ur poolen. Läggs på en prefab som agerar spawner
 */
public class ScrapObjectPooled : MonoBehaviour
{
    private float timer;
    private bool hasSpawned;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 5)
        {
            SpawnScrap();
            timer = 0;
        }
    }

    private void SpawnScrap()
    {
        if (!hasSpawned)
        {
            var battery = BatteryPool.Instance.Get();
            battery.transform.position = transform.position;
            battery.transform.rotation = transform.rotation;
            battery.gameObject.SetActive(true);
            hasSpawned = true;
        }
        hasSpawned = false;
    }
}
