using UnityEngine;

public class PickupListener : MonoBehaviour{
	[SerializeField] private ResourceManager resourceManager;
	
	//Register listener
	private void Start(){
		PickUpEvent.RegisterListener(OnItemPickedUp);
	}

	//What do to when called
	private void OnItemPickedUp(PickUpEvent ePickUpEvent){
        Debug.Log("DOING IT");
		if(ePickUpEvent.GetAmount() + ePickUpEvent.GetRm().Get(ePickUpEvent.GetItemType()) <= resourceManager.GetMaxAmount(ePickUpEvent.GetItemType()))
		{
            Debug.Log("SKRRR");
            ePickUpEvent.GetRm().Offset(ePickUpEvent.GetItemType(), ePickUpEvent.GetAmount());
		}
		
	}
	
	//Unregister listener
	private void OnDestroy(){
        Debug.Log("whyyyyy");
        PickUpEvent.UnregisterListener(OnItemPickedUp);
	}
}
