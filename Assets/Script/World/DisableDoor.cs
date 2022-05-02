using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableDoor_SimonPrototype : MonoBehaviour
{
	public void DisableDoors()
    {
	    for(int i = 0; i < transform.childCount; i++)
	    {
		    Destroy(transform.GetChild(i));
	    }
    }
}
