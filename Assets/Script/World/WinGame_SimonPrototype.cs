using UnityEngine;

public class WinGame_SimonPrototype : MonoBehaviour
{
    public ResourceManager rm;
    public CanvasHandler ch;
    private int scrapsInCar;
    private int scrapsNeededToFixCar = 25;

    public void AddScrapsToCar()
    {
       scrapsInCar += rm.Get(ResourceManager.ItemType.Scrap);
      
       rm.SetTotal(ResourceManager.ItemType.Scrap, 0);
        Debug.Log("rm scraps = " + rm.Get(ResourceManager.ItemType.Scrap) + " scrapsInCar = " + scrapsInCar);
        if (scrapsInCar >= scrapsNeededToFixCar)
        {
            ch.ChangeCanvasToDeathCanvas();
            Debug.Log("u won the game");
        }
    }
}
