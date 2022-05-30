using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltUI : MonoBehaviour
{
    /*
     * 
     * 
     * Author@ Simon Hessling Oscarson
     */

    // Update is called once per frame
    private void Start()
    {
        StartCoroutine(Shaker());
    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            TiltImageLeft();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            TiltImageUp();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            TiltImageDown();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            TiltImageRight();
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            TiltImageRight();
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            TiltImageDown();
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            TiltImageUp();
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            TiltImageLeft();
        }

    }
    private void TiltImageLeft()
    {
        transform.Rotate(0, 10, 0);
    }
    private void TiltImageRight()
    {
        transform.Rotate(0, -10, 0);
    }
    private void TiltImageUp()
    {
        transform.Rotate(10, 0, 0);
    }
    private void TiltImageDown()
    {
        transform.Rotate(-10, 0, 0);
    }

    IEnumerator Shaker()
    {
        transform.Rotate(0, 0, -2);
        yield return new WaitForSeconds(0.1f);
        transform.Rotate(0, 0, 4 );
        yield return new WaitForSeconds(0.1f);
        transform.Rotate(0, 0, -4);
        yield return new WaitForSeconds(0.1f);
        transform.Rotate(0, 0, 4);
        yield return new WaitForSeconds(0.1f);
        transform.Rotate(0, 0, -4);
        yield return new WaitForSeconds(0.1f);
        transform.Rotate(0, 0, 4);
        yield return new WaitForSeconds(0.1f);
        transform.Rotate(0, 0, -2);


    }

}
