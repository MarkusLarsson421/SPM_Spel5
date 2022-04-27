using UnityEngine;

public class RM : MonoBehaviour
{

    /*skapat av SIMON HESSLING
     * Test klass vill kunna få UI att fungera korrekt.
     * 
     * 
     * 
     */

	/*public enum ItemType{
		Batteries,
		Scrap,
		Ammo,
	}*/

	private int totalAmmo;
    private int currentBatteries;
    private int currentScraps;

	/**
	 * @Author Markus Larsson
	 */
	/*public int Get(ItemType type){
		switch(type){
			case ItemType.Batteries:
				return currentBatteries;
			case ItemType.Scrap:
				return currentScraps;
			case ItemType.Ammo:
				return totalAmmo;
		}
		return 0;
	}*/

	//AMMO -------------------------------------------------------
    public int GetTotalAmmo()
    {
        return totalAmmo;
    }
    public void SetTotalAmmo(int a)
    {
        totalAmmo = a;
    }
    public void AddTotalAmmo(int ammo)
    {
        totalAmmo += ammo;
    }
    public void SubTotalAmmo(int ammo)
    {
        totalAmmo -= ammo;
    }


    //AMMO -------------------------------------------------------

    //BATTERIES---------------------------------------------------
    public int GetCurrentBatteries()
    {
        return currentBatteries;
    }
    public void SetCurrentBatteries(int b)
    {
        currentBatteries = b;
    }
    public void PickUpBatteries()
    {
        currentBatteries++;
    }
    //BATTERIES---------------------------------------------------

    //SCRAPS------------------------------------------------------
    public int GetCurrentScraps()
    {
        return currentScraps;
    }
    public void SetCurrentScrap(int s)
    {
        currentScraps = s;
    }
    public void PickUpScraps()
    {
        currentScraps++;
    }
    //SCRAPS------------------------------------------------------
}
