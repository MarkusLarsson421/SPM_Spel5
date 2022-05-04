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
    public static ZombiePool Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    public Zombie Get()
    {
        if(zombieContainer.Count == 0)
        {
            AddZombies(1);
        }
        zombieContainer.Peek().SetHealth(100);
        Debug.Log("Zombie hp: " + zombieContainer.Peek().GetHealth());
        amountOfZombiesSpawned++;

        return zombieContainer.Dequeue();
    }

    private void AddZombies(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Zombie zo = Instantiate(zPrefab);
            zo.gameObject.SetActive(false);
            zombieContainer.Enqueue(zo);
            //amountOfZombiesSpawned++;
        }
    }

    public void ReturnToPool(Zombie zo)
    {
       // Debug.Log(amountOfZombiesSpawned);
        zo.gameObject.SetActive(false);
        amountOfZombiesSpawned--;
        zombieContainer.Enqueue(zo);
    }
    /*Håll koll på hur många zombies som finns här. 
     */
     
}
