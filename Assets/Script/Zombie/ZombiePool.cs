using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*@Author Axel Sterner
 * Databehållare för zombie-objekt som ska spawnas med object pooling.
 */
public class ZombiePool : MonoBehaviour
{
    [SerializeField] private Zombie zPrefab;

    private Queue<Zombie> zombieContainer = new Queue<Zombie>();
    public static ZombiePool Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    public Zombie Get()
    {
        if (zombieContainer.Count == 0)
        {
            AddZombies(1);
        }
        return zombieContainer.Dequeue();
    }

    private void AddZombies(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Zombie zo = Instantiate(zPrefab);
            zo.gameObject.SetActive(false);
            zombieContainer.Enqueue(zo);
        }
    }

    public void ReturnToPool(Zombie zo)
    {
        zo.gameObject.SetActive(false);
        zombieContainer.Enqueue(zo);
    }
}
