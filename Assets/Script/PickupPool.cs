using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*@Author Axel Sterner
 * Databehållare för föremål som ska spawnas med object pooling.
 */
public class PickupPool : MonoBehaviour
{
    [SerializeField] private GameObject batteryPrefab, ammoPrefab, scrapPrefab;
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject[] scraps;
    private int amountOfScraps;


    private Queue<GameObject> pickupContainer = new Queue<GameObject>();
    public static PickupPool Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        amountOfScraps = 3;
        scraps = GameObject.FindGameObjectsWithTag("Scrap");
        foreach(GameObject go in scraps)
        {
            go.SetActive(false);
        }
        SetScrapsActive();
        //AddPickups(1);
    }

    public GameObject Get()
    {
        if (pickupContainer.Count == 0)
        {
            AddPickups(1);
        }

        return pickupContainer.Dequeue();
    }

    private void AddPickups(int count)
    {
        for (int i = 0; i < count; i++)
        {
            int randomItem = Random.Range(0, 3);
            switch (randomItem)
            {
                case 0:
                    GameObject batt = Instantiate(batteryPrefab);
                    batt.gameObject.SetActive(false);
                    pickupContainer.Enqueue(batt);
                    break;

                case 1:
                    GameObject ammo = Instantiate(ammoPrefab);
                    ammo.gameObject.SetActive(false);
                    pickupContainer.Enqueue(ammo);
                    break;

               /* case 5:
                    GameObject scrap = Instantiate(scrapPrefab);
                    scrap.gameObject.SetActive(false);
                    pickupContainer.Enqueue(scrap);
                    break;*/

                default:
                    break;
            }
        }
    }

    public void ReturnToPool(GameObject pickupToReturn)
    {
        MoveToRandomSpawnPoint(pickupToReturn);
        pickupToReturn.gameObject.SetActive(false);
        pickupContainer.Enqueue(pickupToReturn);
    }

    /**
     * @Author Martin Wallmark
     * Moves the item to a random itemSpawner
     */
    private void MoveToRandomSpawnPoint(GameObject pickUp)
    {
        int randomNumber = Random.Range(0, spawnPoints.Length);
        for(int i = 0; i < spawnPoints.Length; i++)
        {
            if(i == randomNumber)
            {
                pickUp.transform.position = spawnPoints[i].transform.position;
                spawnPoints[i].GetComponent<PickupObjectPooled>().SetAbleToSpawn(true);
            }
        }
    }

    /**
     * @author Martin Wallmark
     * aktiverar ett antal scraps som bestämms av amountOfScraps
     */

    public void SetScrapsActive()
    {
        for(int i = 0; i<amountOfScraps; i++)
        {
            scraps[i].SetActive(true);
        }
    }

    public void SetAmountOfScraps(int nAmountOfScraps)
    {
        amountOfScraps = nAmountOfScraps;
    }
}
