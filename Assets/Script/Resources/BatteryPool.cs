using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*@Author Axel Sterner
 * Databehållare för batteri-objekt som ska spawnas med object pooling.
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
            BPU_SimonPrototype batt = Instantiate(batteryPrefab);
            batt.gameObject.SetActive(false);
            batteryContainer.Enqueue(batt);
        }
    }

    public void ReturnToPool(BPU_SimonPrototype battery)
    {
        battery.gameObject.SetActive(false);
        batteryContainer.Enqueue(battery);
    }
}
