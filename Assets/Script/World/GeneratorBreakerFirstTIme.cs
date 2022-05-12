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

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2")
        {
            Debug.Log("triggar?");
            ss.SetGeneratorBreakFirstTime(true);
            Destroy(gameObject);
        }
        
    }
}
