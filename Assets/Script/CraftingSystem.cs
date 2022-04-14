using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Martin Wallmark
public class CraftingSystem : MonoBehaviour
{
    [SerializeField] int scrapAmountNeeded;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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
