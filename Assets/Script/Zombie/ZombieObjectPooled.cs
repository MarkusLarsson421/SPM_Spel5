using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*@Author Axel Sterner
 * Klass som instansierar zombie-objekt ur poolen. L�ggs p� en prefab som agerar spawner
 */
public class ZombieObjectPooled : MonoBehaviour
{
    private float cooldown = 5.0f;
    public ZombiePool zps;
    private void Start()
    {
        SpawnZombie();
        //f�rsta waven. kan beh�va justeras
    }

    void Update()
    {
        Debug.Log(zps.amountOfZombiesSpawned);
        /*
         * cooldown ska r�knas ner. n�r cd �r <= 15, anropa SpawnZombie och �terst�ll cooldown.
         * cooldown-nedr�kning m�ste nog ligga i ett villkor. problemet: hur h�ller jag koll p� antal zombies f�r att veta n�r n�sta v�g kommer?
         */
        if (zps.amountOfZombiesSpawned == 0)//om inga zombies finns kvar, starta cooldown o r�kna ner
        {
            Debug.Log("funkar");
            cooldown -= Time.deltaTime;
            if (cooldown <= 0)
            {
                Debug.Log("funkar2");
                SpawnZombie();
                cooldown = 5;
            }
        }

    }

    private void SpawnZombie()
    {
        var zombie = ZombiePool.Instance.Get();
        zombie.transform.position = transform.position;
        zombie.transform.rotation = transform.rotation;
        zombie.gameObject.SetActive(true);
    }
}
/*H�ll koll p� cooldown och instansiering av waves h�r.
 */