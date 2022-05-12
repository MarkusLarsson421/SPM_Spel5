using UnityEngine;
using System.Collections;

public class WinGame_SimonPrototype : MonoBehaviour
{
    public ResourceManager rm;
    public CanvasHandler ch;
    private int scrapsInCar;
    private int scrapsNeededToFixCar = 1;
    private bool isClicked;


    private void Update()
    {
        if (isClicked)
        {
            AddScrapsToCar();
            isClicked = false;
        }
    }
    public void CarInteraction()
    {
        isClicked = true;
    }
    public void AddScrapsToCar()
    {
        //wait();
        Debug.Log("test132");
       scrapsInCar += rm.Get(ResourceManager.ItemType.Scrap);
      
       rm.SetTotal(ResourceManager.ItemType.Scrap, 0);
        Debug.Log("rm scraps = " + rm.Get(ResourceManager.ItemType.Scrap) + " scrapsInCar = " + scrapsInCar);
        if (scrapsInCar >= scrapsNeededToFixCar)
        {
            ch.ChangeCanvasToDeathCanvas();
            Debug.Log("u won the game");
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1f);

        Debug.Log("test132");
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
