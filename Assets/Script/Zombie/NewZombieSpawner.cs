using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewZombieSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private EnemyAI zPrefab;
    [SerializeField] private NewZombieHandler newZombieHandler;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Spawning();
    }
    private void Spawning()
    {
        if (newZombieHandler.SpawnMoreZombies())
        {
            EnemyAI zo = Instantiate(zPrefab, gameObject.transform.position, Quaternion.identity);
            newZombieHandler.AddZombie();
            Debug.Log("anottaOne");
        }
        
    }
}
