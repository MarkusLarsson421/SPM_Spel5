using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
//Martin Wallmark
public class CraftingSystem : MonoBehaviour
{
    public ResourceManager rm;
    [SerializeField] private int scrapAmountNeeded;
    [SerializeField] private GameObject canvas;
    [SerializeField] private Font font;
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private Interactable inter; //TEST

    [SerializeField] private string playah;
    private GameObject player;
    private Text infoText;
    private bool isToggled;

    [SerializeField] private List<string> damageUpgradedPlayers = new List<string>();
    private List<string> MagazineUpgradedPlayers = new List<string>();
    private List<string> flashLightUpgradedPlayers = new List<string>();


    private GameObject damageUpgrade;
    private GameObject magazineUpgrade;
    private GameObject flashlightUpgrade;
    private GameObject cancelButton;

    private GameObject choiceYes;
    private GameObject choiceNo;

    

    private bool hasUpgradedDamage;
    private bool hasMagazineSizeUpgrade;
    private bool hasFlashlightUpgrade;

    private void Start()
    {
        
        infoText = canvas.AddComponent<Text>();
        infoText.font = font;
        infoText.enabled = false;
       

        damageUpgrade = GameObject.Find("DamageUpgrade");
        magazineUpgrade = GameObject.Find("MagazineUpgrade");
        flashlightUpgrade = GameObject.Find("fireRateUpgrade");
        cancelButton = GameObject.Find("CancelButton");
        choiceYes = GameObject.Find("choiceYes");
        choiceNo = GameObject.Find("choiceNo");
        
        damageUpgrade.SetActive(false);
        magazineUpgrade.SetActive(false);
        flashlightUpgrade.SetActive(false);
        cancelButton.SetActive(false);
        choiceYes.SetActive(false);
        choiceNo.SetActive(false);
    }

