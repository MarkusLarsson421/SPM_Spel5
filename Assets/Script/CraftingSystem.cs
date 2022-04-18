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
    private GameObject player;
    private Text infoText;
    private bool isToggled;
    private Button upgradeButton;
    
    private GameObject damageUpgrade;
    private GameObject magazineUpgrade;
    private GameObject fireRateUpgrade;

    private bool hasUpgradedDamage;

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
            Debug.Log("toggled");
            infoText.enabled = true;
            upgradeButton.enabled = true;


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
            player.GetComponent<Weapon>().setDamage(player.GetComponent<Weapon>().getDamage() + 5);
            //Ska g�ra s� pistolen g�r mer skada
            print("HEYO");
            hasUpgradedDamage = true;
        }
        
    }

    private void flashLightUpgrade()
    {
        //ska g�ra s� ficklampans batterie r�cker l�ngre(eller n�t)
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
    
}
