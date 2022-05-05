using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame_SimonPrototype : MonoBehaviour
{
    public ResourceManager rm;
    public CanvasHandler ch;
    private int scrapsInCar;
    private int scrapsNeededToFixCar = 25;

    public void AddScrapsToCar()
    {
       scrapsInCar += rm.Get(MyItem.Type.Scrap);
      
       rm.SetTotal(MyItem.Type.Scrap, 0);
        Debug.Log("rm scraps = " + rm.Get(MyItem.Type.Scrap) + " scrapsInCar = " + scrapsInCar);
        if (scrapsInCar >= scrapsNeededToFixCar)
        {
            ch.ChangeCanvasToDeathCanvas();
            Debug.Log("u won the game");
        }
    }
}
