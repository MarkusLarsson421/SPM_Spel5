using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnSystem : MonoBehaviour
{

    [SerializeField] private GameObject battery;
    [SerializeField] private GameObject scrap;
    [SerializeField] private GameObject ammo;

    [SerializeField] private Transform[] itemSpawnPoints;
    [SerializeField] private Transform idleSpawnPoint;

    List<GameObject> batteries = new List<GameObject>();
    List<GameObject> scraps = new List<GameObject>();
    List<GameObject> ammos = new List<GameObject>();
    //private Dictionary<string, GameObject[]> items;
    // Start is called before the first frame update
    void Start()
    {
        startAmountOFItems(10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void startAmountOFItems(int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            GameObject ammoObject = Instantiate(ammo, idleSpawnPoint);
            GameObject scrapObject = Instantiate(scrap, idleSpawnPoint);
            GameObject batteryObject = Instantiate(battery, idleSpawnPoint);
            ammos.Add(ammoObject);
            scraps.Add(scrapObject);
            batteries.Add(batteryObject);
        }
    }


    private void spawnItem()
    {

    }
}
