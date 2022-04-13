using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Axel Sterner
//Simon Hessling Oscarson

public class ResourceManager : MonoBehaviour
{
    private int invSize = 32;
    private int ammoCount, scrapCount, batteryCount;
    private int PickUpQuant;
    private string itemTag;
    Weapon wpn;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

   /* public void PickUp(GameObject g)
    {
        //switch med handler för varje objekt
            if (g.CompareTag("Ammo"))
            {
                ammo++;
                invSlots--;
                Debug.Log(invSlots);
            }
            if (g.CompareTag("Battery"))
            {
                Debug.Log("battery picked up");
            }
            if (g.CompareTag("Scrap"))
            {
                Debug.Log("scrap picked up");
            }
    }*/

    public void PickUp(GameObject g)
    {
        itemTag = g.tag;
        switch (itemTag)
        {
            case "Ammo":
                ItemHandler(g);
                ammoCount += PickUpQuant;
                Debug.Log("Quantity: " + PickUpQuant);
                break;

            case "Scrap":
                ItemHandler(g);
                scrapCount += PickUpQuant;
                Debug.Log("Quantity: " + PickUpQuant);
                break;

            case "Battery":
                ItemHandler(g);
                batteryCount += PickUpQuant;
                Debug.Log("Quantity: " + PickUpQuant);
                break;
        }
    }
   
    private void ItemHandler(GameObject g)
    {
        PickUpQuant = Random.Range(1, 15);//ändra vid behov
        invSize -= PickUpQuant;
    }

    private void AmmoHandler(GameObject g)
    {
        PickUpQuant = Random.Range(1, 15);
        invSize -= PickUpQuant;
        
    }
}
