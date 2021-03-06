using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
//Martin Wallmark
/*
 * Används för att kunna updatera vapen och ficklampan
 */

public class CraftingSystem : MonoBehaviour
{
    
    [SerializeField] private GameObject canvas;
    [SerializeField] private Font font;
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private Interactable inter;
    [SerializeField] public string currentPlayerTag;
    
    private EventSystem currentPlayerEventSystem;
    private Text infoText;
    private Canvas currentCanvas;
    public GameObject interactingPlayer;

    private bool isToggled;
    private bool isButtonClicked;
    private bool buttonsEnabled;
    private bool isShowingInfoText;

    private float textTimer;
    //Listorna är till för att hålla koll på om en viss spelare redan har en uppgradering.
    private List<string> damageUpgradedPlayers = new List<string>();
    private List<string> MagazineUpgradedPlayers = new List<string>();
    private List<string> flashLightUpgradedPlayers = new List<string>();

    private void Start()
    {
        
        infoText = canvas.AddComponent<Text>();
        infoText.font = font;
        infoText.fontSize = 32;
        infoText.enabled = false;
      
    }

     void Update()
    {
        
        if (isShowingInfoText)
        {
            textTimer += Time.deltaTime;
            infoText.enabled = true;
            if (textTimer >= 2)
            {
                isShowingInfoText = false;
                infoText.enabled = false;
                textTimer = 0;
            }
        }
        
        
        if(!isToggled && currentPlayerTag != null)
        {
            currentPlayerTag = null;
            currentCanvas.gameObject.transform.Find("CraftingTable").gameObject.SetActive(false);
            currentCanvas = null;
            buttonsEnabled = false;

        }

        if(isToggled && !buttonsEnabled)
        {
            SetCurrentCanvas();
            buttonsEnabled = true; 
        }

        if (isToggled)
        {
            float distance = Vector3.Distance(gameObject.transform.position, GameObject.FindGameObjectWithTag(currentPlayerTag).transform.position);
            if(distance > 3)
            {
                ToggleCraftingBench();
            }
        }
        
     }

    public void ToggleCraftingBench()
    {
        
        
        if (!isToggled)
        {
            
            Cursor.lockState = CursorLockMode.None;
            isToggled = true;
            infoText.enabled = true;
            
            infoText.text = "Craft here! \n" + "\nUpgrade damage: 2 Batteries, 2 Scraps \n" + "\nUpgrade magazine: 1 Battery, 3 Scraps \n" + "\nUpgrade flashlight: 3 Batteries, 1 Scrap";
            
            
        }
        else
        {
            isToggled = false;
            isButtonClicked = false;
            if (!isShowingInfoText)
            {
                infoText.enabled = false;
            }
            Cursor.lockState = CursorLockMode.Locked;
        }
        Debug.Log(currentPlayerTag + "is here");
        
    }
    public void DamageUpgrade()
    {
        if (!isButtonClicked)
        {
            currentPlayerTag = inter.interactingGameObject.transform.parent.tag;
            if (damageUpgradedPlayers.Contains(inter.interactingGameObject.transform.parent.tag))
            {
                Debug.Log("You already have this upgrade!");
                UpdateInfoText("AlreadyHasUpgrade");
            }
            else if (inter.interactingGameObject.GetComponentInChildren<ResourceManager>().Get(ResourceManager.ItemType.Battery) >= 2 && inter.interactingGameObject.GetComponentInChildren<ResourceManager>().Get(ResourceManager.ItemType.Scrap) >= 2)
            {
                inter.interactingGameObject.GetComponentInChildren<ResourceManager>().Offset(ResourceManager.ItemType.Battery, -2);
                inter.interactingGameObject.GetComponentInChildren<ResourceManager>().Offset(ResourceManager.ItemType.Scrap, -2);
                inter.interactingGameObject.GetComponentInChildren<Weapon>().SetDamage(40);

                damageUpgradedPlayers.Add(inter.interactingGameObject.transform.parent.tag);
                UpdateInfoText("GotUpgrade");
            }
            else
            {
                UpdateInfoText("NotEnoughItems");
            }
            isButtonClicked = true;
           
        }

    }

