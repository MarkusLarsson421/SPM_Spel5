using System.Collections;
using UnityEngine;
using TMPro;

public class SubsScript : MonoBehaviour{
	public GameObject textBox;
	public bool scrapPickUpLine;
	public bool batteryFirstPickUp;
	public bool needToReload;
	public bool flashLightLine;
	public bool craftingTableLine;
    private bool firstScrapPickedUp = true; //används i SPU_SimonProtype.
    private bool coroutineRunning;

    /*
     * 
     * @Author Simon Hessling Oscarson
     * 
     * 
     */
    //TODO gör så man kan köra fler rader än en. Just kan scriptet enbart köra en rad.
	private void Start(){
		StartCoroutine(Subtitle("Dan: We got to fix the car.", 3));
	}

	private void Update(){
        
		if(scrapPickUpLine){
            Debug.Log("funkar");
			scrapPickUpLine = false;
			StartCoroutine(Subtitle("We can probably use these to fix the car.", 3));
		}

		if(batteryFirstPickUp){
			batteryFirstPickUp = false;
			StartCoroutine(Subtitle("Perfect for the flashlight.", 3));
		}

		if(needToReload){
			needToReload = false;
			StartCoroutine(Subtitle("Gotta reload.", 3));
		}

		if(flashLightLine){
			flashLightLine = false;
			StartCoroutine(Subtitle("Oh no, it is flickering.", 3));
		}

		if(craftingTableLine){
			craftingTableLine = false;
			StartCoroutine(Subtitle("We can probably use these to fix the car.", 3));
		}
	}

	private IEnumerator Subtitle(string text, int seconds){
		textBox.GetComponent<TextMeshProUGUI>().text = "";
		yield return new WaitForSeconds(1);
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
}