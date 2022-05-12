using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorBreakerFirstTIme : MonoBehaviour
{
    public SubsScript ss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter()
    {
        ss.SetGeneratorBreakFirstTime(true);
        Destroy(gameObject);
    }
}
