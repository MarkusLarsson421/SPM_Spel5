using System;
using UnityEngine;

public class SingleDoor : MonoBehaviour
{
	[SerializeField] private bool blocked = true;
	
	private bool open;
	private Animator ani;

	private void Awake()
	{
		ani = gameObject.GetComponent<Animator>();
	}

	/**
	 * @Author Markus Larsson
	 * 
	 * Toggle the open-close state of the door.
	 */
	public void ToggleOpen(){
		if(open){Close();}
		if(!open){Open();}
		Debug.Log("Toggled Open State!");
	}

	/**
	 * @Author Markus Larsson
	 *
	 * Block or unblock the door. Allows a player to interact with it.
	 */
	public void ToggleBlocked()
	{
		blocked = !blocked;
	}

	/**
	 * @Author Markus Larsson
	 *
	 * Close the door.
	 */
	private void Close(){
		open = false;
		ani.Play("Close", 0, 0.0f);
		Debug.Log("Closing!");
	}
	
	/**
	 * @Author Markus Larsson
	 *
	 * Open the door.
	 */
	private void Open(){
		open = true;
		ani.Play("Open", 0, 0.0f);
		Debug.Log("Opening!");

	}
}