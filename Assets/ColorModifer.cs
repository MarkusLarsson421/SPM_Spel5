using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ColorModifer : MonoBehaviour
{
    Image image;
    Color c;
    public int value;
    // Start is called before the first frame update
    void Start()
    {

         image = gameObject.GetComponent<Image>();
         c = image.color;
        c.a = 0;
        image.color = c;

    }
    
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(HpSampleToggler());
    }
   
        IEnumerator HpSampleToggler()
        {

        if (value == 80)
        {
            c.a = 0.25f;
            image.color = c;
            yield return new WaitForSeconds(8f);
            c.a = 0.15f;
            image.color = c;
            yield return new WaitForSeconds(8f);

            
        }
        if (value == 60)
        {
            c.a = 0.25f;
            image.color = c;
            yield return new WaitForSeconds(1f);
            c.a = 0.5f;
            image.color = c;
            yield return new WaitForSeconds(1f);
        }
        if (value == 40)
        {
            c.a = 0.5f;
            image.color = c;
            yield return new WaitForSeconds(0.7f);
            c.a = 0.75f;
            image.color = c;
            yield return new WaitForSeconds(0.7f);
        }
        if (value == 20)
        {
            c.a = 0.75f;
            image.color = c;
            yield return new WaitForSeconds(0.5f);
            c.a = 1f;
            image.color = c;
            yield return new WaitForSeconds(0.5f);
        }

    }
    
    
}
