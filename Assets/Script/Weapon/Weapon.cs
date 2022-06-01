using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    //Shooting
    [SerializeField] private int damage = 20;
    [SerializeField] private float range = 100.0f;
    [SerializeField] private GameObject zombieHitBloodParticle;
    [Tooltip("Rounds per second.")]
    [SerializeField] private float fireRate = 5.0f;
    private float nextTimeToFire;

    //Ammo
    [SerializeField] private float reloadTime = 2.0f;
    [SerializeField] private ResourceManager rm;
    private SoundManager sM;
    private int magCapacity = 8;
    private int currentMag;
    private bool isReloading;

    private bool isFiring;

    private bool canFire = true;

    [SerializeField] private ParticleSystem[] muzzleFlash;


    [SerializeField] private Camera fpsCamera;

    public Animator playerAnim;
    public Animator gunAnim;

    void Start()
    {
        currentMag = magCapacity;
    }
    private void Awake()
    {
        sM = GameObject.Find("SM").GetComponent<SoundManager>();

    }

    /**
	 * @Author Martin Wallmark
	 */
    public void OnFire(InputAction.CallbackContext context)
    {
        if (canFire && context.performed && Time.time >= nextTimeToFire && isReloading == false && currentMag > 0)
        {
            nextTimeToFire = Time.time + 1.0f / fireRate;
            Fire();
        }

    }

    /**
	 * @Author Martin Wallmark
	 */
    public void OnReload(InputAction.CallbackContext context)
    {
        if (context.performed && isReloading == false && rm.Get(ResourceManager.ItemType.Ammo) != 0)
        {
            
            StartCoroutine(Reload());
        }

        if (context.canceled)
        {
            isReloading = false;
        }
    }

    /**
	 * @Author Markus Larsson and Khaled Alrass
	 */
    private void UserInput()
    {
        if (isFiring || Input.GetKeyDown(KeyCode.Mouse1) && Time.time >= nextTimeToFire && !isReloading && currentMag > 0)
        {
            nextTimeToFire = Time.time + 1.0f / fireRate;
            Fire();
        }
        else if (Input.GetKeyDown(KeyCode.R) && !isReloading)
        {
            if (rm.Get(ResourceManager.ItemType.Ammo) != 0)
            {
                StartCoroutine(Reload());
            }
        }
    }

    /**
	 * Shoots from the referenced camera 10 units forward.
	 * 
	 * @Author Markus Larsson 
	 * @Simon Hessling Oscarson
	 */
    RaycastHit hit;
    private void Fire()
    {
        currentMag--;
        for(int i = 0; i < muzzleFlash.Length; i++)
        {
            muzzleFlash[i].Play();
        }
        sM.SoundPlaying("shootSound");
        //Shoot animation - nyman
        if (!isReloading)
        {
            gunAnim.SetTrigger("Fire");
        }


        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            EnemyAI target;
            int headshotDmg= 0;
            if (hit.collider.CompareTag("headshot"))
            {
                target = hit.collider.GetComponentInParent<EnemyAI>();
                headshotDmg = 30;

                Debug.Log("headshot");
            }
            else
            {
                target = hit.collider.GetComponent<EnemyAI>();//Khaled �ndrat typen fr�n Zombie till EnemyAI
            }
            
            

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.red, 2);
            if (target != null)
            {
               
                
                    target.TakeDamage(damage + headshotDmg);
                    


                ParticleOnHitEffect();
            }
        }

        if (currentMag <= 0 && rm.Get(ResourceManager.ItemType.Ammo) > 0 )
        {
            StartCoroutine(Reload());
        }

    }
    private void ParticleOnHitEffect()
    {

        Vector3 hitMe = new Vector3(hit.point.x, hit.point.y, hit.point.z);

        GameObject zombieBlood = Instantiate(zombieHitBloodParticle, hitMe, Quaternion.identity);
        zombieBlood.GetComponent<ParticleSystem>().Play();
    }
    /**
	 * Reloads the current magazine.
	 *
	 * @Author Markus Larsson and Simon Hessling Oscarson
	 */
    private IEnumerator Reload()
    {

        //load animation - nyman
        if (currentMag < magCapacity && !isReloading)
        {
            sM.SoundPlaying("reload");
            playerAnim.SetTrigger("Reload");
            gunAnim.SetTrigger("Reload");
        }


        isReloading = true;


        yield return new WaitForSeconds(reloadTime);
        int tempSubSize = magCapacity - currentMag;

        if (currentMag + rm.Get(ResourceManager.ItemType.Ammo) >= magCapacity) //g�r s� det inte g�r att f� mer �n magCapacity i magget
        {
            currentMag = magCapacity;
        }
        else
        {
            currentMag += rm.Get(ResourceManager.ItemType.Ammo);
        }

        rm.Offset(ResourceManager.ItemType.Ammo, -tempSubSize);
        if (rm.Get(ResourceManager.ItemType.Ammo) < 0)
        {
            rm.SetTotal(ResourceManager.ItemType.Ammo, 0);
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

    public void SetCanFire(bool nCanFire)
    {
        canFire = nCanFire;
    }

    public void ReloadOnce()
    {
        StartCoroutine(Reload());
    }
}