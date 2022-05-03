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
    private Button upgradeButton;
    
    private GameObject damageUpgrade;
    private GameObject magazineUpgrade;
    private GameObject fireRateUpgrade;

    private bool hasUpgradedDamage;
    private bool hasMagazineSizeUpgrade;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        infoText = canvas.AddComponent<Text>();
        upgradeButton = canvas.AddComponent<Button>();
        upgradeButton.enabled = false;
        infoText.font = font;
        infoText.enabled = false;

        damageUpgrade = GameObject.Find("DamageUpgrade");
        magazineUpgrade = GameObject.Find("MagazineUpgrade");
        fireRateUpgrade = GameObject.Find("fireRateUpgrade");
        damageUpgrade.SetActive(false);
        magazineUpgrade.SetActive(false);
        fireRateUpgrade.SetActive(false);

    }

   

    public void ToggleCraftingBench()
    {
        toggleButtons();
        if (!isToggled)
        {
            Cursor.lockState = CursorLockMode.None;
            isToggled = true;
            //Debug.Log("toggled");
            infoText.enabled = true;
            upgradeButton.enabled = true;
            eventSystem.firstSelectedGameObject = magazineUpgrade;

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
        Debug.Log("hawt");
        if (!hasUpgradedDamage)
        {
            GameObject.FindWithTag("Pistol").GetComponentInChildren<Weapon>().SetDamage(30);
            //Ska göra så pistolen gör mer skada
            print("HEYO");
            hasUpgradedDamage = true;
        }
        
    }

    public void IncreaseMagazineSize()
    {
        if (!hasMagazineSizeUpgrade)
        {
            player.GetComponent<Weapon>().SetMagCapacity(12);
        }
    }

    private void flashLightUpgrade()
    {
        //ska göra så ficklampans batterie räcker längre(eller nåt)
    }

    private void toggleButtons()
    {
        if (!isToggled)
        {
            if (!hasUpgradedDamage)
            {
                damageUpgrade.SetActive(true);
            }
            
            magazineUpgrade.SetActive(true);
            fireRateUpgrade.SetActive(true);
        }
        else
        {
            damageUpgrade.SetActive(false);
            magazineUpgrade.SetActive(false);
            fireRateUpgrade.SetActive(false);
        }
    }

    private void voidChooseUpgrade()
    {
        if (Input.GetKeyDown("1"))
        {
            DamageUpgrade();
        }
    }
    
}
