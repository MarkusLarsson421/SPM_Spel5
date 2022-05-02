using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*@Author Axel Sterner
 * Klass som instansierar ammo-objekt ur poolen. Läggs på en prefab som agerar spawner
 */
public class AmmoObjectPooled : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            SpawnAmmo();
        }
    }

    private void SpawnAmmo()
    {
        var ammo = AmmoPool.Instance.Get();
        ammo.transform.position = transform.position;
        ammo.transform.rotation = transform.rotation;
        ammo.gameObject.SetActive(true);
    }
}
