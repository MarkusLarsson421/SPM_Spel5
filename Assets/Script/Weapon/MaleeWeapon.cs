using EventCallbacks;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class MaleeWeapon : MonoBehaviour
{
	//Shooting
	[SerializeField] private int damage = 1000;
	[SerializeField] private float range = 1f;
	[SerializeField] private float fireRate = 1.0f;
	private float nextTimeToFire;
    private SoundManager sM;

    //Ammo
    private bool isReloading;

	private bool isFiring;

	private bool canFire = true;

	private DynamicMovementController player;

	[SerializeField] private Animator playerAnimator;
	[SerializeField] private Animator handAnimator;


	private void Start()
    {
        player = GetComponentInParent<DynamicMovementController>();
	}
    private void Awake()
    {
        sM = GameObject.Find("SM").GetComponent<SoundManager>();

    }
	float timer=0;
    private void Update()
    {
		if (!canFire&& timer<1)
		{
			timer += Time.deltaTime;
		}
        else
        {
			timer = 0;
			canFire = true;
		}
    }

    [SerializeField] private Camera fpsCamera;

	/**
	 * @Author Martin Wallmark
	 */
	public void OnFire(InputAction.CallbackContext context)
	{
		if (context.performed && canFire && gameObject.activeSelf)
		{
			canFire = false;
			StartCoroutine(Fire());
			sM.SoundPlaying("meleeAttack");
			playerAnimator.SetTrigger("Attack");
			handAnimator.SetTrigger("Fire");
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
	private IEnumerator Fire()
	{
		yield return new WaitForSeconds(0.4f);
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