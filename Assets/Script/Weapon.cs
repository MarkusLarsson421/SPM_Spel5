using System;
using System.Collections;
using UnityEngine;
using TMPro;


public class Weapon : MonoBehaviour{
	//Fire
	[SerializeField] private int damage = 20;
	[SerializeField] private float range = 100.0f;
	[SerializeField] private float fireRate = 5.0f;
	[SerializeField] private TextMeshProUGUI ammoText;
	private float nextTimeToFire;
	
	[SerializeField] private Camera fpsCamera;
	
	//Ammo
	[SerializeField] private int maxAmmo = 100;
	[SerializeField] private int magCapacity = 8;
	[SerializeField] private float reloadTime = 2.0f;
	private int currentAmmo;
	private bool isReloading;
	
	private int ammo = 32;
	private void setAmmText() { ammoText.text = ammo.ToString(); }

	private void Start(){
		currentAmmo = magCapacity;
	}

	void Update(){
		setAmmText();

		if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire && !isReloading){
			nextTimeToFire = Time.time + 1.0f / fireRate;
			Fire();
		}
		else if(Input.GetKeyDown(KeyCode.R) && !isReloading){
			StartCoroutine(Reload());
		}
	}

	private void Fire(){
		ammo--;
		
		RaycastHit hit;
		if(Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range)){
			Target target = hit.transform.GetComponent<Target>();
			if(target != null){
				target.TakeDamage(damage);
			}
		}
	}

	IEnumerator Reload(){
		isReloading = true;
		Debug.Log("Reloading...");

		yield return new WaitForSeconds(reloadTime);
		currentAmmo = magCapacity;
		ammo -= magCapacity;
		
		Debug.Log("Reloaded.");
		isReloading = false;
	}
}