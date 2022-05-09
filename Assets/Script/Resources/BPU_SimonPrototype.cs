using UnityEngine;

public class BPU_SimonPrototype : MonoBehaviour
{
    public ResourceManager rm;
    private int maxBatteries = 5;
    
    public void PickUpBatteries()
    {
        if(rm.Get(ResourceManager.ItemType.Battery) != maxBatteries)
        {
            rm.Offset(ResourceManager.ItemType.Battery, 1);
            Debug.Log("mängd batterier " + rm.Get(ResourceManager.ItemType.Battery));
            Destroy(gameObject);
        }
        
    }
}
