using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    private int ammo;
    private int batteries;
    private int scrapParts;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickUp(GameObject g)
    {
        Debug.Log("funkar");
        if (g.CompareTag("Ammo"))
        {
            Debug.Log("ammo picked up");
        }
        if (g.CompareTag("Battery"))
        {
            Debug.Log("battery picked up");
        }
        if (g.CompareTag("Scrap"))
        {
            Debug.Log("scrap picked up");
        }
    }

}
