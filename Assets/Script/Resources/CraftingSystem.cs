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
    [SerializeField] private string currentPlayerTag;
    
    private EventSystem currentPlayerEventSystem;
    private Text infoText;
    private Canvas currentCanvas;
    private GameObject interactingPlayer;

    private bool isToggled;
    private bool isButtonClicked;
    private bool buttonsEnabled;
    private bool isShowingInfoText;
    

    private float textTimer;
    private float distanceToInteractingPlayer;
    //Listorna är till för att hålla koll på om en viss spelare redan har en uppgradering.

    //TODO ändra så bara en dictionary används istället för 3 listor
    private Dictionary<string, List<string>> upgradedPlayers = new Dictionary<string, List<string>>();
    /*
    private List<string> damageUpgradedPlayers = new List<string>();
    private List<string> MagazineUpgradedPlayers = new List<string>();
    private List<string> flashLightUpgradedPlayers = new List<string>();
    */

    private void Start()
    {
        upgradedPlayers.Add("DamageUpgrade", new List<string>());
        upgradedPlayers.Add("MagazineUpgrade", new List<string>());
        upgradedPlayers.Add("FlashLightUpgrade", new List<string>());
        infoText = canvas.AddComponent<Text>();
        infoText.font = font;
        infoText.fontSize = 32;
        infoText.enabled = false;
      
    }

     void Update()
    {
        
        if (isShowingInfoText)
        {
            ShowUpgradeInfoText();
        }
        
        
        if(!isToggled && currentPlayerTag != null)
        {
            RemoveCurrentPlayer();
        }

        if(isToggled && !buttonsEnabled)
        {
            interactingPlayer = inter.interactingGameObject.transform.parent.gameObject;
            SetCurrentCanvas();
            buttonsEnabled = true; 
        }

        if (isToggled)
        {
            distanceToInteractingPlayer = Vector3.Distance(gameObject.transform.position, interactingPlayer.transform.position);
            if(distanceToInteractingPlayer > 6)
            {
                ToggleCraftingBench();
            }
        }
        
     }

    public void ToggleCraftingBench()
    {
        
        
        if (!isToggled)
        {
            
            
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
            List<string> list;
            currentPlayerTag = inter.interactingGameObject.transform.parent.tag;
            upgradedPlayers.TryGetValue("DamageUpgrade", out list);
            if (list.Contains(currentPlayerTag))
            {
                Debug.Log("You already have this upgrade!");
                UpdateInfoText("AlreadyHasUpgrade");
            }
            else if (interactingPlayer.GetComponentInChildren<ResourceManager>().Get(ResourceManager.ItemType.Battery) >= 2 && interactingPlayer.GetComponentInChildren<ResourceManager>().Get(ResourceManager.ItemType.Scrap) >= 2)
            {
                interactingPlayer.GetComponentInChildren<ResourceManager>().Offset(ResourceManager.ItemType.Battery, -2);
                interactingPlayer.GetComponentInChildren<ResourceManager>().Offset(ResourceManager.ItemType.Scrap, -2);
                interactingPlayer.GetComponentInChildren<Weapon>().SetDamage(40);

                list.Add(currentPlayerTag);
                UpdateInfoText("GotUpgrade");
            }
            else
            {
                UpdateInfoText("NotEnoughItems");
            }
                isButtonClicked = true;



                /*
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
               */
            }

        }

    

    public void IncreaseMagazineSize()
    {
        if (!isButtonClicked)
        {

            List<string> list;
            currentPlayerTag = inter.interactingGameObject.transform.parent.tag;
            upgradedPlayers.TryGetValue("MagazineUpgrade", out list);
            if (list.Contains(currentPlayerTag))
            {
                Debug.Log("You already have this upgrade!");
                UpdateInfoText("AlreadyHasUpgrade");
            }
            //Gör så att vapnets magasin kan ha fler patroner
          
            else if (interactingPlayer.GetComponentInChildren<ResourceManager>().Get(ResourceManager.ItemType.Battery) >= 1 && interactingPlayer.GetComponentInChildren<ResourceManager>().Get(ResourceManager.ItemType.Scrap) >= 3)
            {
                interactingPlayer.GetComponentInChildren<ResourceManager>().Offset(ResourceManager.ItemType.Battery, -1);
                interactingPlayer.GetComponentInChildren<ResourceManager>().Offset(ResourceManager.ItemType.Scrap, -3);
                interactingPlayer.GetComponentInChildren<Weapon>().SetMagCapacity(12);
                list.Add(currentPlayerTag);
                
                UpdateInfoText("GotUpgrade");

            }
            else
            {
                UpdateInfoText("NotEnoughItems");
            }
            isButtonClicked = true;
        }
    }

    public void flashLightUpgrade()
    {
        if (!isButtonClicked)
        {
            List<string> list;
            currentPlayerTag = inter.interactingGameObject.transform.parent.tag;
            upgradedPlayers.TryGetValue("FlashLightUpgrade", out list);
            if (list.Contains(currentPlayerTag))
            {
                Debug.Log("You already have this upgrade!");
                UpdateInfoText("AlreadyHasUpgrade");
            }
            //gör så att ficklampans batterie räcker längre
            else if (interactingPlayer.GetComponentInChildren<ResourceManager>().Get(ResourceManager.ItemType.Battery) >= 3 && inter.interactingGameObject.GetComponentInChildren<ResourceManager>().Get(ResourceManager.ItemType.Scrap) >= 1)
            {
                interactingPlayer.GetComponentInChildren<ResourceManager>().Offset(ResourceManager.ItemType.Battery, -3);
                interactingPlayer.GetComponentInChildren<ResourceManager>().Offset(ResourceManager.ItemType.Scrap, -1);
                interactingPlayer.GetComponentInChildren<FlashLight>().SetDrainMultiplier(0.05f);
                list.Add(currentPlayerTag);
                UpdateInfoText("GotUpgrade");
            }
            else
            {
                UpdateInfoText("NotEnoughItems");
            }
            isButtonClicked = true;
        }

    }

    private void SetCurrentCanvas()
    {
        currentCanvas = interactingPlayer.GetComponentInChildren<Canvas>();
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
        currentPlayerEventSystem = interactingPlayer.transform.Find("EventSystem").GetComponent<EventSystem>();
        currentPlayerEventSystem.SetSelectedGameObject(craftingButtons.gameObject.transform.Find("CancelButton").gameObject);
    }

    private void RemoveCurrentPlayer()
    {
        currentPlayerTag = null;
        currentCanvas.gameObject.transform.Find("CraftingTable").gameObject.SetActive(false);
        currentCanvas = null;
        buttonsEnabled = false;
        interactingPlayer = null;
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

    private void ShowUpgradeInfoText()
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

    public void SetCurrentPlayerTag(string tag)
    {
        currentPlayerTag = tag;
    }

}
