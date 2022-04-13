using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Axel Sterner
//Simon Hessling Oscarson

public class ResourceManager : MonoBehaviour
{
    private int ammo = 0;
    private int batteries = 0;
    private int scrapParts = 0;
    private int invSlots = 4;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void PickUp(GameObject g)
    {        
            if (g.CompareTag("Ammo"))
            {
                Debug.Log("ammo picked up");
                ammo++;
                invSlots--;
                Debug.Log(invSlots);
            }
            if (g.CompareTag("Battery"))
            {
                Debug.Log("battery picked up");
                batteries++;
                invSlots--;
                Debug.Log(invSlots);
            }
            if (g.CompareTag("Scrap"))
            {
                Debug.Log("scrap picked up");
                scrapParts++;
                invSlots--;
                Debug.Log(invSlots);
            }
    }

}
