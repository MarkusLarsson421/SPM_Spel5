using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
//Martin Wallmark
public class CraftingSystem : MonoBehaviour
{
    [SerializeField] private int scrapAmountNeeded;
    [SerializeField] private GameObject canvas;
    [SerializeField] private Font font;
    [SerializeField] private EventSystem eventSystem;
    private GameObject player;
    private Text infoText;
    private bool isToggled;
    
    
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

            infoText.text = "Craft hehe";
            
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
        if (!hasUpgradedDamage)
        {

            //Gör så pistoler gör mer skada
            GameObject.FindWithTag("Pistol").GetComponentInChildren<Weapon>().SetDamage(35);
            print("HEYO");
            hasUpgradedDamage = true;
        }
        
    }

    public void IncreaseMagazineSize()
    {
        //Gör så att vapnets magasin kan ha fler patroner
        if (!hasMagazineSizeUpgrade)
        {
            GameObject.FindWithTag("Pistol").GetComponentInChildren<Weapon>().SetMagCapacity(12);
            hasMagazineSizeUpgrade = true;
            Debug.Log("mhm");
        }
    }

    public void flashLightUpgrade()
    {
        //gör så att ficklampans batterie räcker längre
        if (!hasFlashlightUpgrade)
        {
            GameObject.FindWithTag("Flashlight").GetComponent<FlashLight>().SetDrainMultiplier(0.05);
            hasFlashlightUpgrade = true;
        }
        
    }

    private void toggleButtons()
    {
        if (!isToggled)
        {
            if (!hasUpgradedDamage)
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
        if(hasMagazineSizeUpgrade && !hasUpgradedDamage)
        {
            eventSystem.SetSelectedGameObject(damageUpgrade);
        }
        if (hasMagazineSizeUpgrade && hasUpgradedDamage)
        {
            eventSystem.SetSelectedGameObject(flashlightUpgrade);
        }
        else
            eventSystem.SetSelectedGameObject(magazineUpgrade);
    }
}
