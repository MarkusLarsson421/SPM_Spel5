using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Holster : MonoBehaviour
{
	//Weapons
	private ArrayList weapons = new ArrayList();
	private int selectedWeapon;

    private bool isSwitched;

    private float switchTimer;

    private bool canSwitch;

    private void Start()
    {
		SelectWeapon();
    }

    void Update()
    {
        if (canSwitch)
        {
            UserInput();
        }

        switchTimer += Time.deltaTime;

        if(switchTimer >= 0.2f)
        {
            canSwitch = true;
        }
        
    }
    
    /**
     * @Author Markus Larsson
     *
     * Add weapon to player.
     */
    public void Add(GameObject weaponGO)
    {
        weapons.Add(weaponGO);
    }

    public void OnSwitch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isSwitched = true;
        }
        if(context.canceled)
        {
            isSwitched = false;
        }
    }

    /**
     * @Author Markus Larsson
     *
     * Remove weapon from player.
     */
    public void Remove(string name)
    {
        foreach(GameObject weapon in weapons)
        {
			if(weapon.name.Equals(name)){
				weapons.Remove(weapon);
			}
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
        if (isSwitched || Input.GetAxis("Mouse ScrollWheel") > 0.0f)
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
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0.0f)
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
     *
     * Loops through the list of weapons and disables all non-desired weapons and enables the desired ones.
	 */
    private void SelectWeapon()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (selectedWeapon == i)
            {
                transform.GetChild(i).transform.gameObject.SetActive(true);
            }
            else
            {
                transform.GetChild(i).transform.gameObject.SetActive(false);
            }
        }
    }
}
