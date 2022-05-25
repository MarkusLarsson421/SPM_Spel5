using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatListener : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EatThePizza.RegisterListener(WriteSomething);
    }

    // Update is called once per frame
    void WriteSomething(EatThePizza pizza)
    {
        Debug.Log("Det smakar bra");
    }
}
