using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*@Author Axel Sterner
 * Klass som instansierar pickups ur poolen. L�ggs p� en prefab som agerar spawner
 */
public class PickupObjectPooled : MonoBehaviour
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
        if (timer > timeUntilRespawn)
        {
            timer = 0;
            SpawnPickupItem();
        }
    }

    private void SpawnPickupItem()
    {
        if (isAbleToSpawn == true)
        {
            isAbleToSpawn = false;
            Debug.Log(isAbleToSpawn);
            GameObject item = PickupPool.Instance.Get();
            item.transform.position = transform.position;
            item.transform.rotation = transform.rotation;
            item.gameObject.SetActive(true);
        }
    }

    public void SetAbleToSpawn(bool value)
    {
        isAbleToSpawn = value;
    }

}