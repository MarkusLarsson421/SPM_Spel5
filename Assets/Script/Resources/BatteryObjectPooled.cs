using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*@Author Axel Sterner
 * Klass som instansierar batteri-objekt ur poolen. Läggs på en prefab som agerar spawner
 */
public class BatteryObjectPooled : MonoBehaviour
{
    private float timer;
    private float timeUntilRespawn = 2.0f;
    private bool isAbleToSpawn;

    private void Start()
    {
        isAbleToSpawn = true;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > timeUntilRespawn)
        {
            timer = 0;
            SpawnBattery();
        }
    }

    private void SpawnBattery()
    {
        if (isAbleToSpawn == true)
        {
            isAbleToSpawn = false;
            Debug.Log(isAbleToSpawn);
            var battery = BatteryPool.Instance.Get();
            battery.transform.position = transform.position;
            battery.transform.rotation = transform.rotation;
            battery.gameObject.SetActive(true);
        }   
    }

    public void SetSpawned(bool value)
    {
        isAbleToSpawn = value;
    }
    
}