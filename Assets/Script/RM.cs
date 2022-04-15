using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RM : MonoBehaviour
{

    /*SIMON
     * Test klass vill kunna få UI att fungera korrekt.
     * 
     * 
     * 
     */


    private int totalAmmo;
    private int currentBatteries;
    private int maxBatteries = 3;
    private int currentScraps;
    private int maxScraps = 10;
    // Start is called before the first frame update
    
    public void AddTotalAmmo(int ammo)
    {
        totalAmmo += ammo;
    }
    public void SetTotalAmmo(int ammo)
    {
        totalAmmo = ammo;
    }
    public int GetTotalAmmo()
    {
        return totalAmmo;
    }
    public void PickUpBatteries()
    {
        currentBatteries++;
    }
    public void PickUpScraps()
    {
        currentScraps++;
    }
}
