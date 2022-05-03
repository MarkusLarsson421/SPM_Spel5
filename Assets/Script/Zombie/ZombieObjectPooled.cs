using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*@Author Axel Sterner
 * Klass som instansierar zombie-objekt ur poolen. Läggs på en prefab som agerar spawner
 */
public class ZombieObjectPooled : MonoBehaviour
{
    private float cooldown = 5.0f;
    public ZombiePool zps;
    private void Start()
    {
        SpawnZombie();
        //första waven. kan behöva justeras
    }

    void Update()
    {
        Debug.Log(zps.amountOfZombiesSpawned);
        /*
         * cooldown ska räknas ner. när cd är <= 15, anropa SpawnZombie och återställ cooldown.
         * cooldown-nedräkning måste nog ligga i ett villkor. problemet: hur håller jag koll på antal zombies för att veta när nästa våg kommer?
         */
        if (zps.amountOfZombiesSpawned == 0)//om inga zombies finns kvar, starta cooldown o räkna ner
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
/*Håll koll på cooldown och instansiering av waves här.
 */