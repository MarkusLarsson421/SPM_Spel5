using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APU_SimonPrototype : MonoBehaviour
{

    //Skapat av SIMON HESSLING TA EJ BORT OM DET INTE FINNS ALTERNATIV SOM FUNKAR FÖR PICK UP TACK.
    /*AddAmmo() lägger till ammo. Tar sedan bort Ammo pickUpen genom att göra Destroy(gameObject).
    * AmmoPickUpHandler klassen skall därför ligga på ammo objektet för att fungera korrekt.
    * Modifieras högst upp i klassen. 
    * Sammarbetar med klassen RM för att uppdatera mängden ammo man har
    */
    public ResourceManager rm;
    private int MINPICKUP = 5;
    private int MAXPICKUP = 15;
    private int currentAmmo;
    private int maxAmmo = 100;
    private bool ammoLimit = true;

    private int counter;

    public int GetMaxAmmo()
    {
        return maxAmmo;
    }

    public void PickUpAmmo()
    {
        AmmoLimitReached();
        AddAmmo();
       


    }

    private void AddAmmo()
    {
        //counter++;
        if (ammoLimit)
        {
            currentAmmo = Random.Range(MINPICKUP, MAXPICKUP);
            rm.Offset(ResourceManager.ItemType.Ammo, currentAmmo);
            if (rm.Get(ResourceManager.ItemType.Ammo) > maxAmmo)
            {
                rm.SetTotal(ResourceManager.ItemType.Ammo, maxAmmo);
            }
            /*@Author Axel Sterner
             * Lägger tillbaka ammo-objektet i poolen när den plockas upp
             */
            // AmmoPool.Instance.ReturnToPool(this);
            //quickfix
            //if (counter > 1)
            //{
                Destroy(gameObject);
            //}

            Debug.Log("current ammo =" + currentAmmo);
            Debug.Log("total ammo =" + rm.Get(ResourceManager.ItemType.Ammo));
        }
        else
        {
            Debug.Log("funkar");
        }
    }
    private void AmmoLimitReached() //kontrollerar ifall man har max antal ammo.
    {
        if (rm.Get(ResourceManager.ItemType.Ammo) == maxAmmo)
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
