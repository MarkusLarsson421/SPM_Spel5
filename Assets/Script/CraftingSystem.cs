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

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        infoText = canvas.AddComponent<Text>();
        upgradeButton = canvas.AddComponent<Button>();
        upgradeButton.enabled = false;
        infoText.font = font;
        infoText.enabled = false;
    }

    public void ToggleCraftingBench()
    {
        if (!isToggled)
        {
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
        }
        
    }
    /*
    private void damageUpgrade()
    {
        player.GetComponent<Weapon>().SetDamage(player.GetComponent<Weapon>().getDamage() + 5);
        //Ska göra så pistolen gör mer skada
    }

    private void flashLightUpgrade()
    {
        //ska göra så ficklampans batterie räcker längre(eller nåt)
    }
    */
}
