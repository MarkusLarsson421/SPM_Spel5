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
    [SerializeField] private bool isAbleToSpawn;
    /*L�gg pickup prefabs som barn till spawner-prefaben. L�gg alla barnen i en lista/k�, om isAbleToSpawn SetActive(index).
     * Detta kan ers�tta PickupPool helt, d� items spawnar genom att helt enkelt s�ttas till aktiva. Ingen object pooling d�remot men os�ker om det verkligen beh�vs.
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
    }/*s�tter position p� items n�r de spawnar. Anropar poolens get(), som anropar AddPickups, detta script sitter p� spawnern som konstant anropar spawnpickupitem.
      * Kan man g�ra n�t liknande f�r zombies?
      */

    public void SetAbleToSpawn(bool value)
    {
        isAbleToSpawn = value;
    }

}