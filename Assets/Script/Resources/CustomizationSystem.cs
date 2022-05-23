using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomizationSystem : MonoBehaviour
{

     
    [SerializeField] private GameObject canvas;
    
    [SerializeField] private Font font;
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private Interactable inter;
    [SerializeField] private string currentPlayerTag;
    private Canvas currentCanvas;
    private EventSystem currentPlayerEventSystem;
    private GameObject interactingPlayer;
    private ResourceManager rm;

    private Color originalColor = new Color(61f, 104f, 93f);

    private GameObject greenColorButton;
    private GameObject whiteColorButton;
    private GameObject cancelButton;
    private GameObject currentHat;

    private bool buttonsEnabled;
    private bool isToggled;
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isToggled);
        if (isToggled && !buttonsEnabled)
        {
            interactingPlayer = inter.interactingGameObject.transform.parent.gameObject;
            SetCurrentCanvas();
            buttonsEnabled = true;
        }

        if (!isToggled && currentPlayerTag != null)
        {
            currentPlayerTag = null;
            currentCanvas.gameObject.transform.Find("CustomizationButtons").gameObject.SetActive(false);
            currentCanvas = null;
            buttonsEnabled = false;

        }

        if (isToggled)
        {
            float distance = Vector3.Distance(gameObject.transform.position, GameObject.FindGameObjectWithTag(currentPlayerTag).transform.position);
            if (distance > 3)
            {
                Debug.Log("Toggled");
                ToggleCustomizationTable();
            }
        }
    }

    /**
     * Activate or deactivates the customizationtable based on if the bool istoggled is true or not
     */

    public void ToggleCustomizationTable()
    {
        //ToggleButtons();
        if (!isToggled)
        {
            isToggled = true;
            //eventSystem.SetSelectedGameObject(cancelButton);
        }
        else
        {
            isToggled = false;
        }
    }

    /**
     * Finds the canvas inside the interacting player and activates the buttons
     */
    private void SetCurrentCanvas()
    {
        


        currentCanvas = interactingPlayer.GetComponentInChildren<Canvas>();
        currentHat = interactingPlayer.transform.Find("Hat").gameObject;
        GameObject customButtons = currentCanvas.gameObject.transform.Find("CustomizationButtons").gameObject;
        

        customButtons.SetActive(true);
        //craftingButtons.gameObject.transform.Find("CancelButton").gameObject.GetComponent<Button>().onClick.AddListener(delegate { ToggleCraftingBench(); });
        customButtons.gameObject.transform.Find("NoHatButton").gameObject.GetComponent<Button>().onClick.AddListener(delegate { DisableHat(); });
        customButtons.gameObject.transform.Find("HatButton").gameObject.GetComponent<Button>().onClick.AddListener(delegate { ActivateHat(); });
        /*
        customButtons.gameObject.transform.Find("WhiteColor").gameObject.GetComponent<Button>().onClick.AddListener(delegate { WhiteLight(); });
        customButtons.gameObject.transform.Find("GreenColor").gameObject.GetComponent<Button>().onClick.AddListener(delegate { GreenLight(); });
        */
        



        SetCurrentEventSystem();
    }
    /**
     * Finds the eventsystem inside the interacting player and activates sets the first selected button
     */
    public void SetCurrentEventSystem()
    {
        currentPlayerEventSystem = GameObject.FindGameObjectWithTag(currentPlayerTag).transform.Find("EventSystem").GetComponent<EventSystem>();
        currentPlayerEventSystem.SetSelectedGameObject(currentCanvas.gameObject.transform.Find("CustomizationButtons").gameObject.transform.Find("NoHatButton").gameObject);
    }

    private void ActivateHat()
    {
        Debug.Log("hat");
        currentHat.SetActive(true);
        Debug.Log("wow");
        
    }

    private void DisableHat()
    {
        Debug.Log("noHat");
        currentHat.SetActive(false);
        
    }

    public void SetCurrentPlayerTag(string tag)
    {
        currentPlayerTag = tag;
    }

    /*
    public void GreenLight()
    {
        interactingPlayer.GetComponentInChildren<FlashLight>().SetColor(119f, 250f, 169f);
    }

    public void WhiteLight()
    {
        interactingPlayer.GetComponentInChildren<FlashLight>().SetColor(203f, 212f, 200f);
    }
    */

}
