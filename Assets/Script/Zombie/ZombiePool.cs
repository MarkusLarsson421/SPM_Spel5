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
    [SerializeField] private Zombie zPrefab;
    public int amountOfZombiesSpawned; //@Author Simon Hessling Oscarsson, g�rs ++ varje g�ng en zombie spawnar.
    private Queue<Zombie> zombieContainer = new Queue<Zombie>(10);
    private int zombieQty = 4;
    private System.Random rnd = new System.Random();
    [SerializeField] private LayerMask zombieLayer;

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
        //om returv�rdet <= 0 s� uppst�r ingen kollision
    }

    public Zombie Get()
    {
        if(zombieContainer.Count == 0)
        {
            AddZombies(zombieQty);
        }
        zombieContainer.Peek().SetHealth(100);
        amountOfZombiesSpawned++;

        return zombieContainer.Dequeue();
    }

    private void AddZombies(int count)
    {
        for (int i = 0; i < count; i++)
        {//if isColliding <= 0, k�r Instantiate och allt. Annars v�nta med att instansiera
            InstantiateZombie();
        }
    }

    private void InstantiateZombie()
    {
        float randomXValue = (float)rnd.NextDouble() % 4;
        Vector3 distCorrection = new Vector3(randomXValue, 2.4f);
        Zombie zo = Instantiate(zPrefab, distCorrection, Quaternion.identity);
        zo.gameObject.SetActive(true);//false
        zombieContainer.Enqueue(zo);
    }

    public void ReturnToPool(Zombie zo)
    {
        Debug.Log(zombieQty);
        zo.gameObject.SetActive(false);
        amountOfZombiesSpawned--;
        zombieContainer.Enqueue(zo);
        //zombieQty += 3;
    }
    /*H�ll koll p� hur m�nga zombies som finns h�r. 
     */
     
}