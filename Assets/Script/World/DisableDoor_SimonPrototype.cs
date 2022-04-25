using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableDoor_SimonPrototype : MonoBehaviour
{
    public GameObject door1;
    public GameObject door2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableDoors()
    {
        Destroy(door1);
        Destroy(door2);
        
    }
}
