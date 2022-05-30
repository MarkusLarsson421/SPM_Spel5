using System.Collections;
using UnityEngine;
using TMPro;

public class SubsScript : MonoBehaviour{
    [SerializeField] private GameObject textBox;
    [SerializeField] private GameObject controlsTextBox;
    [SerializeField] private GameObject background;
    private SoundManager sM; //Simon Hessling Oscarson
    public bool scrapPickUpLine;
	public bool needToReload;
	public bool flashLightLine;
	public bool craftingTableLine;
    private bool firstScrapPickedUp = true; //används i SPU_SimonProtype.
    private bool courtineRunning;
    private bool generatorBrokeFirstTime;
    private int timeToShowText = 1;
    private int timeToWait = 2;

    public float delay = 0.1f;
    private string fullText;
    private string currentText = "";

    
    private void Awake()
    {
        
        
        Debug.Log(sM);
    }
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
        sM = GameObject.Find("SM").GetComponent<SoundManager>();
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            textBox.GetComponent<TextMeshProUGUI>().text = currentText;
            sM.SoundPlaying("subtitlesSound");
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
    private IEnumerator ToolTips(int timeToStart, int timeToFinish)
    {
        Debug.Log("gegkwogeggdsgsdgdsgdsgdsdsg");
        controlsTextBox.GetComponent<TextMeshProUGUI>().text = "";
        yield return new WaitForSeconds(3);
        background.SetActive(true);
        controlsTextBox.GetComponent<TextMeshProUGUI>().text = "Controls:";
        yield return new WaitForSeconds(3);
        controlsTextBox.GetComponent<TextMeshProUGUI>().text = "Left Trigger(LT) - Use Flashlight";
        yield return new WaitForSeconds(2);
        controlsTextBox.GetComponent<TextMeshProUGUI>().text = "B - Toggle Sprint";
        yield return new WaitForSeconds(2);
        controlsTextBox.GetComponent<TextMeshProUGUI>().text = "Y - Switch Weapon";
        yield return new WaitForSeconds(2);
        controlsTextBox.GetComponent<TextMeshProUGUI>().text = "X - Reload";
        yield return new WaitForSeconds(2);
        controlsTextBox.GetComponent<TextMeshProUGUI>().text = "A - Interact";
        yield return new WaitForSeconds(2);
        controlsTextBox.GetComponent<TextMeshProUGUI>().text = "START - Controls and Pause";
        yield return new WaitForSeconds(4);
        background.SetActive(false);
        controlsTextBox.GetComponent<TextMeshProUGUI>().text = "";
    }
    public void SetGeneratorBreakFirstTime(bool boolean)
    {
        generatorBrokeFirstTime = boolean;
    }

    public void FixCarLinePlay()
    {
        

        StartCoroutine(ToolTips(2, timeToShowText));

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