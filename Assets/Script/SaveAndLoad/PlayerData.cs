using UnityEngine;

[System.Serializable]
public class PlayerData{
	//Weapons
	private byte ammoMag{get;set;}
	private float batteryCharge{get;set;}
	
	//Stats
	private string tag{get;set;}
	private byte health{get;set;}
	private float stamina{get;set;}
	private float[] pos{get;set;}
	private float[] quaternion{get;set;}

	//Resources
	private byte scrap{get;set;}
	private byte batteries{get;set;}
	private byte ammo{get;set;}

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

		quaternion = new float[4];
		Quaternion quat = stats.transform.rotation;
		quaternion[0] = quat.x;
		quaternion[1] = quat.y;
		quaternion[2] = quat.z;
		quaternion[3] = quat.w;
		

		scrap = (byte)rm.Get(ResourceManager.ItemType.Scrap);
		batteries = (byte)rm.Get(ResourceManager.ItemType.Battery);
		ammo = (byte)rm.Get(ResourceManager.ItemType.Ammo);
	}
}
