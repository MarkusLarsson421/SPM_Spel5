using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * @Authors Martin Wallmark, Simon Hessling Oscarson
 */
public class PlayerSettings : MonoBehaviour
{
    [SerializeField] private ResourceManager rm;
    [SerializeField] private ResourceManager rm2;
    [SerializeField] private GameObject zOP;
    // Start is called before the first frame update

    private void Awake()
    {

    }
    public void SavePlayerRM()
    {

        PlayerPrefs.SetInt("CurrentAmmo", rm.Get(ResourceManager.ItemType.Ammo));
        PlayerPrefs.SetInt("CurrentScraps", rm.Get(ResourceManager.ItemType.Scrap));
        PlayerPrefs.SetInt("CurrentBatteries", rm.Get(ResourceManager.ItemType.Battery));
        if(rm2 != null)
        {
            PlayerPrefs.SetInt("CurrentAmmo2", rm2.Get(ResourceManager.ItemType.Ammo));
            PlayerPrefs.SetInt("CurrentScraps2", rm2.Get(ResourceManager.ItemType.Scrap));
            PlayerPrefs.SetInt("CurrentBatteries2", rm2.Get(ResourceManager.ItemType.Battery));
        }
        PlayerPrefs.Save();

    }


    public void addRM(ResourceManager rm)
    {
        this.rm = rm;
    }

    public void addRM2(ResourceManager rm)
    {
        rm2 = rm;
    }

    public void SetPlayerOneRM()
    {
        rm.SetTotal(ResourceManager.ItemType.Ammo, PlayerPrefs.GetInt("CurrentAmmo"));
        rm.SetTotal(ResourceManager.ItemType.Scrap, PlayerPrefs.GetInt("CurrentScraps"));
        rm.SetTotal(ResourceManager.ItemType.Battery, PlayerPrefs.GetInt("CurrentBatteries"));


    }

    public void SetPlayerTwoRM()
    {
        rm2.SetTotal(ResourceManager.ItemType.Ammo, PlayerPrefs.GetInt("CurrentAmmo2"));
        rm2.SetTotal(ResourceManager.ItemType.Scrap, PlayerPrefs.GetInt("CurrentScraps2"));
        rm2.SetTotal(ResourceManager.ItemType.Battery, PlayerPrefs.GetInt("CurrentBatteries2"));
    }



}
