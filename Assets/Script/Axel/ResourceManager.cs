using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Axel Sterner
//Simon Hessling Oscarson

public class ResourceManager : MonoBehaviour
{
    private int ammo;
    private int batteries;
    private int scrapParts;
    private int invSlots;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void PickUp(GameObject g)
    {
        while(invSlots >= 1)
        {
            if (g.CompareTag("Ammo"))
            {
                Debug.Log("ammo picked up");
                ammo++;
                invSlots--;
            }
            if (g.CompareTag("Battery"))
            {
                Debug.Log("battery picked up");
                batteries++;
                invSlots--;
            }
            if (g.CompareTag("Scrap"))
            {
                Debug.Log("scrap picked up");
                scrapParts++;
                invSlots--;
            }
        }
        
    }

}
