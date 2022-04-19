using System;
using System.Collections;
using UnityEngine;
using TMPro;


public class Weapon : MonoBehaviour {
	//Fire
	[SerializeField] private int damage = 20;
	[SerializeField] private float range = 100.0f;
	[SerializeField] private float fireRate = 5.0f;
	[SerializeField] private TextMeshProUGUI ammoText; // ammo Text UI; @Khaled Alraas
	private float nextTimeToFire;

	[SerializeField] private Camera fpsCamera;

	//Ammo
	[SerializeField] private int maxAmmo = 100;
	[SerializeField] private int magCapacity = 8;
	[SerializeField] private float reloadTime = 2.0f;
	private int currentMag;
	private bool isReloading;

	private int ammo = 32; //extra ammo
	public int getAmmo() { return ammo; }

	public int getDamage() { return damage; }
	public void setAmmo(int newAmmo)
    {
		ammo += newAmmo;
    }

	public void setDamage(int newDamage)
    {
		damage = newDamage;
    }

	public void setMagCapacity(int newMagCapacity)
    {
		magCapacity = newMagCapacity;
    }

	public void resetAmmo()
    {
		ammo = 100;
    }

	private void Start(){
		currentMag = magCapacity;
	}

	void Update(){
		if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire && !isReloading){
			nextTimeToFire = Time.time + 1.0f / fireRate;
			Fire();
			SetAmmoText(); // show ammo text;  @Khaled Alraas
		}
		else if(Input.GetKeyDown(KeyCode.R) && !isReloading){
			StartCoroutine(Reload());
			SetAmmoText(); // show ammo text; @Khaled Alraas
		}
	}

	
	/**
	 * @Author Markus Larsson
	 *
	 * Shoots from the referenced camera 10 units forward.
	 */
	private void Fire(){
		currentMag--;
		ammo--;

		RaycastHit hit;
		if(Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range)){
			Target target = hit.transform.GetComponent<Target>();
			Debug.Log("Hit: " + hit.transform.name + ", Remaining ammo: " + ammo);
			Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.red, 2);
			if(target != null){
				target.TakeDamage(damage);
			}
		}
	}

	IEnumerator Reload(){
		isReloading = true;
		Debug.Log("Reloading...");

		yield return new WaitForSeconds(reloadTime);
		currentMag = magCapacity;
		ammo -= magCapacity;
		
		Debug.Log("Reloaded!");
		isReloading = false;
	}
	
	private void SetAmmoText()
	{  // set ammo Text UI; @Khaled Alraas
		ammoText.text = ammo.ToString();
	}
}