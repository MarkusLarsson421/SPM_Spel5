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
    /*H�ll koll p� hur m�nga zombies som finns h�r. 
     */
     
}
