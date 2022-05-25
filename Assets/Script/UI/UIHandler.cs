using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public ResourceManager rm;
    public Weapon weapon;
    [SerializeField] private TextMeshProUGUI ammoText;
    [SerializeField] private TMP_Text batteryText;
    [SerializeField] private TMP_Text scrapText;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private Image gunImageSmall;
    [SerializeField] private Image axeImageSmall;
    [SerializeField] private Image gunImageBig;
    [SerializeField] private Image axeImageBig;
    [SerializeField] private Image ak47ImageBig;
    [SerializeField] private Image ak47ImageSmall;

    private void Start()
    {
        gunImageSmall.enabled = false;
        axeImageBig.enabled = false;
        ak47ImageBig.enabled = false;
    }

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
        batteryText.text = rm.Get(ResourceManager.ItemType.Battery) + " / "+rm.GetMaxBatteries();
    }
    
    /**
	 * @Author Simon Hessling Oscarson
	 */
    private void UpdateScrapsText()
    {
        scrapText.text = rm.Get(ResourceManager.ItemType.Scrap)+"";
    }

    public void SwitchWeaponIcons(string currentWeapon)
    {
        switch (currentWeapon)
        {
            case "Melee":
                EnlargeMeleeIcon();
                break;
            case "Pistol":
                EnlargePistolIcon();
                break;
            case "AK47":
                EnlargeAKIcon();
                break;
        }
    }

    public void SetCurrentHealth(int currentHealth)
    {
        healthText.text = currentHealth+"";
    }

    private void EnlargeMeleeIcon()
    {
        gunImageBig.enabled = false;
        gunImageSmall.enabled = true;

        axeImageBig.enabled = true;
        axeImageSmall.enabled = false;

        ak47ImageBig.enabled = false;
        ak47ImageSmall.enabled = true;

    }

    private void EnlargePistolIcon()
    {
        gunImageBig.enabled = true;
        gunImageSmall.enabled = false;

        axeImageBig.enabled = false;
        axeImageSmall.enabled = true;

        ak47ImageBig.enabled = false;
        ak47ImageSmall.enabled = true;


    }

    private void EnlargeAKIcon()
    {

        ak47ImageBig.enabled = true;
        ak47ImageSmall.enabled = false;

        gunImageBig.enabled = false;
        gunImageSmall.enabled = true;

        axeImageBig.enabled = false;
        axeImageSmall.enabled = true;

    }
}
