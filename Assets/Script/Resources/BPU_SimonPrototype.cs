using UnityEngine;

public class BPU_SimonPrototype : MonoBehaviour
{
    public ResourceManager rm;
    public SubsScript ss;
    private int maxBatteries = 1;
    
    public void PickUpBatteries()
    {
        if(rm.Get(ResourceManager.ItemType.Battery) != maxBatteries)
        {
            rm.Offset(ResourceManager.ItemType.Battery, 1);
            Debug.Log("m?ngd batterier " + rm.Get(ResourceManager.ItemType.Battery));
        }

      /*  if (ss != null && ss.GetFirstBatteryPickUp())
        {
            Debug.Log("funkar");
            ss.batteryFirstPickUp = true;
            Debug.Log(ss.GetFirstBatteryPickUp());
            ss.SetFirstBatteryPickUp(false);

        }*/

    }
}
