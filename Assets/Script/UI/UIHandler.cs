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
    [SerializeField] private Image GunImageSmall;
    [SerializeField] private Image AxeImageSmall;
    [SerializeField] private Image GunImageBig;
    [SerializeField] private Image AxeImageBig;

    private void Start()
    {
        GunImageSmall.enabled = false;
        AxeImageBig.enabled = false;
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
        }
    }

    public void SetCurrentHealth(int currentHealth)
    {
        healthText.text = currentHealth+"";
    }

    private void EnlargeMeleeIcon()
    {
        GunImageBig.enabled = false;
        GunImageSmall.enabled = true;

        AxeImageBig.enabled = true;
        AxeImageSmall.enabled = false;

    }

    private void EnlargePistolIcon()
    {
        GunImageBig.enabled = true;
        GunImageSmall.enabled = false;

        AxeImageBig.enabled = false;
        AxeImageSmall.enabled = true;


    }
}
