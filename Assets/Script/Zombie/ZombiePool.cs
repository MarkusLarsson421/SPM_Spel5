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
    [SerializeField] private Zombie zPrefab;
    public int amountOfZombiesSpawned; //@Author Simon Hessling Oscarsson, görs ++ varje gång en zombie spawnar.
    private Queue<Zombie> zombieContainer = new Queue<Zombie>(10);
    private int zombieQty = 4;
    private System.Random rnd = new System.Random();

    public static ZombiePool Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
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
        {
            float randomXValue = (float)rnd.NextDouble() % 4;
            Vector3 distCorrection = new Vector3(randomXValue, 2.4f);
            Zombie zo = Instantiate(zPrefab, distCorrection, Quaternion.identity);
            zo.gameObject.SetActive(true);//false
            zombieContainer.Enqueue(zo);
        }
    }

    public void ReturnToPool(Zombie zo)
    {
        Debug.Log(zombieQty);
        zo.gameObject.SetActive(false);
        amountOfZombiesSpawned--;
        zombieContainer.Enqueue(zo);
        //zombieQty += 3;
    }
    /*Håll koll på hur många zombies som finns här. 
     */
     
}
