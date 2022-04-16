using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUpHandler : MonoBehaviour
{

    //Skapat av SIMON HESSLING
    /*AddAmmo() l�gger till ammo. Tar sedan bort Ammo pickUpen genom att g�ra Destroy(gameObject).
    * AmmoPickUpHandler klassen skall d�rf�r ligga p� ammo objektet f�r att fungera korrekt.
    * Modifieras h�gst upp i klassen. 
    * Sammarbetar med klassen RM f�r att uppdatera m�ngden ammo man har
    */
    public RM rm;

    private int MINPICKUP = 5;
    private int MAXPICKUP = 15;
    private int currentAmmo = 0;
    private int maxAmmo = 100;
    private bool ammoLimit = true;
  



    public void PickUpAmmo()
    {
        AmmoLimitReached();
        AddAmmo();
    }
   
    private void AddAmmo() 
    {
        
        if (ammoLimit)
        {
            currentAmmo = Random.Range(MINPICKUP, MAXPICKUP);
            rm.AddTotalAmmo(currentAmmo);
            if (rm.GetTotalAmmo() >= maxAmmo)
            {
                Debug.Log("current ammo = 100");
                rm.SetTotalAmmo(100);
            }
            Destroy(gameObject);
            Debug.Log("current ammo =" + currentAmmo);
        }
        else
        {
            Debug.Log("funkar");
        }
    }
    private void AmmoLimitReached() //kontrollerar ifall man har max antal ammo.
    { 
        if (rm.GetTotalAmmo() == maxAmmo)
        {
            Debug.Log("ammo limit reached");
            ammoLimit = false;

        }
        else
        {
            ammoLimit = true;
        }
        
    }

    
}
