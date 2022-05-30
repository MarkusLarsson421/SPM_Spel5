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

    private Weapon playerOneWeapon, playerTwoWeapon;
    private ResourceManager playerOneRM, playerTwoRM;
    private FlashLight playerOneFlashLight, playerTwoFlashLight;
    private GameObject playerOneButtons, playerTwoButtons;
    [SerializeField] private Canvas playerOneCanvas, playerTwoCanvas;

    private EventSystem playerOneEventSystem, playerTwoEventSystem;

    private GameObject playerOneDamageUpgrade, playerTwoDamageUpgrade;
    private GameObject playerOneMagazineUpgrade, playerTwoMagazineUpgrade;
    private GameObject playerOneFlashLightUpgrade, playerTwoFlashLightUpgrade;
    private GameObject playerOneCancelButton, playerTwoCancelButton;

    //TODO ändra så bara en dictionary används istället för 3 listor
    private Dictionary<string, List<string>> upgradedPlayers = new Dictionary<string, List<string>>();
    private List<string> interactedPlayers = new List<string>();
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
                return;
            }
            if (interactingPlayer.tag.Equals("Player1"))
            {
                if (playerOneRM.Get(ResourceManager.ItemType.Battery) >= 2 && playerOneRM.Get(ResourceManager.ItemType.Scrap) >= 2)
                {
                    playerOneRM.Offset(ResourceManager.ItemType.Battery, -2);
                    playerOneRM.Offset(ResourceManager.ItemType.Scrap, -2);
                    playerOneWeapon.SetDamage(40);

                    list.Add(currentPlayerTag);
                    UpdateInfoText("GotUpgrade");
                    playerOneDamageUpgrade.GetComponent<Button>().interactable = false;
                }
                else
                {
                    UpdateInfoText("NotEnoughItems");
                }
            }
            else
            {
                if (playerTwoRM.Get(ResourceManager.ItemType.Battery) >= 2 && playerTwoRM.Get(ResourceManager.ItemType.Scrap) >= 2)
                {
                    playerTwoRM.Offset(ResourceManager.ItemType.Battery, -2);
                    playerTwoRM.Offset(ResourceManager.ItemType.Scrap, -2);
                    playerTwoWeapon.SetDamage(40);

                    list.Add(currentPlayerTag);
                    UpdateInfoText("GotUpgrade");
                    playerTwoDamageUpgrade.GetComponent<Button>().interactable = false;
                }
                else
                {
                    UpdateInfoText("NotEnoughItems");
                }
            }

            isButtonClicked = true;
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
                return;
            }
            //Gör så att vapnets magasin kan ha fler patroner
            if (interactingPlayer.tag.Equals("Player1"))
            {
                if (playerOneRM.Get(ResourceManager.ItemType.Battery) >= 1 && playerOneRM.Get(ResourceManager.ItemType.Scrap) >= 3)
                {
                    playerOneRM.Offset(ResourceManager.ItemType.Battery, -1);
                    playerOneRM.Offset(ResourceManager.ItemType.Scrap, -3);
                    playerOneWeapon.SetMagCapacity(12);
                    playerOneWeapon.ReloadOnce();
                    list.Add(currentPlayerTag);

                    UpdateInfoText("GotUpgrade");
                    playerOneMagazineUpgrade.GetComponent<Button>().interactable = false;

                }
                else
                {
                    UpdateInfoText("NotEnoughItems");
                }
                
            }
            else
            {
                if (playerTwoRM.Get(ResourceManager.ItemType.Battery) >= 1 && playerTwoRM.Get(ResourceManager.ItemType.Scrap) >= 3)
                {
                    playerTwoRM.Offset(ResourceManager.ItemType.Battery, -1);
                    playerTwoRM.Offset(ResourceManager.ItemType.Scrap, -3);
                    playerTwoWeapon.SetMagCapacity(12);
                    list.Add(currentPlayerTag);
                    playerTwoWeapon.ReloadOnce();

                    UpdateInfoText("GotUpgrade");
                    playerTwoMagazineUpgrade.GetComponent<Button>().interactable = false;

                }
                else
                {
                    UpdateInfoText("NotEnoughItems");
                }
            }
            isButtonClicked = true;


        }
    }

    public void TotalAmmoUpgrade()
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
                return;
            }
            if (interactingPlayer.tag.Equals("Player1"))
            {
                if (playerOneRM.Get(ResourceManager.ItemType.Battery) >= 3 && playerOneRM.Get(ResourceManager.ItemType.Scrap) >= 1)
                {
                    playerOneRM.SetMaxAmmo(150);
                    list.Add(currentPlayerTag);
                    UpdateInfoText("GotUpgrade");
                    playerOneFlashLightUpgrade.GetComponent<Button>().interactable = false;
                }
                else
                {
                    UpdateInfoText("NotEnoughItems");
                }
            }
            else
            {
                if (playerTwoRM.Get(ResourceManager.ItemType.Battery) >= 3 && playerTwoRM.Get(ResourceManager.ItemType.Scrap) >= 1)
                {
                    playerTwoRM.SetMaxAmmo(150);
                    list.Add(currentPlayerTag);
                    UpdateInfoText("GotUpgrade");
                    playerTwoFlashLightUpgrade.GetComponent<Button>().interactable = false;
                }
                else
                {
                    UpdateInfoText("NotEnoughItems");
                }
            }
            //gör så att ficklampans batterie räcker längre
           
            isButtonClicked = true;
        }

    }

    /**
     * Metoden körs endast första gången spelaren interagerar med craftingbordet, därefter cachas allt som craftingen behöver från spelaren
     */

    private void SetCurrentCanvas()
    {
        if(interactingPlayer.tag.Equals("Player1"))
        {
            playerOneCanvas = interactingPlayer.GetComponentInChildren<Canvas>();
            playerOneButtons = playerOneCanvas.gameObject.transform.Find("CraftingTable").gameObject;
            playerOneButtons.SetActive(true);

            playerOneDamageUpgrade = playerOneButtons.gameObject.transform.Find("DamageUpgrade").gameObject;
            playerOneMagazineUpgrade = playerOneButtons.gameObject.transform.Find("MagazineUpgrade").gameObject;
            playerOneFlashLightUpgrade = playerOneButtons.gameObject.transform.Find("TotalAmmoUpgrade").gameObject;
            playerOneCancelButton = playerOneButtons.gameObject.transform.Find("CancelButton").gameObject;

            playerOneDamageUpgrade.gameObject.GetComponent<Button>().onClick.AddListener(delegate { DamageUpgrade(); });
            playerOneMagazineUpgrade.GetComponent<Button>().onClick.AddListener(delegate { IncreaseMagazineSize(); });
            playerOneFlashLightUpgrade.GetComponent<Button>().onClick.AddListener(delegate { TotalAmmoUpgrade(); });

            playerOneRM = interactingPlayer.GetComponentInChildren<ResourceManager>();
            playerOneWeapon = interactingPlayer.GetComponentInChildren<Weapon>();
            playerOneFlashLight = interactingPlayer.GetComponentInChildren<FlashLight>();

            SetCurrentEventSystem(playerOneButtons);
        }
        else
        {
            playerTwoCanvas = interactingPlayer.GetComponentInChildren<Canvas>();
            playerTwoButtons = playerTwoCanvas.gameObject.transform.Find("CraftingTable").gameObject;
            playerTwoButtons.SetActive(true);

            playerTwoDamageUpgrade = playerTwoButtons.gameObject.transform.Find("DamageUpgrade").gameObject;
            playerTwoMagazineUpgrade = playerTwoButtons.gameObject.transform.Find("MagazineUpgrade").gameObject;
            playerTwoFlashLightUpgrade = playerTwoButtons.gameObject.transform.Find("TotalAmmoUpgrade").gameObject;
            playerTwoCancelButton = playerTwoButtons.gameObject.transform.Find("CancelButton").gameObject;

            playerTwoDamageUpgrade.gameObject.GetComponent<Button>().onClick.AddListener(delegate { DamageUpgrade(); });
            playerTwoMagazineUpgrade.GetComponent<Button>().onClick.AddListener(delegate { IncreaseMagazineSize(); });
            playerTwoFlashLightUpgrade.GetComponent<Button>().onClick.AddListener(delegate { TotalAmmoUpgrade(); });

            playerTwoRM = interactingPlayer.GetComponentInChildren<ResourceManager>();
            playerTwoWeapon = interactingPlayer.GetComponentInChildren<Weapon>();
            playerTwoFlashLight = interactingPlayer.GetComponentInChildren<FlashLight>();
            SetCurrentEventSystem(playerTwoButtons);
        }
        interactedPlayers.Add(interactingPlayer.tag);
        /*
        currentCanvas = interactingPlayer.GetComponentInChildren<Canvas>();
        GameObject craftingButtons = currentCanvas.gameObject.transform.Find("CraftingTable").gameObject;
        
        craftingButtons.SetActive(true);
        //craftingButtons.gameObject.transform.Find("CancelButton").gameObject.GetComponent<Button>().onClick.AddListener(delegate { ToggleCraftingBench(); });
        craftingButtons.gameObject.transform.Find("DamageUpgrade").gameObject.GetComponent<Button>().onClick.AddListener(delegate { DamageUpgrade(); });
        craftingButtons.gameObject.transform.Find("fireRateUpgrade").gameObject.GetComponent<Button>().onClick.AddListener(delegate { flashLightUpgrade(); });
        craftingButtons.gameObject.transform.Find("MagazineUpgrade").gameObject.GetComponent<Button>().onClick.AddListener(delegate { IncreaseMagazineSize(); });
        
        SetCurrentEventSystem(craftingButtons);
        */
    }

    private void ActivateInteractingPlayer()
    {
        if(interactingPlayer.tag == "Player1")
        {
            playerOneButtons.SetActive(true);
            playerOneEventSystem.SetSelectedGameObject(playerOneCancelButton);
        }
        else
        {
            playerTwoButtons.SetActive(true);
            playerTwoEventSystem.SetSelectedGameObject(playerTwoCancelButton);
        }
        
    }

    private void SetCurrentEventSystem(GameObject craftingButtons)
    {
        if(interactingPlayer.tag.Equals("Player1"))
        {
            playerOneEventSystem = interactingPlayer.transform.Find("EventSystem").GetComponent<EventSystem>();
            playerOneEventSystem.SetSelectedGameObject(playerOneCancelButton);
        }
        else
        {
            playerTwoEventSystem = interactingPlayer.transform.Find("EventSystem").GetComponent<EventSystem>();
            playerTwoEventSystem.SetSelectedGameObject(playerTwoCancelButton);
        }
        /*
        currentPlayerEventSystem = interactingPlayer.transform.Find("EventSystem").GetComponent<EventSystem>();
        currentPlayerEventSystem.SetSelectedGameObject(craftingButtons.gameObject.transform.Find("CancelButton").gameObject);
        */
    }

    private void RemoveCurrentPlayer()
    {
        if(currentPlayerTag == "Player1")
        {
            playerOneButtons.SetActive(false);
        }
        else
        {
            playerTwoButtons.SetActive(false);
        }
        currentPlayerTag = null;
        //currentCanvas.gameObject.transform.Find("CraftingTable").gameObject.SetActive(false);
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
