using UnityEngine;

public class Item : MonoBehaviour{
	[SerializeField] private int amount;
	[SerializeField] private ResourceManager.ItemType type;

	public void PickUp(){
		Die();
	}

	private void Die(){
		PickUpEvent pickUpEvent = new PickUpEvent();
		pickUpEvent.Description = "Item: " + type + " x " + amount + " has been picked up.";
		pickUpEvent.SetItemType(type);
		pickUpEvent.SetAmount(amount);
		pickUpEvent.FireEvent();
		Destroy(this);
	}
}
