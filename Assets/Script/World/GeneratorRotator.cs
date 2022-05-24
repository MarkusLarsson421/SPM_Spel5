using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class GeneratorRotator : MonoBehaviour {
    private Generator gen;

    // Update is called once per frame

    private void Start() {
        gen = gameObject.GetComponentInParent<Generator>();
    }

    void Update()
    {
        if(gen.GetFuel() != 0)
            Rotate();
        else
            StopRotate();

    }

    void Rotate() {
        transform.Rotate(50 * Time.deltaTime,0 ,0 );
    }

    void StopRotate() {
        transform.Rotate(0,0 ,0 );
    }
}
