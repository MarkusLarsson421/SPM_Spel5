using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
        damageUpgrade.active = false;
        magazineUpgrade.active = false;
        fireRateUpgrade.active = false;

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
        //player.GetComponent<Weapon>().SetDamage(player.GetComponent<Weapon>().getDamage() + 5);
        //Ska göra så pistolen gör mer skada
        Debug.Log("+1");
    }

    private void flashLightUpgrade()
    {
        //ska göra så ficklampans batterie räcker längre(eller nåt)
    }

    private void toggleButtons()
    {
        if (!isToggled)
        {
            damageUpgrade.active = true;
            magazineUpgrade.active = true;
            fireRateUpgrade.active = true;
        }
        else
        {
            damageUpgrade.active = false;
            magazineUpgrade.active = false;
            fireRateUpgrade.active = false;
        }
    }
    
}
