using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.EventSystems;

public class WinGame_SimonPrototype : MonoBehaviour
{
    public ResourceManager rm;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private SubsScript ss;
    [SerializeField] private TMP_Text scrapsInCarText;
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private GameObject theButton;
    private int scrapsInCar;
    private int scrapsNeededToFixCar = 12;
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
        
            scrapsInCar += rm.Get(ResourceManager.ItemType.Scrap);


            rm.SetTotal(ResourceManager.ItemType.Scrap, 0);
            Debug.Log("rm scraps = " + rm.Get(ResourceManager.ItemType.Scrap) + " scrapsInCar = " + scrapsInCar);
            scrapsInCarText.text = "in car " + scrapsInCar + " / " + scrapsNeededToFixCar;
            if (scrapsInCar >= scrapsNeededToFixCar)
            {

                winPanel.SetActive(true);
                eventSystem.SetSelectedGameObject(theButton);
                Debug.Log("u won the game");
            }
        }
    }
        

   

