using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SubsScript : MonoBehaviour
{
    public GameObject textBox;
    public bool scrapPickUpLine = false;
    public bool batteryFirstPickUp = false;
    public bool needToReload = false;
    public bool flashLightLine = false;
    public bool craftingTableLine = false;

    void Start()
    {
        StartCoroutine(TheFirstLine());
    }
    private void Update()
    {
        if (scrapPickUpLine == true)
        {
            Debug.Log("kommer  hit");
            StartCoroutine(ScrapsFirstPickUpLine());
            scrapPickUpLine = false;
        }
        if(batteryFirstPickUp == true)
        {
            BatteryFirstPickUpLine();
        }
        if (needToReload == true)
        {
            NeedToReloadLine();
        }   
        if (flashLightLine == true)
        {
            FlashLightLine();
        }
        if (craftingTableLine == true)
        {
            CraftingTableLine();
        }
       
       
    }
    IEnumerator TheFirstLine()
    {
        yield return new WaitForSeconds(1);
        textBox.GetComponent<TextMeshProUGUI>().text = "We got to fix the car.";
        yield return new WaitForSeconds(3);
        textBox.GetComponent<TextMeshProUGUI>().text = "";
        

       
    }
     IEnumerator ScrapsFirstPickUpLine()
    {
        Debug.Log("gör detta med");
        yield return new WaitForSeconds(1);
        textBox.GetComponent<TextMeshProUGUI>().text = "We can probably use these to fix the car.";
        yield return new WaitForSeconds(3);
        textBox.GetComponent<TextMeshProUGUI>().text = "";
    }
    IEnumerator BatteryFirstPickUpLine()
    {
        yield return new WaitForSeconds(1);
        textBox.GetComponent<TextMeshProUGUI>().text = "Perfect for the flashlight";
        yield return new WaitForSeconds(3);
        textBox.GetComponent<TextMeshProUGUI>().text = "";
    }

    IEnumerator NeedToReloadLine()
    {
        yield return new WaitForSeconds(1);
        textBox.GetComponent<TextMeshProUGUI>().text = "Gotta reload";
        yield return new WaitForSeconds(3);
        textBox.GetComponent<TextMeshProUGUI>().text = "";
    }
    IEnumerator FlashLightLine()
    {
        yield return new WaitForSeconds(1);
        textBox.GetComponent<TextMeshProUGUI>().text = "Oh no, it is flickering.";
        yield return new WaitForSeconds(3);
        textBox.GetComponent<TextMeshProUGUI>().text = "";
    }
    IEnumerator CraftingTableLine()
    {
        yield return new WaitForSeconds(1);
        textBox.GetComponent<TextMeshProUGUI>().text = "We can probably use these to fix the car.";
        yield return new WaitForSeconds(3);
        textBox.GetComponent<TextMeshProUGUI>().text = "";
    }
}
