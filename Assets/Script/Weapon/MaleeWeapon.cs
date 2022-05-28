using EventCallbacks;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class MaleeWeapon : MonoBehaviour
{
	//Shooting
	[SerializeField] private int damage = 100;
	[SerializeField] private float range = 1f;
	[SerializeField] private float fireRate = 1.0f;
	private float nextTimeToFire;
    private SoundManager sM;

    //Ammo
    private bool isReloading;

	private bool isFiring;

	private bool canFire;

	private DynamicMovementController player;

    private void Start()
    {
        player = GetComponentInParent<DynamicMovementController>();
	}
    private void Awake()
    {
        sM = GameObject.Find("SM").GetComponent<SoundManager>();

    }

    [SerializeField] private Camera fpsCamera;

	/**
	 * @Author Martin Wallmark
	 */
	public void OnFire(InputAction.CallbackContext context)
	{
		if (context.performed && !isReloading && canFire)
		{
			Fire();
            sM.SoundPlaying("meleeAttack");
			OnAttackWithMaleeEvent unit = new OnAttackWithMaleeEvent();
			unit.player = player;
			unit.FireEvent();

		}
	}

	/**
	 * @Author Markus Larsson and Khaled Alrass
	 */
	private void UserInput()
	{
		if (isFiring || Input.GetKeyDown(KeyCode.Mouse1) && Time.time >= nextTimeToFire && !isReloading)
		{
			nextTimeToFire = Time.time + 1.0f / fireRate;
			Fire();
		}
		//timer = 0;
	}

	/**
	 * Shoots from the referenced camera 10 units forward.
	 * 
	 * @Author Markus Larsson 
	 * @Simon Hessling Oscarson
	 */
	private void Fire()
	{
		RaycastHit hit;
		if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
		{
			EnemyAI target = hit.collider.GetComponent<EnemyAI>(); //Khaled ändrat typen från Zombie till EnemyAI
			Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.red, 2);
			if (target != null)
			{
				target.TakeDamage(damage);
			}
		}
	}

	/**
	 * Reloads the current magazine.
	 *
	 * @Author Markus Larsson and Simon Hessling Oscarson
	 */

	public void SetDamage(int newDamage)
	{
		damage = newDamage;
	}

	public void SetCanFire(bool nCanFire)
    {
		canFire = nCanFire;
    }
}