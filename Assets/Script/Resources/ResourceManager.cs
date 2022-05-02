using System;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
	/*
	 * Test klass vill kunna f� UI att fungera korrekt.
	 * 
	 * @Author Simon Hessling and Markus Larsson
	 */
	
	private int ammo;
	private int batteries;
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
}
