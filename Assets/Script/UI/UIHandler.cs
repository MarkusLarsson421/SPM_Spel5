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
    void Update()
    {

       UpdateAmmoText();
        UpdateBatteryText();
        UpdateScrapsText();
    }


    /**
	 * @Author Simon Hessling Oscarson
	 */
    private void UpdateAmmoText()
    {
        
        ammoText.text = weapon.GetCurrentMag() + " / " + rm.GetTotalAmmo().ToString();
        
    }
    /**
	 * @Author Simon Hessling Oscarson
	 */
    private void UpdateBatteryText()
    {

        batteryText.text ="batteries "+ rm.GetCurrentBatteries() + " / 5";

    }
    /**
	 * @Author Simon Hessling Oscarson
	 */
    private void UpdateScrapsText()
    {

        scrapText.text = "scraps "+rm.GetCurrentScraps();

    }
}
