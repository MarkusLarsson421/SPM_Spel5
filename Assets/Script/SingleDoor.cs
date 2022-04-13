using UnityEngine;

public class SingleDoor : MonoBehaviour
{
	[SerializeField] private bool blocked = true;
	private bool doorOpen;
	private Collider trigger;

	void Start()
	{
		//transform.GetComponent<Collision>() //Reference to trigger collision box.
	}

	void Update()
	{
		//TODO
		//Raycast, see if it hits the door.
		if(Input.GetKeyDown(KeyCode.E))
		{
			RaycastHit hit;
			/*if(Physics.Raycast())
			{
				ToggleState();
			}*/
			
		}
	}

	public void ToggleState()
	{
		SetState(!doorOpen);
	}
	
	private void SetState(bool desiredState){
		if(desiredState && !blocked){
			// Open door.
			gameObject.transform.GetChild(0).gameObject.SetActive(true);
			doorOpen = true;
		}else{
			// Close door.
			gameObject.transform.GetChild(0).gameObject.SetActive(false);
			doorOpen = false;
		}
	}
}