using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPU_SimonPrototype : MonoBehaviour
{
    public ResourceManager rm;
    public SubsScript ss;

    private bool firstScrapPickedUp = true;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PickUpScrap()
    {

        
        if (firstScrapPickedUp)
        {
            Debug.Log("plockar upp");
            ss.scrapPickUpLine = true;
            
            firstScrapPickedUp = false;
           
        }
        rm.Offset(MyItem.Type.Scrap, 1);
        Debug.Log("totalt antal scraps " + rm.Get(MyItem.Type.Scrap));
        Destroy(gameObject);
    }
}
