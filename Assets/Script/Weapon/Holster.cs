using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Holster : MonoBehaviour
{
    [SerializeField] private UIHandler handler;
    [SerializeField] private Weapon pistol;
    [SerializeField] private MaleeWeapon melee;

    private int selectedWeapon;
    private float switchTimer;
    private bool isSwitched;
    private bool canSwitch;
    private bool isSwitching;

    private bool isSwitchingUp;
    private bool isSwitchingDown;

    [SerializeField] private Animator handAnimator;
    [SerializeField] private Animator playerAnimator;

    //List include every weaponassociated gameobject sorted by tag IE mesh, rigg, particleffects etc..
    [SerializeField] private GameObject[] weaponRelatedGameObjects;

    private void Start()
    {
        SelectWeapon();
    }

    public void OnSwitchUp(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isSwitchingUp = true;
            UserInput();
        }
    }


    private void Update()
    {
        if (canSwitch) { UserInput(); }

        switchTimer += Time.deltaTime;

        if (switchTimer >= 0.2f)
        {
            //canSwitch = true;
        }
    }

    /**
     * @Author Markus Larsson
     *
     * Takes input from the user.
     */
    private void UserInput()
    {
        //Scroll through weapons.
        Debug.Log("ayyo");
        if (isSwitched || Input.GetAxis("Mouse ScrollWheel") > 0.0f || isSwitchingUp)
        {
            if (selectedWeapon >= transform.childCount - 1)
            {
                selectedWeapon = 0;
            }
            else
            {
                selectedWeapon++;
            }

            SelectWeapon();
            isSwitchingUp = false;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0.0f || isSwitchingDown)
        {
            if (selectedWeapon <= 0)
            {
                selectedWeapon = transform.childCount - 1;
            }
            else
            {
                selectedWeapon--;
            }

            SelectWeapon();
            isSwitchingDown = false;
        }

        //Weapon select using numbers at the top.
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
            SelectWeapon();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedWeapon = 1;
            SelectWeapon();
        }

        switchTimer = 0;
        canSwitch = false;
    }

    /**
	 * @Author Markus Larsson
     * @Author Martin Wallmark
     * 
     * Loops through the list of weapons and disables all non-desired weapons and enables the desired ones.
	 */
    private void SelectWeapon()
    {
        if (isSwitching) { return; }

        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject currentWeapon = transform.GetChild(i).transform.gameObject;
            if (selectedWeapon == i)
            {
                currentWeapon.SetActive(true);
                if (currentWeapon.tag.Equals("Pistol"))
                {
                    pistol.SetCanFire(true);
                    handler.SwitchWeaponIcons("Pistol");
                    handAnimator.SetBool("Axe", false);
                    playerAnimator.SetBool("Axe", false);
                    StartCoroutine(ToggleWeaponObjects("Pistol"));

                }
                else if (currentWeapon.tag.Equals("Melee"))
                {
                    melee.SetCanFire(true);
                    handler.SwitchWeaponIcons("Melee");
                    handAnimator.SetBool("Axe", true);
                    playerAnimator.SetBool("Axe", true);
                    StartCoroutine(ToggleWeaponObjects("Melee"));

                }
                /*
                else if (currentWeapon.tag.Equals("AK47"))
                {
                    //currentWeapon.GetComponent<MaleeWeapon>().SetCanFire(true);
                    handler.SwitchWeaponIcons("AK47");
                }
                */

            }
            else
            {
                currentWeapon.SetActive(false);
                if (currentWeapon.tag.Equals("Pistol"))
                {
                    pistol.SetCanFire(false);
                }
                else if (currentWeapon.tag.Equals("Melee"))
                {
                    melee.SetCanFire(false);
                }
                /*
                else if (currentWeapon.tag.Equals("AK47"))
                {
                    //currentWeapon.GetComponent<MaleeWeapon>().SetCanFire(false);
                    
                }
                */
            }
        }
    }

    /**
    * @Author Martin Nyman
    * 
    * Loops through the list of weapons and associated parts like mesh, rigg and particles and toggles all related gameobjects by tag.
    */


    IEnumerator ToggleWeaponObjects(string tag)
    {
        isSwitching = true;

        yield return new WaitForSeconds(0.25f);

        for (int i = 0; i < weaponRelatedGameObjects.Length; i++)
        {
            if (weaponRelatedGameObjects[i].tag == tag)
            {
                weaponRelatedGameObjects[i].SetActive(true);
            }
            else
            {
                weaponRelatedGameObjects[i].SetActive(false);
            }
        }

        isSwitching = false;
    }


}