using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*@Author Axel Sterner
 * Klass som instansierar batteri-objekt ur poolen. Läggs på en prefab som agerar spawner
 */
public class BatteryObjectPooled : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            SpawnBattery();
        }
    }

    private void SpawnBattery()
    {
        var battery = BatteryPool.Instance.Get();
        battery.transform.position = transform.position;
        battery.transform.rotation = transform.rotation;
        battery.gameObject.SetActive(true);
    }
}
