using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*@Author Axel Sterner
 * Databehållare för zombie-objekt som ska spawnas med object pooling.
 */
public class ZombiePool : MonoBehaviour
{
    /*Linjär ökning av zombies varje runda. Första rundan: 7 zombies.
     * När sista zombien i rundan dör får spelaren ca 15 sekunder innan nästa runda börjar.
     * Börja med att 7 zombies ska spawna varje runda och när sista zombien dör börjar nästa runda efter 15 sekunder.
     */
    [SerializeField] private EnemyAI zPrefab;
    public int amountOfZombiesSpawned; //@Author Simon Hessling Oscarsson, görs ++ varje gång en zombie spawnar.
    private Queue<EnemyAI> zombieContainer = new Queue<EnemyAI>(10);
    private int zombieQty = 2;
    private System.Random rnd = new System.Random();
    [SerializeField] private LayerMask zombieLayer;

    [SerializeField] private GameObject[] spawnObjects;

    public static ZombiePool Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    private int CheckCollisionOnSpawn()
    {
        int maxColliders = 10;
        Collider[] hitColliders = new Collider[maxColliders];
        int numColliders = Physics.OverlapSphereNonAlloc(transform.position, 10.0f, hitColliders, zombieLayer);
        return numColliders;
        //om returvärdet <= 0 så uppstår ingen kollision
    }

    public EnemyAI Get()
    {
        if(zombieContainer.Count == 0)
        {
            AddZombies(zombieQty);
        }
        zombieContainer.Peek().SetHealth();
        amountOfZombiesSpawned++;

        return zombieContainer.Dequeue();
    }

    private void AddZombies(int count)
    {
        for (int i = 0; i < count; i++)
        {//if isColliding <= 0, kör Instantiate och allt. Annars vänta med att instansiera
            InstantiateZombie();
        }
    }

    private void InstantiateZombie()
    {
        /*float randomXValue = (float)rnd.NextDouble() % 4;
        Vector3 distCorrection = new Vector3(randomXValue, 2.4f);*/
        for(int i = 0; i < spawnObjects.Length; i++)
        {
            EnemyAI zo = Instantiate(zPrefab, spawnObjects[i].transform.position, Quaternion.identity);
            zo.gameObject.SetActive(true);//false
            zombieContainer.Enqueue(zo);
        }
        
    }

    public void ReturnToPool(EnemyAI zo)
    {
        Debug.Log(zombieQty);
        zo.gameObject.SetActive(false);
        amountOfZombiesSpawned--;
        zombieContainer.Enqueue(zo);
    }
    /*Håll koll på hur många zombies som finns här. 
     */
     
}
