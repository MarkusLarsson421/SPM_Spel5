using System.Collections;
using UnityEngine;
using TMPro;

public class SubsScript : MonoBehaviour{
	public GameObject textBox;
	public bool scrapPickUpLine;
	public bool needToReload;
	public bool flashLightLine;
	public bool craftingTableLine;
    private bool firstScrapPickedUp = true; //används i SPU_SimonProtype.
    private bool courtineRunning;
    private bool generatorBrokeFirstTime;
    private int timeToShowText = 1;
    

    public float delay = 0.1f;
    private string fullText;
    private string currentText = "";
    
    /*
     *       
     * @Author Simon Hessling Oscarson
     * 
     * 
     */
    //TODO gör så man kan köra fler rader än en. Just kan scriptet enbart köra en rad.

    private void Update(){
        if (generatorBrokeFirstTime)
        {
            StartCoroutine(Subtitle("Shit, the generator broke, we have to fix it.", timeToShowText));
            generatorBrokeFirstTime = false;
        }
        /*
        if (firstBatteryPickedUp)
        {
            firstBatteryPickedUp = false;
			StartCoroutine(Subtitle("Perfect for the flashlight.",0, timeToShowText));
		}

		if(needToReload){
			needToReload = false;
			StartCoroutine(Subtitle("Gotta reload.",0, timeToShowText));
		}

		if(flashLightLine){
			flashLightLine = false;
			StartCoroutine(Subtitle("Oh no, it is flickering.",0, timeToShowText));
		}

		if(craftingTableLine){
			craftingTableLine = false;
			StartCoroutine(Subtitle("We can probably use these to fix the car.",0, timeToShowText));
		}*/
	}

	private IEnumerator Subtitle(string text, int timeToFinish){
        fullText = text;
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            textBox.GetComponent<TextMeshProUGUI>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
		yield return new WaitForSeconds(timeToFinish);
		textBox.GetComponent<TextMeshProUGUI>().text = "";
	}

    
    private IEnumerator Warning(string text, int timeToStart, int timeToFinish)
    {
        textBox.GetComponent<TextMeshProUGUI>().text = "";
        yield return new WaitForSeconds(timeToStart);
        textBox.GetComponent<TextMeshProUGUI>().text = text;
        yield return new WaitForSeconds(timeToFinish);
        textBox.GetComponent<TextMeshProUGUI>().text = "";
    }
    public void SetGeneratorBreakFirstTime(bool boolean)
    {
        generatorBrokeFirstTime = boolean;
    }

    public void FixCarLinePlay()
    {
        StartCoroutine(Subtitle("Dan: We got to fix the car.", timeToShowText));
    }
    public void ScrapsUsedForCarLine()
    {
        if (firstScrapPickedUp)
        {
            StartCoroutine(Subtitle("We can probably use these to fix the car.", timeToShowText));
        }
        firstScrapPickedUp = false;
        
    }

    
    public void NoScrapsLinePlay()//funkar här. Interaktioner körs för många gånger dock.
    {
       
            StartCoroutine(Warning("no scraps.", 0, timeToShowText));
      
    }
}