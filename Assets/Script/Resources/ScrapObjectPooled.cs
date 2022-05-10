using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*@Author Axel Sterner
 * Klass som instansierar scrap-objekt ur poolen. Läggs på en prefab som agerar spawner
 */
public class ScrapObjectPooled : MonoBehaviour
{
    private float timer;
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
        var scrap = ScrapPool.Instance.Get();
        scrap.transform.position = transform.position;
        scrap.transform.rotation = transform.rotation;
        scrap.gameObject.SetActive(true);
    }
}
