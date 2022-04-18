using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class UIHandler : MonoBehaviour
{
    public RM rm;
    [SerializeField] private TMP_Text ammoText;
    [SerializeField] private TMP_Text batteryText;
    [SerializeField] private TMP_Text scrapText;

    private int maxAmmo = 100; //detta bör flyttas. Annars finns maxAmmo i både AmmoPickUpHandler och UIHandler
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        UpdateAmmoText();
    }


    
    private void UpdateAmmoText()
    {
        ammoText.gameObject.SetActive(false);
        ammoText.text = rm.GetTotalAmmo() + " / " + rm.GetTotalAmmo();
        ammoText.gameObject.SetActive(true);
    }
}
