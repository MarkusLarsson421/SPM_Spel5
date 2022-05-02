using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPU_SimonPrototype : MonoBehaviour
{
    public ResourceManager rm;
    private int maxBatteries = 5;
    
    public void PickUpBatteries()
    {
        if(rm.Get(MyItem.Type.Batteries) != maxBatteries)
        {
            rm.Offset(MyItem.Type.Batteries, 1);
            Debug.Log("mängd batterier " + rm.Get(MyItem.Type.Batteries));
            Destroy(gameObject);
        }
        
    }
}
