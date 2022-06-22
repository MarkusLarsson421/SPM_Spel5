using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*@Author Axel Sterner
 * Databehållare för zombie-objekt som ska spawnas med object pooling.
 */
public class ZombiePool : MonoBehaviour
{

    [SerializeField] private EnemyAI zPrefab;
    private Queue<EnemyAI> zombieContainer = new Queue<EnemyAI>();
    [SerializeField] private LayerMask zombieLayer;
    public ZombieObjectPooled[] spawnObjects;
    public static ZombiePool Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    public int GetArraySize()
    {
        return spawnObjects.Length;
    }

    public EnemyAI Get()
    {
        if (zombieContainer.Count == 0)
        {
            InstantiateZombie();
            
        }
        zombieContainer.Peek().SetHealth();
        ZombieObjectPooled.amountOfZombiesSpawned++;
        return zombieContainer.Dequeue();
    }

    
    private void InstantiateZombie()
    {
        int randomNumber = Random.Range(0, spawnObjects.Length);//Martin Wallmark
        for (int i = 0; i < spawnObjects.Length; i++)
        {
                if (i == randomNumber)//Martin Wallmark
                {
                  if (spawnObjects[i].isAbleToSpawn == true)
                {
                    //if (spawnObjects[i].gameObject.GetComponent<DistanceCheck>().isAbleToSpawn())
                   // {
                        EnemyAI zo = Instantiate(zPrefab, spawnObjects[i].transform.position, Quaternion.identity);
                        zo.spawnPosition = spawnObjects[i].transform.position;                  
                    zo.gameObject.SetActive(true);
                        zombieContainer.Enqueue(zo);

                    //}

                }
            }
           
            
        }
    }
    public void ReturnToPool(EnemyAI zo)
    {
        zo.gameObject.SetActive(false);
        zombieContainer.Enqueue(zo);
        ZombieObjectPooled.amountOfZombiesSpawned--;
        zo.transform.position = GetTurnedOnSpawnPoint();
    

        spawnObjects[0].DecreaseZombies();
    }

    public Vector3 GetTurnedOnSpawnPoint()
    {
        List<Vector3> activeSpawnPoints = new List<Vector3>();
        Vector3 positionToReturn = new Vector3();
        foreach(ZombieObjectPooled zp in spawnObjects)
        {
            if (zp.gameObject.GetComponent<DistanceCheck>().isAbleToSpawn() == true)
            {
                activeSpawnPoints.Add(zp.transform.position);
            }
        }
        int randomNumber = Random.Range(0, activeSpawnPoints.Count);

        for(int i = 0; i < activeSpawnPoints.Count; i++)
        {
            if(i == randomNumber)
            {
                positionToReturn = activeSpawnPoints[i];
            }
        }

        return positionToReturn;
    }
}
