using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour {
	public RM rm;
	//Shooting
	[SerializeField] private int damage = 20;
	[SerializeField] private float range = 100.0f;
	[SerializeField] private float fireRate = 5.0f;
	//[SerializeField] private TextMeshProUGUI ammoText; // ammo Text UI; @Khaled Alraas //bör ej finnas här Simon.
	private float nextTimeToFire;

	//Ammo
	[SerializeField] private int totalAmmo;
	[SerializeField] private int magCapacity = 8;
	[SerializeField] private float reloadTime = 2.0f;
	private int currentMag;
	private bool isReloading;

	private bool isFiring;
	private bool isReloadPressed;
	
	[SerializeField] private Camera fpsCamera;

	void Start()
	{
		totalAmmo = rm.GetTotalAmmo();// var 100. Uppdaterat av Simon till rm.GetTotalAmmo()
		currentMag = magCapacity;
	}

	void Update()
	{
		UserInput();
	}

	/**
	 * @Author Martin Wallmark
	 */
	public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
			isFiring = true;
        }

        if (context.canceled)
        {
			isFiring = false;
        }
    }

	public void OnReload(InputAction.CallbackContext context)
    {
		if (context.performed)
		{
			isFiring = true;
		}

		if (context.canceled)
		{
			isFiring = false;
		}
	}
	
	/**
	 * @Author Axel Sterner
	 * @Simon Hessling Oscarson finns i RM.
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
	 * 
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
	 * @Author Simon Hessling Oscarson
	 */
	public int GetCurrentMag() { return currentMag; }
	/**
	 * @Author Markus Larsson and Khaled Alrass
	 */
	private void UserInput()
	{
		if (isFiring || Input.GetKeyDown(KeyCode.Mouse1) && Time.time >= nextTimeToFire && !isReloading && currentMag > 0){
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
	 * @Author Simon Hessling Oscarson. Minskar inte total ammo längre.
	 */
	private void Fire(){
		currentMag--;
		//totalAmmo--;

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
	 * @Simon Hessling Oscarson
	 * Reloads the current magazine.
	 */
	IEnumerator Reload(){
		if (rm.GetTotalAmmo() != 0) // ifall man har något extra ammo
		{
			isReloading = true;
			Debug.Log("Reloading...");
			yield return new WaitForSeconds(reloadTime);
			rm.SubTotalAmmo(magCapacity - currentMag);
			if (currentMag + rm.GetTotalAmmo() >= magCapacity)//gör så det inte går att få mer än magCapacity i magget
			{
				currentMag = magCapacity;
			}
			else
			{
				
				
				
				int tempMagSize = currentMag;
				rm.AddTotalAmmo(tempMagSize - magCapacity);
				currentMag += rm.GetTotalAmmo();


			}	
			Debug.Log("Reloaded!");
			isReloading = false;
		}
	}
	
	/**
	 * @Author Khaled Alraas
	 * @Simon Hessling Oscarson. Tagit bort texten.
	 */
	private void SetAmmoText()
	{
		// set ammo Text UI
		//ammoText.text = totalAmmo.ToString();
	}
}