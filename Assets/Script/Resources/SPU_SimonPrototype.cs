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
        rm.Offset(MyItem.Type.Scrap, 1);
        Debug.Log("totalt antal scraps " + rm.Get(MyItem.Type.Scrap));
        Destroy(gameObject);
    }
}
