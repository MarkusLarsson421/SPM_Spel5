using UnityEngine;

public class ResourceManager : MonoBehaviour
{
	/*
	 * Test klass vill kunna f� UI att fungera korrekt.
	 * 
	 * @Author Simon Hessling and Markus Larsson
	 */
	
	private int ammo = 16;
	private int batteries = 2; 
	private int scrap;

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
	    return 0;
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
	
}
