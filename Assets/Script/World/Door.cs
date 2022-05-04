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
			ToggleState();
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
		//If it already is the same state and the desired state, yeet.
		if(desiredState && playerCanOpen){return;}

		playerCanOpen = desiredState;
	}

	/**
	 * Updates the light if the inspectorState value has been updated.
	 */
	private void OnValidate(){
		ani = transform.GetChild(0).GetComponent<Animator>();
		
		Debug.Log("Noticed inspector update.");
		SetState(isOpen);
		SetCanOpen(playerCanOpen);
	}
}