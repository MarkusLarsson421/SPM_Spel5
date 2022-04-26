using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame_SimonPrototype : MonoBehaviour
{
    public RM rm;
    public CanvasHandler ch;
    private int scrapsInCar;
    private int scrapsNeededToFixCar = 4;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScrapsToCar()
    {
       scrapsInCar += rm.GetCurrentScraps();
      
       rm.SetCurrentScrap(0);
        Debug.Log("rm scraps = " + rm.GetCurrentScraps() + " scrapsInCar = " + scrapsInCar);
        if (scrapsInCar >= scrapsNeededToFixCar)
        {
            ch.ChangeCanvasToDeathCanvas();
            Debug.Log("u won the game");
        }
    }
}
