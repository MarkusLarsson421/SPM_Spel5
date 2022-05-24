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
    /*Lägg pickup prefabs som barn till spawner-prefaben. Lägg alla barnen i en lista/kö, om isAbleToSpawn SetActive(index).
     * Detta kan ersätta PickupPool helt, då items spawnar genom att helt enkelt sättas till aktiva. Ingen object pooling däremot men osäker om det verkligen behövs.
     */
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
            item.transform.SetPositionAndRotation(transform.position, transform.rotation);
            item.gameObject.SetActive(true);
        }
    }/*sätter position på items när de spawnar. Anropar poolens get(), som anropar AddPickups, detta script sitter på spawnern som konstant anropar spawnpickupitem.
      * Kan man göra nåt liknande för zombies?
      */

    public void SetAbleToSpawn(bool value)
    {
        isAbleToSpawn = value;
    }

}