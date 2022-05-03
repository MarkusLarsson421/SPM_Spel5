using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*@Author Axel Sterner
 * Klass som instansierar scrap-objekt ur poolen. Läggs på en prefab som agerar spawner
 */
public class ScrapObjectPooled : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SpawnScrap();
        }
    }

    private void SpawnScrap()
    {
        var scrap = ScrapPool.Instance.Get();
        scrap.transform.position = transform.position;
        scrap.transform.rotation = transform.rotation;
        scrap.gameObject.SetActive(true);
    }
}
