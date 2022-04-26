using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class UIHandler : MonoBehaviour
{
    public RM rm;
    public Weapon weapon;
    [SerializeField] private TextMeshProUGUI ammoText;
    [SerializeField] private TMP_Text batteryText;
    [SerializeField] private TMP_Text scrapText;

    private int maxAmmo = 100; //detta bör flyttas. Annars finns maxAmmo i både AmmoPickUpHandler och UIHandler
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    void Update()
    {

       UpdateAmmoText();
        UpdateBatteryText();
        UpdateScrapsText();
    }


    
    private void UpdateAmmoText()
    {
        
        ammoText.text = weapon.GetCurrentMag() + " / " + rm.GetTotalAmmo().ToString();
        
    }
    private void UpdateBatteryText()
    {

        batteryText.text ="batteries "+ rm.GetCurrentBatteries() + " / 5";

    }
    private void UpdateScrapsText()
    {

        scrapText.text = "scraps "+rm.GetCurrentScraps();

    }
}
