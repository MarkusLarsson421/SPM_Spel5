using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnPoint : MonoBehaviour
{
    
    [SerializeField] private GameObject zombie;
    [SerializeField] private int maxAmountAtSpawnPoint;
    private int randomNr;
    


    public void Spawn()
    {
        NrOfZombies();
        for(int i = 0; i < maxAmountAtSpawnPoint; i++)
        {
            Instantiate(zombie, this.transform);
        }

    }

    private void NrOfZombies()
    {
        int randomNr = Random.Range(0, maxAmountAtSpawnPoint);
        
    }

    public void SetMaxZombies(int amount)
    {
        maxAmountAtSpawnPoint = amount;
    }


}
