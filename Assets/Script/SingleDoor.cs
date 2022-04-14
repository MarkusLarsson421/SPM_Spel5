using System;
using UnityEngine;

public class SingleDoor : MonoBehaviour
{
	[SerializeField] private bool blocked = true;
	private bool open;
	private Animator animation;

	private void Awake()
	{
		animation = gameObject.GetComponent<Animator>();
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
		animation.Play("Close", 0, 0.0f);
		Debug.Log("Closing!");
	}
	
	/**
	 * @Author Markus Larsson
	 *
	 * Open the door.
	 */
	private void Open(){
		open = true;
		animation.Play("Open", 0, 0.0f);
		Debug.Log("Opening!");

	}
}