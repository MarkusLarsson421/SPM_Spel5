using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Martin Wallmark
public class CraftingSystem : MonoBehaviour
{
    [SerializeField] private int scrapAmountNeeded;
    [SerializeField] private GameObject canvas;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void ToggleCraftingBench()
    {
        Debug.Log("toggled");
        Text infoText = canvas.AddComponent<Text>();
        infoText.text = "Craft hehe";
    }

    private void damageUpgrade()
    {
        player.GetComponent<Weapon>().SetDamage(player.GetComponent<Weapon>().getDamage() + 5);
        //Ska göra så pistolen gör mer skada
    }

    private void flashLightUpgrade()
    {
        //ska göra så ficklampans batterie räcker längre(eller nåt)
    }
}
