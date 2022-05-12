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
    public ResourceManager rm;

    [SerializeField] private int scrapAmountNeeded;
    [SerializeField] private GameObject canvas;
    [SerializeField] private Font font;
    [SerializeField] private EventSystem eventSystem;
    
    //Används för att kunna identifiera vilken spelare det är som interagerar med craftingbordet
    [SerializeField] private Interactable inter; 

    [SerializeField] public string currentPlayerTag;
    private Text infoText;
    private bool isToggled;

    //Listorna är till för att hålla koll på om en viss spelare redan har en uppgradering.
    private List<string> damageUpgradedPlayers = new List<string>();
    private List<string> MagazineUpgradedPlayers = new List<string>();
    private List<string> flashLightUpgradedPlayers = new List<string>();

    private Canvas currentCanvas;
    private GameObject damageUpgrade;
    private GameObject magazineUpgrade;
    private GameObject flashlightUpgrade;
    private GameObject cancelButton;


    public GameObject interactingPlayer;

    private bool isShowingInfoText;

    private float textTimer;

    private bool hasUpgradedDamage;
    private bool hasMagazineSizeUpgrade;
    private bool hasFlashlightUpgrade;

    private bool buttonsEnabled;

    private void Start()
    {
        
        infoText = canvas.AddComponent<Text>();
        infoText.font = font;
        infoText.fontSize = 32;
        infoText.enabled = false;
       

        damageUpgrade = GameObject.Find("DamageUpgrade");
        magazineUpgrade = GameObject.Find("MagazineUpgrade");
        flashlightUpgrade = GameObject.Find("fireRateUpgrade");
        cancelButton = GameObject.Find("CancelButton");
        
        
        damageUpgrade.SetActive(false);
        magazineUpgrade.SetActive(false);
        flashlightUpgrade.SetActive(false);
        cancelButton.SetActive(false);
        
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
            currentCanvas = GameObject.FindGameObjectWithTag(currentPlayerTag).GetComponentInChildren<Canvas>();
            GameObject craftingButtons = currentCanvas.gameObject.transform.Find("CraftingTable").gameObject;
            craftingButtons.SetActive(true);
            craftingButtons.gameObject.transform.Find("DamageUpgrade").gameObject.GetComponent<Button>().onClick.AddListener(delegate { DamageUpgrade(); });
            craftingButtons.gameObject.transform.Find("fireRateUpgrade").gameObject.GetComponent<Button>().onClick.AddListener(delegate { flashLightUpgrade(); });
            craftingButtons.gameObject.transform.Find("MagazineUpgrade").gameObject.GetComponent<Button>().onClick.AddListener(delegate { IncreaseMagazineSize(); });
            buttonsEnabled = true;
            
        }

        if (isToggled)
        {
            float distance = Vector3.Distance(gameObject.transform.position, GameObject.FindGameObjectWithTag(currentPlayerTag).transform.position);
            if(distance > 2)
            {
                ToggleCraftingBench();
            }
        }
        
     }

    public void ToggleCraftingBench()
    {
        
        //toggleButtons();
        if (!isToggled)
        {
            
            Cursor.lockState = CursorLockMode.None;
            isToggled = true;
            infoText.enabled = true;
            eventSystem.SetSelectedGameObject(cancelButton);
            infoText.text = "Craft here! \n" + "Upgrade damage: 2 Batteries, 2 Scraps \n" + "Upgrade magazine: 1 Battery, 3 Scraps \n" + "Upgrade flashlight: 3 Batteries, 1 Scrap";
            
        }
        else
        {
            isToggled = false;
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
            inter.interactingGameObject.GetComponentInChildren<Weapon>().SetDamage(35);

            damageUpgradedPlayers.Add(inter.interactingGameObject.transform.parent.tag);
            UpdateInfoText("GotUpgrade");
            Debug.Log("GOT UPGRADE");
        }
        else
        {
            Debug.Log("Too few batteries pal");
            Debug.Log(inter.interactingGameObject.transform.parent.tag);
            UpdateInfoText("NotEnoughItems");
        }


    }

    public void IncreaseMagazineSize()
    {
        //Gör så att vapnets magasin kan ha fler patroner
        if (MagazineUpgradedPlayers.Contains(inter.interactingGameObject.transform.parent.tag))
        {
            UpdateInfoText("AlreadyHasUpgrade");
        }
        else if (!hasMagazineSizeUpgrade && inter.interactingGameObject.GetComponentInChildren<ResourceManager>().Get(ResourceManager.ItemType.Battery) >= 1 && inter.interactingGameObject.GetComponentInChildren<ResourceManager>().Get(ResourceManager.ItemType.Scrap) >= 3)
        {
            inter.interactingGameObject.GetComponentInChildren<ResourceManager>().Offset(ResourceManager.ItemType.Battery, -1);
            inter.interactingGameObject.GetComponentInChildren<ResourceManager>().Offset(ResourceManager.ItemType.Scrap, 3);
            inter.interactingGameObject.GetComponentInChildren<Weapon>().SetMagCapacity(12);
            MagazineUpgradedPlayers.Add(inter.interactingGameObject.transform.parent.tag);
            UpdateInfoText("GotUpgrade");

        }
        else
        {
            UpdateInfoText("NotEnoughItems");
        }
    }

    public void flashLightUpgrade()
    {
        if (flashLightUpgradedPlayers.Contains(inter.interactingGameObject.transform.parent.tag))
        {
            UpdateInfoText("AlreadyHasUpgrade");
        }
        //gör så att ficklampans batterie räcker längre
        else if (!hasFlashlightUpgrade && inter.interactingGameObject.GetComponentInChildren<ResourceManager>().Get(ResourceManager.ItemType.Battery) >= 3 && inter.interactingGameObject.GetComponentInChildren<ResourceManager>().Get(ResourceManager.ItemType.Scrap) >= 1)
        {
            inter.interactingGameObject.GetComponentInChildren<ResourceManager>().Offset(ResourceManager.ItemType.Battery, -3);
            inter.interactingGameObject.GetComponentInChildren<ResourceManager>().Offset(ResourceManager.ItemType.Scrap, -1);
            inter.interactingGameObject.GetComponentInChildren<FlashLight>().SetDrainMultiplier(0.05);
            flashLightUpgradedPlayers.Add(inter.interactingGameObject.transform.parent.tag);
            Debug.Log(inter.interactingGameObject.transform.parent.tag);
            UpdateInfoText("GotUpgrade");
        }
        else
        {
            UpdateInfoText("NotEnoughItems");
        }
        
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
