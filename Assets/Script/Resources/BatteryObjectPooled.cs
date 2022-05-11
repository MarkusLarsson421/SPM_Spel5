using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*@Author Axel Sterner
 * Klass som instansierar batteri-objekt ur poolen. Läggs på en prefab som agerar spawner
 */
public class BatteryObjectPooled : MonoBehaviour
{

    private float timer;
    private bool hasSpawned = false;
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 5)
        {
            SpawnBattery();
            timer = 0;
        }
    }
 
    private void SpawnBattery()
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

    public void SpawnBatteryFromZombie()
    {
        var battery = BatteryPool.Instance.Get();
        battery.gameObject.SetActive(true);
    }
}
