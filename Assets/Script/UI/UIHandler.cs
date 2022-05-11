using UnityEngine;
using TMPro;

public class UIHandler : MonoBehaviour
{
    public ResourceManager rm;
    public Weapon weapon;
    [SerializeField] private TextMeshProUGUI ammoText;
    [SerializeField] private TMP_Text batteryText;
    [SerializeField] private TMP_Text scrapText;
    
    private void Update()
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
        ammoText.text = weapon.GetCurrentMag() + " / " + rm.Get(ResourceManager.ItemType.Ammo);
    }
    
    /**
	 * @Author Simon Hessling Oscarson
	 */
    private void UpdateBatteryText()
    {
        batteryText.text ="batteries "+ rm.Get(ResourceManager.ItemType.Battery) + " /"+rm.GetMaxBatteries();
    }
    
    /**
	 * @Author Simon Hessling Oscarson
	 */
    private void UpdateScrapsText()
    {
        scrapText.text = "scraps "+rm.Get(ResourceManager.ItemType.Scrap);
    }
}
