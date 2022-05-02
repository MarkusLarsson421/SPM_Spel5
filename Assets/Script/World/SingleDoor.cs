using UnityEngine;

public class SingleDoor : MonoBehaviour
{
	[SerializeField] private bool blocked = true;
	[SerializeField] private bool playerCanOpen;
	
	private bool open;
	private Animator ani;

	private void Awake()
	{
		ani = gameObject.transform.GetChild(0).GetComponent<Animator>();
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
	public void Close()
	{
		if(blocked){return;}
		open = false;
		ani.SetBool("isOpen", false);
		Debug.Log("Closing!");
	}
	
	/**
	 * @Author Markus Larsson
	 *
	 * Open the door.
	 */
	public void Open()
	{
		if(blocked){return;}
		open = true;
		ani.SetBool("isOpen", true);
		Debug.Log("Opening!");
	}
}