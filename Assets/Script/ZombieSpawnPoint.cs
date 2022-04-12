using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnPoint : MonoBehaviour
{
    [SerializeField] private int maxAmountAtSpawnPoint;
    [SerializeField] private GameObject zombie;
    private int randomNr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Spawn()
    {
        nrOfZombies();
        for(int i = 0; i < maxAmountAtSpawnPoint; i++)
        {
            Instantiate(zombie, this.transform);
        }

    }

    private void nrOfZombies()
    {
        int randomNr = Random.Range(0, maxAmountAtSpawnPoint);
        
    }


}
