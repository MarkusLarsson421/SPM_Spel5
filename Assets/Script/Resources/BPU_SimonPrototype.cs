using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPU_SimonPrototype : MonoBehaviour
{
    public ResourceManager rm;
    private int maxBatteries = 5;
    
    public void PickUpBatteries()
    {
        if(rm.GetCurrentBatteries() != maxBatteries)
        {
            rm.PickUpBatteries();
            Debug.Log("mängd batterier " + rm.GetCurrentBatteries());
            Destroy(gameObject);
        }
        
    }
}
