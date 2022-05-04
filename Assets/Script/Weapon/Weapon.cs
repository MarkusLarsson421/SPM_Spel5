using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour {
	//Shooting
	[SerializeField] private int damage = 20;
	[SerializeField] private float range = 100.0f;
	[SerializeField] private float fireRate = 5.0f;
	private float nextTimeToFire;

	//Ammo
	[SerializeField] private int magCapacity = 8;
	[SerializeField] private float reloadTime = 2.0f;
	[SerializeField] private ResourceManager rm;
	private int currentMag;
	private bool isReloading;

	private bool isFiring;
	private bool isReloadPressed;
	private bool canFire = true;

	private float timer;

	private ParticleSystem muzzleFlash;
	
	[SerializeField] private Camera fpsCamera;

	void Start()
	{
		currentMag = magCapacity;
		muzzleFlash = transform.GetChild(0).GetComponent<ParticleSystem>();
	}

	void Update()
	{
		/*
		timer += Time.deltaTime;

		if (canFire)
		{	
			UserInput();
		}

		if (timer >= 0.4f)
		{
			canFire = true;
			

		}
		*/



		//UserInput();
	}

	/**
	 * @Author Martin Wallmark
	 */
	public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed && !isReloading && currentMag > 0 /*&& /*canFire*/)
        {
			Fire();
			isFiring = true;
			//canFire = false ;
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
			Reload();
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
			canFire = false;
			
		}
		else if(isReloadPressed || Input.GetKeyDown(KeyCode.R) && !isReloading){
			if(rm.Get(MyItem.Type.Ammo) != 0)
			{
				StartCoroutine(Reload());
			}
		}
		timer = 0;
	}

	/**
	 * Shoots from the referenced camera 10 units forward.
	 * 
	 * @Author Markus Larsson 
	 * @Simon Hessling Oscarson
	 */
	private void Fire(){
		currentMag--;
		muzzleFlash.Play();
		Debug.Log("FIRE!");

		RaycastHit hit;
		if(Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range)){
			EnemyAI target = hit.collider.GetComponent<EnemyAI>(); //Khaled ändrat typen från Zombie till EnemyAI
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
		if(currentMag + rm.Get(MyItem.Type.Ammo) >= magCapacity) //gör så det inte går att få mer än magCapacity i magget
		{
			currentMag = magCapacity;
		}
		else
		{
			currentMag += rm.Get(MyItem.Type.Ammo);
		}
		
		rm.Offset(MyItem.Type.Ammo, -tempSubSize);
		if (rm.Get(MyItem.Type.Ammo) < 0)
        {
			rm.SetTotal(MyItem.Type.Ammo, 0);
        }
		Debug.Log("Reloaded!");
		isReloading = false;
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