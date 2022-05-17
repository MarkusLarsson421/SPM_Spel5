using UnityEngine;

[System.Serializable]
public class PlayerData{
	//Weapons
	private byte ammoMag;
	private float batteryCharge;
	
	//Stats
	private string tag;
	private byte health;
	private float stamina;
	private float[] pos;

	//Resources
	private byte scrap;
	private byte batteries;
	private byte ammo;

	//Maybe add isFiring and isReloading?

	public PlayerData(Weapon pistol, FlashLight flashLight, ResourceManager rm, PlayerStats stats){
		//Weapons
		ammoMag = (byte)pistol.GetCurrentMag();
		batteryCharge = flashLight.GetBatteryCharge();
		
		//Stats
		tag = stats.tag;
		health = (byte)stats.GetHealth();
		stamina = stats.getStamina();

		pos = new float[3];
		Vector3 position = stats.transform.position;
		pos[0] = position.x;
		pos[1] = position.y;
		pos[2] = position.z;

		scrap = (byte)rm.Get(ResourceManager.ItemType.Scrap);
		batteries = (byte)rm.Get(ResourceManager.ItemType.Battery);
		ammo = (byte)rm.Get(ResourceManager.ItemType.Ammo);
	}
}
