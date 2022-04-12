using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnPoint : MonoBehaviour
{
    public Transform target;
    [SerializeField] private GameObject zombie;
    [SerializeField] private int maxAmountAtSpawnPoint;
    private int randomAmountOfZombies;
    


    public void Spawn()
    {
        NrOfZombies();
        for(int i = 0; i < randomAmountOfZombies; i++)
        {
            GameObject go = Instantiate(zombie, this.transform);
            go.GetComponent<Zombie>().SetTarget(target);
        }

    }

    private void NrOfZombies()
    {
        randomAmountOfZombies = Random.Range(0, maxAmountAtSpawnPoint);
        
    }

    public void SetMaxZombies(int amount)
    {
        maxAmountAtSpawnPoint = amount;
    }


}
