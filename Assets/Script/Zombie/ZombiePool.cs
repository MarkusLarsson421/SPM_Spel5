using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*@Author Axel Sterner
 * Databeh�llare f�r zombie-objekt som ska spawnas med object pooling.
 */
public class ZombiePool : MonoBehaviour
{
    /*Linj�r �kning av zombies varje runda. F�rsta rundan: 7 zombies.
     * N�r sista zombien i rundan d�r f�r spelaren ca 15 sekunder innan n�sta runda b�rjar.
     * B�rja med att 7 zombies ska spawna varje runda och n�r sista zombien d�r b�rjar n�sta runda efter 15 sekunder.
     */
    [SerializeField] private EnemyAI zPrefab;
    private Queue<EnemyAI> zombieContainer = new Queue<EnemyAI>();
    public static int zombieQty = 1;
    private System.Random rnd = new System.Random();
    [SerializeField] private LayerMask zombieLayer;
    [SerializeField] private GameObject[] spawnObjects;
    public static ZombiePool Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    public int GetArraySize()
    {
        return spawnObjects.Length;
    }

    /*private int CheckCollisionOnSpawn()
    {
        int maxColliders = 10;
        Collider[] hitColliders = new Collider[maxColliders];
        int numColliders = Physics.OverlapSphereNonAlloc(transform.position, 10.0f, hitColliders, zombieLayer);
        return numColliders;
        //om returv�rdet <= 0 s� uppst�r ingen kollision
    }*/

    public EnemyAI Get()
    {
        if (zombieContainer.Count == 0)
        {
            AddZombies(zombieQty);
            //Debug.Log(zombieContainer.Count);
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
        /*float randomXValue = (float)rnd.NextDouble() % 4;
        Vector3 distCorrection = new Vector3(randomXValue, 2.4f);*/
        for (int i = 0; i < spawnObjects.Length; i++)
        {
            EnemyAI zo = Instantiate(zPrefab, spawnObjects[i].transform.position, Quaternion.identity);
            zo.gameObject.SetActive(true);
            zombieContainer.Enqueue(zo);
        }
    }
    public void ReturnToPool(EnemyAI zo)
    {
        zo.gameObject.SetActive(false);
        zombieContainer.Enqueue(zo);
        ZombieObjectPooled.amountOfZombiesSpawned--;
    }
}
