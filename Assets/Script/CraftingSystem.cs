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
        //Ska g�ra s� pistolen g�r mer skada
    }

    private void flashLightUpgrade()
    {
        //ska g�ra s� ficklampans batterie r�cker l�ngre(eller n�t)
    }
}
