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
    public static int zombieQty = 1;
    private System.Random rnd = new System.Random();
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
            AddZombies(zombieQty);
        }
        zombieContainer.Peek().SetHealth();
        ZombieObjectPooled.amountOfZombiesSpawned++;
        return zombieContainer.Dequeue();
    }

    private void AddZombies(int count)
    {
        for (int i = 0; i < count; i++)
        {
            InstantiateZombie();
        }
    }
    private void InstantiateZombie()
    {
        int randomNumber = Random.Range(0, spawnObjects.Length);//Martin Wallmark
        for (int i = 0; i < spawnObjects.Length; i++)
        {
            if(i == randomNumber)//Martin Wallmark
            {
                EnemyAI zo = Instantiate(zPrefab, spawnObjects[i].transform.position, Quaternion.identity);
                zo.spawnPosition = spawnObjects[i].transform.position;
                zo.gameObject.SetActive(true);
                zombieContainer.Enqueue(zo);
            }
            
        }
    }
    public void ReturnToPool(EnemyAI zo)
    {
        zo.gameObject.SetActive(false);
        zombieContainer.Enqueue(zo);
        ZombieObjectPooled.amountOfZombiesSpawned--;
        zo.transform.position = zo.spawnPosition;
        spawnObjects[0].DecreaseZombies();
    }
}
