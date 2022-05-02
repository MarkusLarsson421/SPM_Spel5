using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPU_SimonPrototype : MonoBehaviour
{
    public ResourceManager rm;
    private int maxBatteries = 5;
    
    public void PickUpBatteries()
    {
        if(rm.Get(ResourceManager.ItemType.Batteries) != maxBatteries)
        {
            rm.Add(ResourceManager.ItemType.Batteries, 1);
            Debug.Log("mängd batterier " + rm.Get(ResourceManager.ItemType.Batteries));
            Destroy(gameObject);
        }
        
    }
}