    public void IncreaseMagazineSize()
    {
        if (!isButtonClicked)
        {
            //Gör så att vapnets magasin kan ha fler patroner
            if (MagazineUpgradedPlayers.Contains(inter.interactingGameObject.transform.parent.tag))
            { 
                UpdateInfoText("AlreadyHasUpgrade");
            }
            else if (inter.interactingGameObject.GetComponentInChildren<ResourceManager>().Get(ResourceManager.ItemType.Battery) >= 1 && inter.interactingGameObject.GetComponentInChildren<ResourceManager>().Get(ResourceManager.ItemType.Scrap) >= 3)
            {
                inter.interactingGameObject.GetComponentInChildren<ResourceManager>().Offset(ResourceManager.ItemType.Battery, -1);
                inter.interactingGameObject.GetComponentInChildren<ResourceManager>().Offset(ResourceManager.ItemType.Scrap, -3);
                inter.interactingGameObject.GetComponentInChildren<Weapon>().SetMagCapacity(12);
                MagazineUpgradedPlayers.Add(inter.interactingGameObject.transform.parent.tag);
                
                UpdateInfoText("GotUpgrade");

            }
            else
            {
                UpdateInfoText("NotEnoughItems");
            }
            
            Debug.Log("wahwah");
            isButtonClicked = true;
        }
    }

    public void flashLightUpgrade()
    {
        if (!isButtonClicked)
        {


            if (flashLightUpgradedPlayers.Contains(inter.interactingGameObject.transform.parent.tag))
            {
                UpdateInfoText("AlreadyHasUpgrade");
            }
            //gör så att ficklampans batterie räcker längre
            else if (inter.interactingGameObject.GetComponentInChildren<ResourceManager>().Get(ResourceManager.ItemType.Battery) >= 3 && inter.interactingGameObject.GetComponentInChildren<ResourceManager>().Get(ResourceManager.ItemType.Scrap) >= 1)
            {
                inter.interactingGameObject.GetComponentInChildren<ResourceManager>().Offset(ResourceManager.ItemType.Battery, -3);
                inter.interactingGameObject.GetComponentInChildren<ResourceManager>().Offset(ResourceManager.ItemType.Scrap, -1);
                inter.interactingGameObject.GetComponentInChildren<FlashLight>().SetDrainMultiplier(0.05f);
                flashLightUpgradedPlayers.Add(inter.interactingGameObject.transform.parent.tag);
                Debug.Log(inter.interactingGameObject.transform.parent.tag);
                UpdateInfoText("GotUpgrade");
            }
            else
            {
                UpdateInfoText("NotEnoughItems");
            }
            //ToggleCraftingBench();
            Debug.Log("wahwah");
            isButtonClicked = true;
        }

    }

    private void SetCurrentCanvas()
    {
        currentCanvas = GameObject.FindGameObjectWithTag(currentPlayerTag).GetComponentInChildren<Canvas>();
        GameObject craftingButtons = currentCanvas.gameObject.transform.Find("CraftingTable").gameObject;
        
        craftingButtons.SetActive(true);
        //craftingButtons.gameObject.transform.Find("CancelButton").gameObject.GetComponent<Button>().onClick.AddListener(delegate { ToggleCraftingBench(); });
        craftingButtons.gameObject.transform.Find("DamageUpgrade").gameObject.GetComponent<Button>().onClick.AddListener(delegate { DamageUpgrade(); });
        craftingButtons.gameObject.transform.Find("fireRateUpgrade").gameObject.GetComponent<Button>().onClick.AddListener(delegate { flashLightUpgrade(); });
        craftingButtons.gameObject.transform.Find("MagazineUpgrade").gameObject.GetComponent<Button>().onClick.AddListener(delegate { IncreaseMagazineSize(); });
        
        SetCurrentEventSystem(craftingButtons);
    }

    private void SetCurrentEventSystem(GameObject craftingButtons)
    {
        currentPlayerEventSystem = GameObject.FindGameObjectWithTag(currentPlayerTag).transform.Find("EventSystem").GetComponent<EventSystem>();
        currentPlayerEventSystem.SetSelectedGameObject(craftingButtons.gameObject.transform.Find("CancelButton").gameObject);
    }

    private void UpdateInfoText(string s)
    {
        switch (s)
        {
            case "AlreadyHasUpgrade":
                infoText.text = "You already have this upgrade!";
                break;
            case "NotEnoughItems":
                infoText.text = "You don't have enough items!";
                break;
            case "GotUpgrade":
                infoText.text = "Upgrade succesful!";
                break;
        }
        isShowingInfoText = true;
    }

}
