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
	/**
	 * @Author Markus Larsson
	 */
    public int Get(MyItem.Type type){
	    switch(type){
		    case MyItem.Type.Batteries:
			    return batteries;
		    case MyItem.Type.Scrap:
			    return scrap;
		    case MyItem.Type.Ammo:
			    return ammo;
	    }
		Debug.Log(gameObject.tag);
	    return 46;
    }

    /**
	 * @Author Markus Larsson
	 */
    public void SetTotal(MyItem.Type type, int amount)
    {
	    switch(type){
		    case MyItem.Type.Batteries:
			    batteries = amount;
			    break;
		    case MyItem.Type.Scrap:
			    scrap = amount;
			    break;
		    case MyItem.Type.Ammo:
			    ammo = amount;
			    break;
	    }
    }

    /**
	 * @Author Markus Larsson
	 */
    public void Offset(MyItem.Type type, int amount)
    {
	    switch(type){
		    case MyItem.Type.Batteries:
			    batteries += amount;
			    break;
		    case MyItem.Type.Scrap:
			    scrap += amount;
			    break;
		    case MyItem.Type.Ammo:
			    ammo += amount;
			    break;
	    }
    }

	/**
	 * @Author Martin Wallmark
	 */
	public void DecreaseItem(MyItem.Type type, int amount)
	{
		switch (type)
		{
			case MyItem.Type.Batteries:
				batteries -= amount;
				break;
			case MyItem.Type.Scrap:
				scrap -= amount;
				break;
			case MyItem.Type.Ammo:
				ammo -= amount;
				break;
		}

	}
	public int GetAmmo()
    {
		return ammo;
    }
	
}
