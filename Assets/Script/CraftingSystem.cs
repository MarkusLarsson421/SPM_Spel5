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
        //Ska göra så pistolen gör mer skada
    }

    private void flashLightUpgrade()
    {
        //ska göra så ficklampans batterie räcker längre(eller nåt)
    }
}
