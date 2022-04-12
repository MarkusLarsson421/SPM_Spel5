using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnPoint : MonoBehaviour
{
    [SerializeField] private int maxAmountAtSpawnPoint;
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
        Instantiate(Zombie, new Vector3)
    }

    private int nrOfZombies()
    {

    }


}
