using System.Collections;
using UnityEngine;
using TMPro;

public class SubsScript : MonoBehaviour{
	public GameObject textBox;
	public bool scrapPickUpLine;
	//public bool batteryFirstPickUp;
	public bool needToReload;
	public bool flashLightLine;
	public bool craftingTableLine;
    private bool firstScrapPickedUp; //används i SPU_SimonProtype.
    private bool firstBatteryPickedUp;
    private bool generatorBrokeFirstTime;
    private bool coroutineRunning;
    private int timeToShowText = 3;

    /*
     *       
     * @Author Simon Hessling Oscarson
     * 
     * 
     */
    //TODO gör så man kan köra fler rader än en. Just kan scriptet enbart köra en rad.
	private void Start(){
		StartCoroutine(Subtitle("Dan: We got to fix the car.", timeToShowText));
	}

	private void Update(){
        
		if(firstScrapPickedUp){
            Debug.Log("funkar2");
			
			StartCoroutine(Subtitle("We can probably use these to fix the car.", timeToShowText));
            firstScrapPickedUp = false;
        }
        if (generatorBrokeFirstTime)
        {
            Debug.Log("funkar2");

            StartCoroutine(Subtitle("Shit, the generator broke, we have to fix it.", timeToShowText));
            generatorBrokeFirstTime = false;
        }

        if (firstBatteryPickedUp)
        {
            firstBatteryPickedUp = false;
			StartCoroutine(Subtitle("Perfect for the flashlight.", timeToShowText));
		}

		if(needToReload){
			needToReload = false;
			StartCoroutine(Subtitle("Gotta reload.", timeToShowText));
		}

		if(flashLightLine){
			flashLightLine = false;
			StartCoroutine(Subtitle("Oh no, it is flickering.", timeToShowText));
		}

		if(craftingTableLine){
			craftingTableLine = false;
			StartCoroutine(Subtitle("We can probably use these to fix the car.", timeToShowText));
		}
	}

	private IEnumerator Subtitle(string text, int seconds){
		textBox.GetComponent<TextMeshProUGUI>().text = "";
		yield return new WaitForSeconds(0);
		textBox.GetComponent<TextMeshProUGUI>().text = text;
		yield return new WaitForSeconds(seconds);
		textBox.GetComponent<TextMeshProUGUI>().text = "";
	}
    
    public bool GetFirstScrapPickUp()
    {
        return firstScrapPickedUp;
    }
    public void SetFirstScrapPickUp(bool boolean)
    {
        firstScrapPickedUp = boolean;
    }
    public bool GetFirstBatteryPickUp()
    {
        return firstBatteryPickedUp;
    }
    public void SetFirstBatteryPickUp(bool boolean)
    {
        firstBatteryPickedUp = boolean;
    }

    public void SetGeneratorBreakFirstTime(bool boolean)
    {
        generatorBrokeFirstTime = boolean;
    }
}