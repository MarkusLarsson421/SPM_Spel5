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

    private GameObject greenColorButton;
    private GameObject whiteColorButton;


    private
    // Start is called before the first frame update
    void Start()
    {
        greenColorButton = GameObject.Find("GreenColorButton");
        whiteColorButton = GameObject.Find("WhiteColorButton"); 

        greenColorButton.SetActive(false);
        whiteColorButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
