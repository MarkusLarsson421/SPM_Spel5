using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableDoor : MonoBehaviour
{
	public GameObject door1;
	public GameObject door2;
	public void DisableDoors()
    {
		Destroy(door1);
		Destroy(door2);
    }
}
