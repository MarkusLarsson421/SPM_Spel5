using UnityEngine;

public class PickupListener : MonoBehaviour{
	[SerializeField] private ResourceManager resourceManager;
	
	//Register listener
	private void Start(){
		PickUpEvent.RegisterListener(OnItemPickedUp);
	}

	//What do to when called
	private void OnItemPickedUp(PickUpEvent ePickUpEvent){
		if(ePickUpEvent.GetAmount() + resourceManager.Get(ePickUpEvent.GetItemType()) <= resourceManager.GetMaxAmount(ePickUpEvent.GetItemType()))
		{
			resourceManager.Offset(ePickUpEvent.GetItemType(), ePickUpEvent.GetAmount());
		}
		
	}
	
	//Unregister listener
	private void OnDestroy(){
		PickUpEvent.UnregisterListener(OnItemPickedUp);
	}
}
