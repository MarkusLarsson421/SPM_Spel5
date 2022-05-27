using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*@Author Axel Sterner
 * Klass som instansierar pickups ur poolen. Läggs på en prefab som agerar spawner
 */
public class PickupObjectPooled : MonoBehaviour
{
    private float timer;
    private float timeUntilRespawn = 2.0f;
    [SerializeField] private bool isAbleToSpawn;

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
            GameObject item = PickupPool.Instance.Get();
            item.transform.SetPositionAndRotation(transform.position, transform.rotation);
            item.gameObject.SetActive(true);
        }
    }
    public void SetAbleToSpawn(bool value)
    {
        isAbleToSpawn = value;
    }

}