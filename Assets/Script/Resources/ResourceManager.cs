using UnityEngine;

public class ResourceManager : MonoBehaviour
{
	/*
	 * Test klass vill kunna f� UI att fungera korrekt.
	 * 
	 * @Author Simon Hessling and Markus Larsson
	 */
	
	[SerializeField] private int ammo  = 20;
	[SerializeField] private int batteries = 2;
	[SerializeField] private int scrap;

	private int aP1;
	private int aP2;

	public enum ItemType{
		Scrap,
		Battery,
		Ammo,
	}

	/**
	 * @Author Markus Larsson
	 */
    public int Get(ItemType type){
	    switch(type){
		    case ItemType.Battery:
			    return batteries;
		    case ItemType.Scrap:
			    return scrap;
		    case ItemType.Ammo:
			    return ammo;
	    }
		Debug.Log(gameObject.tag);
	    return 46;
    }

    /**
	 * @Author Markus Larsson
	 */
    public void SetTotal(ItemType type, int amount)
    {
	    switch(type){
		    case ItemType.Battery:
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
    public void Offset(ItemType type, int amount)
    {
	    switch(type){
		    case ItemType.Battery:
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

	public int GetAmmo()
    {
		return ammo;
    }
}
