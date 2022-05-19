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

    private Color originalColor = new Color(61f, 104f, 93f);

    private GameObject greenColorButton;
    private GameObject whiteColorButton;
    private GameObject cancelButton;

    private bool isToggled;
    // Start is called before the first frame update
    void Start()
    {
        greenColorButton = GameObject.Find("GreenColorButton");
        whiteColorButton = GameObject.Find("WhiteColorButton");
        cancelButton = GameObject.Find("CancelButton");

        greenColorButton.SetActive(false);
        whiteColorButton.SetActive(false);
        cancelButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ToggleCustomizationTable()
    {
        ToggleButtons();
        if (!isToggled)
        {
            isToggled = true;
            eventSystem.SetSelectedGameObject(cancelButton);
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

}
