using UnityEngine;
/**
 * @authors Markus Larsson and Martin Wallmark
 * 
 */
public class PickupListener : MonoBehaviour{
	[SerializeField] private ResourceManager resourceManager;
	
	//Register listener
	private void Start(){
		PickUpEvent.RegisterListener(OnItemPickedUp);
	}

	//What do to when called
	/*
	 * @Author Martin Wallmark
	 * Adds the item to the resourceManager of the player who interacted with it if there is enough room for it
	 */

	private void OnItemPickedUp(PickUpEvent ePickUpEvent){
		if(ePickUpEvent.GetAmount() + ePickUpEvent.GetRm().Get(ePickUpEvent.GetItemType()) <= resourceManager.GetMaxAmount(ePickUpEvent.GetItemType()))
		{
            ePickUpEvent.GetRm().Offset(ePickUpEvent.GetItemType(), ePickUpEvent.GetAmount());
		}
		
	}
	
	//Unregister listener
	private void OnDestroy(){
        Debug.Log("whyyyyy");
        PickUpEvent.UnregisterListener(OnItemPickedUp);
	}
}
