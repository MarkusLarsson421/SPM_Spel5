using UnityEngine;

public class Item : MonoBehaviour{
	[SerializeField] private int amount;
	[SerializeField] private ResourceManager.ItemType type;
	private AmmoPool ammoPool;
	private APU_SimonPrototype apu;
	private BPU_SimonPrototype bpu;
	private SPU_SimonPrototype spu;

	private ScrapPool scrapPool;
	private BatteryPool batteryPool;
    private void Start()
    {
		ammoPool = GameObject.Find("AmmoPool").GetComponent<AmmoPool>();
		scrapPool = GameObject.Find("ScrapPool").GetComponent<ScrapPool>();
		batteryPool = GameObject.Find("BatteryPool").GetComponent<BatteryPool>();
		apu = gameObject.GetComponent<APU_SimonPrototype>();
		bpu = gameObject.GetComponent<BPU_SimonPrototype>();
		spu = gameObject.GetComponent<SPU_SimonPrototype>();
    }

    public void PickUp(){
		Die();
	}

	private void Die(){

        switch (type)
        {
			case ResourceManager.ItemType.Ammo:
				ammoPool.ReturnToPool(apu);
				break;
			case ResourceManager.ItemType.Scrap:
				scrapPool.ReturnToPool(spu);
				break;
			case ResourceManager.ItemType.Battery:
				batteryPool.ReturnToPool(bpu);
				break;
				
        }
		PickUpEvent pickUpEvent = new PickUpEvent();
		pickUpEvent.Description = "Item: " + type + " x " + amount + " has been picked up.";
		pickUpEvent.SetItemType(type);
		pickUpEvent.SetAmount(amount);
		pickUpEvent.FireEvent();
		
	}
}
