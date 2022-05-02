using UnityEngine;

public class ResourceManager : MonoBehaviour
{
	/*
	 * Test klass vill kunna f� UI att fungera korrekt.
	 * 
	 * @Author Simon Hessling and Markus Larsson
	 */

	public enum ItemType{
		Batteries,
		Scrap,
		Ammo,
	}

	private int ammo;
    private int batteries;
    private int scrap;

    /**
	 * @Author Markus Larsson
	 */
    public int Get(ItemType type){
	    switch(type){
		    case ItemType.Batteries:
			    return batteries;
			    break;
		    case ItemType.Scrap:
			    return scrap;
			    break;
		    case ItemType.Ammo:
			    return ammo;
			    break;
	    }
	    return 0;
    }

    /**
	 * @Author Markus Larsson
	 */
    public void SetTotal(ItemType type, int amount)
    {
	    switch(type){
		    case ItemType.Batteries:
			    batteries = amount;
			    break;
		    case ItemType.Scrap:
			    scrap = amount;
			    break;
		    case ItemType.Ammo:
			    ammo = amount;
			    break;
	    }
    }

    /**
	 * @Author Markus Larsson
	 */
    public void Add(ItemType type, int amount)
    {
	    switch(type){
		    case ItemType.Batteries:
			    batteries += amount;
			    break;
		    case ItemType.Scrap:
			    scrap += amount;
			    break;
		    case ItemType.Ammo:
			    ammo += amount;
			    break;
	    }
    }

    /**
	 * @Author Markus Larsson
	 */
    public void Subtract(ItemType type, int amount)
    {
	    switch(type){
		    case ItemType.Batteries:
			    batteries -= amount;
			    break;
		    case ItemType.Scrap:
			    scrap -= amount;
			    break;
		    case ItemType.Ammo:
			    ammo -= amount;
			    break;
	    }
    }
}
