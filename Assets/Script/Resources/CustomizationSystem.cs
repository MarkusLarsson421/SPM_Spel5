using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomizationSystem : MonoBehaviour
{

    public ResourceManager rm;
    [SerializeField] private GameObject canvas;
    [SerializeField] private Font font;
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private Interactable inter;
    [SerializeField] public string currentPlayerTag;
    private Canvas currentCanvas;
    private EventSystem currentPlayerEventSystem;

    private Color originalColor = new Color(61f, 104f, 93f);

    private GameObject greenColorButton;
    private GameObject whiteColorButton;
    private GameObject cancelButton;

    private bool buttonsEnabled;
    private bool isToggled;
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isToggled && !buttonsEnabled)
        {
            SetCurrentCanvas();
            buttonsEnabled = true;
        }

        if (!isToggled && currentPlayerTag != null)
        {
            currentPlayerTag = null;
            currentCanvas.gameObject.transform.Find("CraftingTable").gameObject.SetActive(false);
            currentCanvas = null;
            buttonsEnabled = false;

        }

        if (isToggled)
        {
            float distance = Vector3.Distance(gameObject.transform.position, GameObject.FindGameObjectWithTag(currentPlayerTag).transform.position);
            if (distance > 3)
            {
                ToggleCustomizationTable();
            }
        }
    }


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


    private void ToggleButtons()
    {
        if (!isToggled)
        {
            greenColorButton.SetActive(true);
            whiteColorButton.SetActive(true);
            cancelButton.SetActive(true);
        }
        else
        {
            greenColorButton.SetActive(false);
            whiteColorButton.SetActive(false);
            cancelButton.SetActive(false);
        }
    }

    private void SetCurrentCanvas()
    {
        


        currentCanvas = GameObject.FindGameObjectWithTag(currentPlayerTag).GetComponentInChildren<Canvas>();
        GameObject customButtons = currentCanvas.gameObject.transform.Find("CustomizationButtons").gameObject;

        customButtons.SetActive(true);
        //craftingButtons.gameObject.transform.Find("CancelButton").gameObject.GetComponent<Button>().onClick.AddListener(delegate { ToggleCraftingBench(); });
        customButtons.gameObject.transform.Find("NoHatButton").gameObject.GetComponent<Button>().onClick.AddListener(delegate { DisableHat(); });
        customButtons.gameObject.transform.Find("HatButton").gameObject.GetComponent<Button>().onClick.AddListener(delegate { ActivateHat(); });
        
        //customButtons.gameObject.transform.Find("MagazineUpgrade").gameObject.GetComponent<Button>().onClick.AddListener(delegate { IncreaseMagazineSize(); });



        SetCurrentEventSystem();
    }

    public void SetCurrentEventSystem()
    {
        currentPlayerEventSystem = GameObject.FindGameObjectWithTag(currentPlayerTag).transform.Find("EventSystem").GetComponent<EventSystem>();
        currentPlayerEventSystem.SetSelectedGameObject(currentCanvas.gameObject.transform.Find("CustomizationButtons").gameObject.transform.Find("NoHatButton").gameObject);
    }

    private void ActivateHat()
    {
        Debug.Log("hat");
    }

    private void DisableHat()
    {
        Debug.Log("noHat");
    }

    /*
    public void GreenLight()
    {
        Debug.Log("wadaffa");
       // GameObject interactingPlayer = inter.gameObject;
        //Debug.Log(inter.gameObject.tag);
        //interactingPlayer.GetComponentInChildren<FlashLight>().setFlashLightColor(18f, 166f, 0f);
        Debug.Log("wadaffa1");
    }

    public void WhiteLight()
    {
        Debug.Log("click31");
        //GameObject interactingPlayer = GameObject.Find(inter.interactingGameObject.transform.parent.tag);
        //interactingPlayer.GetComponentInChildren<FlashLight>().setFlashLightColor(61f, 104f, 93f);
    }
    */

}
