using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*@Author Axel Sterner
 * Databehållare för batteri-objekt som ska spawnas med object pooling.
 * 
 * PickupPool som innehåller en kö med GameObjects. Get() tar emot gameobjects och lägger till en av varje prefab. Tre olika add-metoder (för batteri, scraps och ammo) och slutligen ReturnToPool som tar emot gameobject
 */
public class BatteryPool : MonoBehaviour
{
    [SerializeField] private BPU_SimonPrototype batteryPrefab;

    private Queue<BPU_SimonPrototype> batteryContainer = new Queue<BPU_SimonPrototype>();
    public static BatteryPool Instance { get; private set; }
    
    private void Awake()
    {
        Instance = this;
    }

    public BPU_SimonPrototype Get()
    {
        if (batteryContainer.Count == 0)
        {
            AddBatteries(1);
        }

        return batteryContainer.Dequeue();
    }

    private void AddBatteries(int count)
    {
        for(int i = 0; i < count; i++)
        {
            int randomItem = Random.Range(0,2);
            if(randomItem == 0)
            {
                BPU_SimonPrototype batt = Instantiate(batteryPrefab);
            }
            if (randomItem == 1)
            {
                //ammo
            }
            if (randomItem == 2)
            {
                //scraps
            }
            
            /*batt.gameObject.SetActive(false);
            batteryContainer.Enqueue(batt);*/
        }
    }

    public void ReturnToPool(BPU_SimonPrototype battery)
    {
        battery.gameObject.SetActive(false);
        batteryContainer.Enqueue(battery);
    }
}
