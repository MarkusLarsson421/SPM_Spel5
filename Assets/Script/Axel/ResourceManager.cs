using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Axel Sterner
//Simon Hessling Oscarson

public class ResourceManager : MonoBehaviour
{
    private int scrapCount, batteryCount;
    private int ammoCap = 100;
    private int scrapCap = 10;
    private int batteryCap = 3; //maxantal
    private int PickUpQuant;
    private string itemTag;
    public Weapon wpn;

    private int MINAMMOPICKUP = 10;
    private int MAXAMMOPICKUP = 40;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void PickUp(GameObject g)
    {
        itemTag = g.tag;
        switch (itemTag)
        {
            case "Ammo":
                AmmoHandler(g);
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
       
    }

    private void AmmoHandler(GameObject g)
    {
        Debug.Log("funkar");
        int currentAmmo = wpn.getAmmo();
        if(currentAmmo >= ammoCap)
        {
            wpn.SetAmmo(100);
        }
        else
        {
            PickUpQuant = Random.Range(MINAMMOPICKUP, MAXAMMOPICKUP);
            wpn.SetAmmo(PickUpQuant);

        }

    }
}
