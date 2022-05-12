using UnityEngine;

public class DoorController : MonoBehaviour
{
	[SerializeField] private bool isOpen;
	[SerializeField] private Door[] doors;

	private void Start(){
		foreach(Door door in doors){
			door.SetState(isOpen);
		}
	}

	public void Toggle(){
		SetDoorState(!isOpen);
	}
	
	/*
	 * Tells the doors to either open or close.
	 *
	 * @Param desiredState What state the door is desired to be in.
	 * @Author Martin Wallmark and Markus Larsson
	*/
	private void SetDoorState(bool desiredState){
		foreach(Door door in doors){
			door.SetState(desiredState);
		}
	}

	private void OnValidate(){
		Start();
	}
}
