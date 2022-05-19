using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.EventSystems;

public class WinGame_SimonPrototype : MonoBehaviour
{
    public ResourceManager rm;
    public CanvasHandler ch;
    [SerializeField] private TMP_Text scrapsInCarText;
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private GameObject theButton;
    private int scrapsInCar;
    private int scrapsNeededToFixCar = 14;
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
        scrapsInCarText.text = "scraps in car " + scrapsInCar + " / " + scrapsNeededToFixCar;
        if (scrapsInCar >= scrapsNeededToFixCar)
        {
            
            ch.ChangeCanvasToWinCanvas();
            eventSystem.SetSelectedGameObject(theButton);
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
            ch.ChangeCanvasToWinCanvas();
            Debug.Log("u won the game");
        }
    }
}