    public void ToggleCraftingBench()
    {

        toggleButtons();
        if (!isToggled)
        {
            //choiceNo.SetActive(true);
            //choiceYes.SetActive(true);
            //eventSystem.SetSelectedGameObject(choiceNo);
            //playah = inter.interactingGameObject.transform.parent.tag;
            
            Cursor.lockState = CursorLockMode.None;
            isToggled = true;
            infoText.enabled = true;
            //chooseSelectedButton();
            eventSystem.SetSelectedGameObject(cancelButton);
            Debug.Log(damageUpgradedPlayers.Count);

            if(hasFlashlightUpgrade && hasMagazineSizeUpgrade && hasUpgradedDamage)
            {
                infoText.text = "No more upgrades available :(";
            }
            else
            {
                infoText.text = "Craft hehe";
            }
        }
        else
        {
            isToggled = false;
            infoText.enabled = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    public void DamageUpgrade()
    {
        if (damageUpgradedPlayers.Contains(inter.interactingGameObject.transform.parent.tag)){
            Debug.Log("You already have this upgrade!");
        }
        else if(inter.interactingGameObject.GetComponentInChildren<ResourceManager>().Get(MyItem.Type.Batteries) >= 2 && inter.interactingGameObject.GetComponentInChildren<ResourceManager>().Get(MyItem.Type.Scrap) >= 2)
        {
            inter.interactingGameObject.GetComponentInChildren<ResourceManager>().DecreaseItem(MyItem.Type.Batteries, 2);
            inter.interactingGameObject.GetComponentInChildren<ResourceManager>().DecreaseItem(MyItem.Type.Scrap, 2);
            //Gör så pistoler gör mer skada
            GameObject.FindWithTag("Pistol").GetComponentInChildren<Weapon>().SetDamage(35);
            print("HEYO");
            //hasUpgradedDamage = true;
            damageUpgradedPlayers.Add(inter.interactingGameObject.transform.parent.tag);
            Debug.Log(damageUpgradedPlayers.Contains("Player1"));
            
        }
        else
        {
            Debug.Log("Too few batteries pal");
            Debug.Log(inter.interactingGameObject.transform.parent.tag);
            
        }
        



    }

    public void IncreaseMagazineSize()
    {
        //Gör så att vapnets magasin kan ha fler patroner
        if (MagazineUpgradedPlayers.Contains(inter.interactingGameObject.transform.parent.tag))
        {
            Debug.Log("You already have this upgrade!");
        }
        else if (!hasMagazineSizeUpgrade && inter.interactingGameObject.GetComponentInChildren<ResourceManager>().Get(MyItem.Type.Batteries) >= 1 && inter.interactingGameObject.GetComponentInChildren<ResourceManager>().Get(MyItem.Type.Scrap) >= 3)
        {
            inter.interactingGameObject.GetComponentInChildren<ResourceManager>().DecreaseItem(MyItem.Type.Batteries, 1);
            inter.interactingGameObject.GetComponentInChildren<ResourceManager>().DecreaseItem(MyItem.Type.Scrap, 3);
            GameObject.FindWithTag("Pistol").GetComponentInChildren<Weapon>().SetMagCapacity(12);
            //hasMagazineSizeUpgrade = true;
            MagazineUpgradedPlayers.Add(inter.interactingGameObject.transform.parent.tag);
            
        }
        else
        {
            Debug.Log("Need more items pal");
        }
    }

    public void flashLightUpgrade()
    {
        if (flashLightUpgradedPlayers.Contains(inter.interactingGameObject.transform.parent.tag))
        {
            Debug.Log("You already have this upgrade!");
        }
        //gör så att ficklampans batterie räcker längre
        else if (!hasFlashlightUpgrade && inter.interactingGameObject.GetComponentInChildren<ResourceManager>().Get(MyItem.Type.Batteries) >= 3 && inter.interactingGameObject.GetComponentInChildren<ResourceManager>().Get(MyItem.Type.Scrap) >= 1)
        {
            inter.interactingGameObject.GetComponentInChildren<ResourceManager>().DecreaseItem(MyItem.Type.Batteries, 3);
            inter.interactingGameObject.GetComponentInChildren<ResourceManager>().DecreaseItem(MyItem.Type.Scrap, 1);
            GameObject.FindWithTag("Flashlight").GetComponent<FlashLight>().SetDrainMultiplier(0.05);
            //hasFlashlightUpgrade = true;
            //flashlightUpgrade.SetActive(false);
            flashLightUpgradedPlayers.Add(inter.interactingGameObject.transform.parent.tag);
            Debug.Log(inter.interactingGameObject.transform.parent.tag);
        }
        else
        {
            Debug.Log("Need more items pal");
        }
        
    }

    private void toggleButtons()
    {
       // string key = inter.interactingGameObject.transform.parent.tag;
        if (!isToggled)
        {
            cancelButton.SetActive(true);
            damageUpgrade.SetActive(true);
            /*
            if (damageUpgradedPlayers.Count==0 || !damageUpgradedPlayers.Contains(inter.interactingGameObject.transform.parent.tag))
            {
                
            }
            */
            magazineUpgrade.SetActive(true);
            flashlightUpgrade.SetActive(true);
            
        }
        else
        {
            damageUpgrade.SetActive(false);
            magazineUpgrade.SetActive(false);
            flashlightUpgrade.SetActive(false);
            cancelButton.SetActive(false);
        }
    }

    private void chooseSelectedButton()
    {
        if(hasMagazineSizeUpgrade && !hasUpgradedDamage && !hasFlashlightUpgrade)
        {
            eventSystem.SetSelectedGameObject(damageUpgrade);
        }
        else if (hasMagazineSizeUpgrade && hasUpgradedDamage)
        {
            eventSystem.SetSelectedGameObject(flashlightUpgrade);
        }
        else if(hasMagazineSizeUpgrade && hasFlashlightUpgrade)
        {
            eventSystem.SetSelectedGameObject(damageUpgrade);
        }
        else
            eventSystem.SetSelectedGameObject(magazineUpgrade);
    }

    public void exitCrafting()
    {
        ToggleCraftingBench();
    }

    //private void ShowUpgradeButtons()


}
