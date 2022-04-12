using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnPoint : MonoBehaviour
{
    [SerializeField] private int maxAmountAtSpawnPoint;
    private int rNr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void Spawn()
    {
        nrOfZombies();
        for(int i = 0; i < maxAmountAtSpawnPoint; i++)
        {

        }
        //Instantiate(Zombie, new Vector3)
    }

    private void nrOfZombies()
    {
        int rNr = Random.Range(0, maxAmountAtSpawnPoint);
        
    }


}
