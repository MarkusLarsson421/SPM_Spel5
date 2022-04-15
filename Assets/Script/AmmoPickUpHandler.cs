using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUpHandler : MonoBehaviour
{

    public RM rm;
    private int currentAmmo = 0;
    private int maxAmmo = 100;
    private bool ammoLimit = false;
  



    public void PickUpAmmo()
    {
        Debug.Log(rm.GetTotalAmmo() + " max ammo" + maxAmmo);
        
        AddAmmo();
    }

    private void AddAmmo()
    {
        AmmoLimitReached();
        if (ammoLimit)
        {
            Debug.Log("kommer hit??");
            currentAmmo = Random.Range(30, 70);
            rm.AddTotalAmmo(currentAmmo);
            if (rm.GetTotalAmmo() >= maxAmmo)
            {
                Debug.Log("current ammo = 100");
                currentAmmo = 100;
            }
            Destroy(gameObject);
            Debug.Log("current ammo =" + currentAmmo);
        }
    }
    private void AmmoLimitReached()
    { 
        if (rm.GetTotalAmmo() >= maxAmmo)
        {
            Debug.Log("ammo limit reached");
            ammoLimit = false;
            
        }
        ammoLimit = true;
        
    }

    
}
