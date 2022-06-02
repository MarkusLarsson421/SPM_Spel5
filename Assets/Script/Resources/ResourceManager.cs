using System;
using UnityEngine;

public class ResourceManager : MonoBehaviour, Saveable
{
	[SerializeField] private int ammo = 0;
	[SerializeField] private int ammoMax = 20;
	[SerializeField] private int batteries = 0;
	[SerializeField] private int batteriesMax = 4;
	[SerializeField] private int scrap = 0;
	[SerializeField] private int scrapMax = 4;

	private int aP1;
	private int aP2;

	public enum ItemType{
		Scrap,
		Battery,
		Ammo,
	}

	/**
	 * @Author Markus Larsson
	 */
    public int Get(ItemType type){
	    switch(type){
		    case ItemType.Battery:
			    return batteries;
		    case ItemType.Scrap:
			    return scrap;
		    case ItemType.Ammo:
			    return ammo;
	    }
	    return -1;
    }

    /**
	 * @Author Markus Larsson
	 */
    public void SetTotal(ItemType type, int amount)
    {
	    switch(type){
		    case ItemType.Battery:
				batteries = amount;
			    break;
		    case ItemType.Scrap:
			    scrap = amount;
			    break;
		    case ItemType.Ammo:
			    ammo = amount;
			    break;
	    }
    }

    /**
	 * @Author Markus Larsson
	 */
    public void Offset(ItemType type, int amount)
    {
	    switch(type){
		    case ItemType.Battery:
			    batteries += amount;
			    break;
		    case ItemType.Scrap:
			    scrap += amount;
			    break;
		    case ItemType.Ammo:
			    ammo += amount;
			    break;
	    }
    }
	/**
	 * @Author Martin Wallmark
	 */
	public int GetMaxAmount(ItemType type)
    {
		switch (type)
		{
			case ItemType.Battery:
				return batteriesMax;
			case ItemType.Scrap:
				return scrapMax;
			case ItemType.Ammo:
				return ammoMax;
				
		}
		return 0;
	}

	public int GetMaxBatteries()
    {
		return batteriesMax;
    }

	public void SetMaxAmmo(int nMaxAmmo)
    {
		ammoMax = nMaxAmmo;
    }

    public object CaptureState()
    {
		return new SaveData()
		{
			ammo = ammo,
			batteries = batteries,
			scraps = scrap
		};
	}

    public void RestoreState(object state)
    {
		SaveData saveData = (SaveData)state;
		ammo = saveData.ammo;
		batteries= saveData.batteries;
		scrap = saveData.scraps;
	}


	[Serializable]
	private struct SaveData
	{
		public int ammo;
		public int scraps;
		public int batteries;
	}
}
