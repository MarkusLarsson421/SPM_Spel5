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

    private List<string> interactedPlayers = new List<string>();
  
   
    private GameObject interactingPlayer;
    private ResourceManager rm;

    

    private GameObject playerOneCustomizationButtons, playerTwoCustomizationButtons;
    private GameObject playerOneHatButton, playerTwoHatButton;
    private GameObject playerOneNoHatButton, playerTwoNoHatButton;
   
    private GameObject playerOneHat, playerTwoHat;
    private Canvas playerOneCanvas, playerTwoCanvas;
    private EventSystem playerOneEventSystem, playerTwoEventSystem;

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
            interactingPlayer = inter.interactingGameObject.transform.parent.gameObject;
            if (!interactedPlayers.Contains(interactingPlayer.tag))
            {
                SetCurrentCanvas();
            }
            else
            {
                ActivateInteractingPlayer();
            }
            
            buttonsEnabled = true;
        }

        if (!isToggled && currentPlayerTag != null)
        {
            RemoveCurrentPlayer();
            currentPlayerTag = null;
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

        if (interactingPlayer.tag.Equals("Player1"))
        {
            playerOneCanvas = interactingPlayer.GetComponentInChildren<Canvas>();
            playerOneHat = interactingPlayer.transform.Find("Hat").gameObject;
            playerOneCustomizationButtons = playerOneCanvas.gameObject.transform.Find("CustomizationButtons").gameObject;
            playerOneCustomizationButtons.SetActive(true);
            playerOneHatButton = playerOneCustomizationButtons.transform.Find("HatButton").gameObject;
            playerOneNoHatButton = playerOneCustomizationButtons.transform.Find("NoHatButton").gameObject;
            playerOneNoHatButton.GetComponent<Button>().onClick.AddListener(delegate { DisableHat(); });
            playerOneHatButton.GetComponent<Button>().onClick.AddListener(delegate { ActivateHat(); });
        }
        else
        {
            playerTwoCanvas = interactingPlayer.GetComponentInChildren<Canvas>();
            playerTwoHat = interactingPlayer.transform.Find("Hat").gameObject;
            playerTwoCustomizationButtons = playerTwoCanvas.gameObject.transform.Find("CustomizationButtons").gameObject;
            playerTwoCustomizationButtons.SetActive(true);
            playerTwoHatButton = playerTwoCustomizationButtons.transform.Find("HatButton").gameObject;
            playerTwoNoHatButton = playerTwoCustomizationButtons.transform.Find("NoHatButton").gameObject;
            playerTwoNoHatButton.GetComponent<Button>().onClick.AddListener(delegate { DisableHat(); });
            playerTwoHatButton.GetComponent<Button>().onClick.AddListener(delegate { ActivateHat(); });
        }
        interactedPlayers.Add(interactingPlayer.tag);

        SetCurrentEventSystem();
    }
    /**
     * Finds the eventsystem inside the interacting player and activates sets the first selected button
     */
    public void SetCurrentEventSystem()
    {
        if (interactingPlayer.tag.Equals("Player1"))
        {
            playerOneEventSystem = interactingPlayer.transform.Find("EventSystem").GetComponent<EventSystem>();
            playerOneEventSystem.SetSelectedGameObject(playerOneNoHatButton);
        }
        else
        {
            playerTwoEventSystem = interactingPlayer.transform.Find("EventSystem").GetComponent<EventSystem>();
            playerTwoEventSystem.SetSelectedGameObject(playerTwoNoHatButton);
        }
    }

    private void ActivateHat()
    {
        if (interactingPlayer.tag.Equals("Player1"))
        {
            playerOneHat.SetActive(true);
        }
        else
        {
            playerTwoHat.SetActive(true);
        }
        
    }

    private void DisableHat()
    {
        if (interactingPlayer.tag.Equals("Player1"))
        {
            playerOneHat.SetActive(false);
        }
        else
        {
            playerTwoHat.SetActive(false);
        }
        
    }

    private void ActivateInteractingPlayer()
    {
        if (interactingPlayer.tag == "Player1")
        {
            playerOneCustomizationButtons.SetActive(true);
            playerOneEventSystem.SetSelectedGameObject(playerOneNoHatButton);
        }
        else
        {
            playerOneCustomizationButtons.SetActive(true);
            playerTwoEventSystem.SetSelectedGameObject(playerTwoNoHatButton);
        }

    }

    private void RemoveCurrentPlayer()
    {
        if (currentPlayerTag == "Player1")
        {
            playerOneCustomizationButtons.SetActive(false);
        }
        else
        {
            playerTwoCustomizationButtons.SetActive(false);
        }
    }

    public void SetCurrentPlayerTag(string tag)
    {
        currentPlayerTag = tag;
    }

}
