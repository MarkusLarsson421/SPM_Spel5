using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ColorModifer : MonoBehaviour
{
    Image image;
    Color c;
    [SerializeField]private float value;
   
    // Start is called before the first frame update
    void Start()
    {

        image = gameObject.GetComponent<Image>();
        c = image.color;
    }
    
    // Update is called once per frame
    void Update()
    {
        HpIndicator();
    }
    public void setValue(float health)
    {
        float healthProcent = 1f - (health / 100f);
        this.value = healthProcent;
    }
    public void setImage(Image image)
    {
        this.image = image;
    }
    void HpIndicator()
    {
        c.a = value;
        image.color = c;
        //if (value <= 20)
        //{
        //    c.a = 0.75f;
        //    image.color = c;
        //}
        //else if (value <= 40)
        //{
        //    c.a = 0.5f;
        //    image.color = c;
        //}
        //else if (value <= 60)
        //{
        //    c.a = 0.25f;
        //    image.color = c;
        //}
        //else if (value <= 80)
        //{
        //    c.a = 0.25f;
        //    image.color = c;
        //}
        //else
        //{
        //    c.a = 0f;
        //    image.color = c;
        //}
    }
   
        IEnumerator HpSampleToggler()
        {

        if (value == 80)
        {
            c.a = 0.25f;
            image.color = c;
            yield return new WaitForSeconds(4f);
            c.a = 0.20f;
            image.color = c;
            yield return new WaitForSeconds(4f);

            
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
