using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Axel Sterner

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
    private int MINSCRAPPICKUP = 3;
    private int MAXSCRAPPICKUP = 6;
    
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
                if(wpn.getAmmo() == 100)
                {
                    return;
                }
                else
                {
                    AmmoHandler(g);
                    Destroy(g);
                }
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
        PickUpQuant = Random.Range(1, 15);//�ndra vid behov
       
    }

    private void AmmoHandler(GameObject g)
    {
        PickUpQuant = Random.Range(MINAMMOPICKUP, MAXAMMOPICKUP);
        Debug.Log("Antal: " + PickUpQuant);
        int currentAmmo = wpn.getAmmo();
        if(currentAmmo + PickUpQuant > 100)
        {
            wpn.resetAmmo();
            Debug.Log(wpn.getAmmo());
        }
        else
        {
            wpn.setAmmo(PickUpQuant);
            Debug.Log("Total ammo: " + wpn.getAmmo());
        }

    }

    private void ScrapHandler(GameObject g)
    {
        PickUpQuant = Random.Range(MINSCRAPPICKUP, MAXSCRAPPICKUP);
    }
    /*
     * 
     * */
}