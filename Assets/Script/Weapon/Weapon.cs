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

	private ParticleSystem muzzleFlash;
	
	[SerializeField] private Camera fpsCamera;

	void Start()
	{
		totalAmmo = rm.GetTotalAmmo();// var 100. Uppdaterat av Simon till rm.GetTotalAmmo()
		currentMag = magCapacity;
		muzzleFlash = transform.GetChild(0).GetComponent<ParticleSystem>();
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
			isReloadPressed = true;
		}

		if (context.canceled)
		{
			isReloadPressed = false;
		}
	}

	/**
	 * @Author Markus Larsson and Khaled Alrass
	 */
	private void UserInput()
	{
		if (isFiring || Input.GetKeyDown(KeyCode.Mouse1) && Time.time >= nextTimeToFire && !isReloading && currentMag > 0){
			nextTimeToFire = Time.time + 1.0f / fireRate;
			Fire();
		}
		else if(isReloadPressed || Input.GetKeyDown(KeyCode.R) && !isReloading){
			if(rm.GetTotalAmmo() != 0)
			{
				StartCoroutine(Reload());
			}
		}
	}

	/**
	 * Shoots from the referenced camera 10 units forward.
	 * 
	 * @Author Markus Larsson and Simon Hessling Oscarson
	 */
	private void Fire(){
		currentMag--;
		muzzleFlash.Play();

		RaycastHit hit;
		if(Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range)){
			Zombie target = hit.transform.GetComponent<Zombie>();
			Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.red, 2);
			if(target != null){
				target.TakeDamage(damage);
			}
		}
	}

	/**
	 * Reloads the current magazine.
	 *
	 * @Author Markus Larsson and Simon Hessling Oscarson
	 */
	private IEnumerator Reload(){
		isReloading = true;
		Debug.Log("Reloading...");
		yield return new WaitForSeconds(reloadTime);
		int tempSubSize = magCapacity - currentMag;
		if(currentMag + rm.GetTotalAmmo() >= magCapacity) //gör så det inte går att få mer än magCapacity i magget
		{
			currentMag = magCapacity;
		}
		else
		{
			currentMag += rm.GetTotalAmmo();
		}
		
		rm.SubTotalAmmo(tempSubSize);
		if (rm.GetTotalAmmo() < 0)
        {
			rm.SetTotalAmmo(0);
        }
		Debug.Log("Reloaded!");
		isReloading = false;
	}

	public int GetAmmo()
	{
		return totalAmmo;
	}
	public void SetAmmo(int newAmmo)
	{
		totalAmmo += newAmmo;
	}
	public void ResetAmmo()
	{
		totalAmmo = 100;
	}
	public void SetDamage(int newDamage)
	{
		damage = newDamage;
	}
	public void SetMagCapacity(int newMagCapacity)
	{
		magCapacity = newMagCapacity;
	}

	public int GetCurrentMag()
	{
		return currentMag;
	}
}