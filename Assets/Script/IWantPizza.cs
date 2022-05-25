using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IWantPizza : MonoBehaviour
{
    float dileveryTime = 2;
    bool pizzaIsHere = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!pizzaIsHere) { 
            dileveryTime -= Time.deltaTime;
            if (dileveryTime <= 0) pizzaIsHere =true;
        }
        else
        {
            dileveryTime = 2;
            pizzaIsHere = false;
            //Here we want to trigger an event
            EatThePizza pizza = new EatThePizza();
            pizza.FireEvent();
        }
    }
}
