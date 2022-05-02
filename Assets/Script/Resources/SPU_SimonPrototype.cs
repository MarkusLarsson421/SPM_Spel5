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
        rm.PickUpScraps();
        Debug.Log("totalt antal scraps " + rm.GetCurrentScraps());
        Destroy(gameObject);
    }
}
