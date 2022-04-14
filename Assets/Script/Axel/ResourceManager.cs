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
    /*spelaren ska inte kunna plocka upp ammo när den har max ammo
     * 
     * */
}
