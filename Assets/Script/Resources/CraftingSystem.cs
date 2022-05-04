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
        
        damageUpgrade.SetActive(false);
        magazineUpgrade.SetActive(false);
        flashlightUpgrade.SetActive(false);
    }

    public void ToggleCraftingBench()
    {
        
        toggleButtons();
        if (!isToggled)
        {
            Cursor.lockState = CursorLockMode.None;
            isToggled = true;
            infoText.enabled = true;
            chooseSelectedButton();
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
        if(inter.interactingGameObject.GetComponentInChildren<ResourceManager>().Get(MyItem.Type.Batteries) >= 2 && inter.interactingGameObject.GetComponentInChildren<ResourceManager>().Get(MyItem.Type.Scrap) >= 2)
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
        if (!hasMagazineSizeUpgrade && inter.interactingGameObject.GetComponentInChildren<ResourceManager>().Get(MyItem.Type.Batteries) >= 1 && inter.interactingGameObject.GetComponentInChildren<ResourceManager>().Get(MyItem.Type.Scrap) >= 3)
        {
            inter.interactingGameObject.GetComponentInChildren<ResourceManager>().DecreaseItem(MyItem.Type.Batteries, 1);
            inter.interactingGameObject.GetComponentInChildren<ResourceManager>().DecreaseItem(MyItem.Type.Scrap, 3);
            GameObject.FindWithTag("Pistol").GetComponentInChildren<Weapon>().SetMagCapacity(12);
            hasMagazineSizeUpgrade = true;
            Debug.Log("mhm");
            Debug.Log(inter.interactingGameObject.transform.parent.tag);
        }
        else
        {
            Debug.Log("Need more items pal");
        }
    }

    public void flashLightUpgrade()
    {
        //gör så att ficklampans batterie räcker längre
        if (!hasFlashlightUpgrade && inter.interactingGameObject.GetComponentInChildren<ResourceManager>().Get(MyItem.Type.Batteries) >= 3 && inter.interactingGameObject.GetComponentInChildren<ResourceManager>().Get(MyItem.Type.Scrap) >= 1)
        {
            inter.interactingGameObject.GetComponentInChildren<ResourceManager>().DecreaseItem(MyItem.Type.Batteries, 3);
            inter.interactingGameObject.GetComponentInChildren<ResourceManager>().DecreaseItem(MyItem.Type.Scrap, 1);
            GameObject.FindWithTag("Flashlight").GetComponent<FlashLight>().SetDrainMultiplier(0.05);
            hasFlashlightUpgrade = true;
            flashlightUpgrade.SetActive(false);
            chooseSelectedButton();
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
            if (damageUpgradedPlayers.Count==0 || !damageUpgradedPlayers.Contains(inter.interactingGameObject.transform.parent.tag))
            {
                damageUpgrade.SetActive(true);
            }
            if (!hasMagazineSizeUpgrade)
            {
                magazineUpgrade.SetActive(true);
            }
            if (!hasFlashlightUpgrade)
            {
                flashlightUpgrade.SetActive(true);
            }
        }
        else
        {
            damageUpgrade.SetActive(false);
            magazineUpgrade.SetActive(false);
            flashlightUpgrade.SetActive(false);
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


}
