using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*@Author Axel Sterner
 * Databehållare för föremål som ska spawnas med object pooling.
 */
public class PickupPool : MonoBehaviour
{
    [SerializeField] private GameObject batteryPrefab, ammoPrefab, scrapPrefab;


    private Queue<GameObject> pickupContainer = new Queue<GameObject>();
    public static PickupPool Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
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

                case 5:
                    GameObject scrap = Instantiate(scrapPrefab);
                    scrap.gameObject.SetActive(false);
                    pickupContainer.Enqueue(scrap);
                    break;

                default:
                    break;
            }
        }
    }

    public void ReturnToPool(GameObject pickupToReturn)
    {
        pickupToReturn.gameObject.SetActive(false);
        pickupContainer.Enqueue(pickupToReturn);
    }
}
