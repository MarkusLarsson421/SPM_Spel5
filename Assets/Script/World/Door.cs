using UnityEngine;

/**
 * @Author Markus Larsson
 */
public class Door : MonoBehaviour{
	[SerializeField] private bool isOpen;
	[SerializeField] private bool playerCanOpen;
	private Animator ani;

	private void Start(){
		ani = transform.GetChild(0).GetComponent<Animator>();

		SetState(isOpen);
	}
	
	private void OnTriggerEnter(Collider other){
		if(other.CompareTag("Player") && playerCanOpen){
			Open();
		}
	}

	/**
	 * Toggle the open-close state of the door.
	 */
	public void ToggleState(){
		SetState(!isOpen);
	}

	/**
	 * Set the state of the door.
	 *
	 * @param State the desired state of the door.
	 */
	public void SetState(bool desiredOpen){
		if(desiredOpen){
			Open();
		} else{
			Close();
		}
	}

	/**
	 * Closes the door.
	 */
	public void Close(){
		isOpen = false;
		ani.SetBool("isOpen", false);
	}

	/**
	 * Opens the door.
	 */
	public void Open(){
		isOpen = true;
		ani.SetBool("isOpen", true);
	}

	public void SetCanOpen(bool desiredState){
		playerCanOpen = desiredState;
	}

	/**
	 * Updates the light if the inspectorState value has been updated.
	 */
	private void OnValidate(){
		if(ani == null){
			ani = transform.GetChild(0).GetComponent<Animator>();
		}
		
		SetState(isOpen);
		SetCanOpen(playerCanOpen);
	}
}