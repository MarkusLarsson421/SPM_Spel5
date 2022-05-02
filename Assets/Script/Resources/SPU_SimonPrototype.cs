using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPU_SimonPrototype : MonoBehaviour
{
    public ResourceManager rm;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PickUpScrap()
    {
        rm.Add(ResourceManager.ItemType.Scrap, 1);
        Debug.Log("totalt antal scraps " + rm.Get(ResourceManager.ItemType.Scrap));
        Destroy(gameObject);
    }
}
