using System.Collections;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour {
	//Shooting
	[SerializeField] private int damage = 20;
	[SerializeField] private float range = 100.0f;
	[SerializeField] private float fireRate = 5.0f;
	[SerializeField] private TextMeshProUGUI ammoText; // ammo Text UI; @Khaled Alraas
	private float nextTimeToFire;

	//Ammo
	[SerializeField] private int totalAmmo;
	[SerializeField] private int magCapacity = 8;
	[SerializeField] private float reloadTime = 2.0f;
	private int currentMag;
	private bool isReloading;
	
	[SerializeField] private Camera fpsCamera;

	void Start()
	{
		totalAmmo = magCapacity * 2;
		currentMag = magCapacity;
	}

	void Update()
	{
		UserInput();
	}
	
	/**
	 * @Author Axel Sterner
	 */
	public int GetAmmo() { return totalAmmo; }

	/**
	 * @Author Axel Sterner
	 */
	public void SetAmmo(int newAmmo)
	{
		totalAmmo += newAmmo;
	}
	
	/**
	 * @Author Axel Sterner
	 */
	public void ResetAmmo()
	{
		totalAmmo = 100;
	}

	/**
	 * @Author Martin Wallmark
	 */
	public void SetDamage(int newDamage)
	{
		damage = newDamage;
	}
	
	/**
	 * @Author Martin Wallmark
	 */
	public void SetMagCapacity(int newMagCapacity)
	{
		magCapacity = newMagCapacity;
	}

	/**
	 * @Author Markus Larsson and Khaled Alrass
	 */
	private void UserInput()
	{
		if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire && !isReloading && currentMag > 0){
			nextTimeToFire = Time.time + 1.0f / fireRate;
			Fire();
			SetAmmoText();
		}
		else if(Input.GetKeyDown(KeyCode.R) && !isReloading){
			StartCoroutine(Reload());
			SetAmmoText();
		}
	}
	
	/**
	 * @Author Markus Larsson
	 *
	 * Shoots from the referenced camera 10 units forward.
	 */
	private void Fire(){
		currentMag--;
		totalAmmo--;

		RaycastHit hit;
		if(Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range)){
			Zombie target = hit.transform.GetComponent<Zombie>();
			Debug.Log("Hit: " + hit.transform.name + ", Remaining ammo: " + totalAmmo);
			Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.red, 2);
			if(target != null){
				target.TakeDamage(damage);
			}
		}
	}

	/**
	 * @Author Markus Larsson
	 *
	 * Reloads the current magazine.
	 */
	IEnumerator Reload(){
		isReloading = true;
		Debug.Log("Reloading...");

		yield return new WaitForSeconds(reloadTime);
		currentMag = magCapacity;
		totalAmmo -= magCapacity;
		
		Debug.Log("Reloaded!");
		isReloading = false;
	}
	
	/**
	 * @Author Khaled Alraas
	 */
	private void SetAmmoText()
	{
		// set ammo Text UI
		ammoText.text = totalAmmo.ToString();
	}
}