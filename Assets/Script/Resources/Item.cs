using UnityEngine;

public class Item : MonoBehaviour{

	public string playah;
	[SerializeField] private int amount;
	[SerializeField] private ResourceManager.ItemType type;
	private AmmoPool ammoPool;
	private APU_SimonPrototype apu;
	private BPU_SimonPrototype bpu;
	private SPU_SimonPrototype spu;
	public SubsScript ss;
	private ScrapPool scrapPool;
	private BatteryPool batteryPool;

	private bool isPickedUp;

    private void Start()
    {
		ammoPool = GameObject.Find("AmmoPool").GetComponent<AmmoPool>();
		scrapPool = GameObject.Find("ScrapPool").GetComponent<ScrapPool>();
		batteryPool = GameObject.Find("BatteryPool").GetComponent<BatteryPool>();
		apu = gameObject.GetComponent<APU_SimonPrototype>();
		bpu = gameObject.GetComponent<BPU_SimonPrototype>();
		spu = gameObject.GetComponent<SPU_SimonPrototype>();
    }

    private void Update()
    {
        if (isPickedUp && playah !=null)
        {
			//Debug.Log(playah + "wow");
			Die();
			//Debug.Log(playah + "owo");
		}
    }

    public void PickUp(){
		
		//Die();
		isPickedUp = true;
		
	}

	private void Die(){

        switch (type)
        {
			case ResourceManager.ItemType.Ammo:
				ammoPool.ReturnToPool(apu);
                //ss.SetFirstScrapPickUp(true);
                break;
			case ResourceManager.ItemType.Scrap:
				scrapPool.ReturnToPool(spu);
				ss.SetFirstScrapPickUp(true);
				break;
			case ResourceManager.ItemType.Battery:
                Debug.Log("HADA");
				batteryPool.ReturnToPool(bpu);
                ss.SetFirstBatteryPickUp(true);
                break;
				
        }
		//Debug.Log("Playyhada");
		PickUpEvent pickUpEvent = new PickUpEvent();
		pickUpEvent.Description = "Item: " + type + " x " + amount + " has been picked up.";
		pickUpEvent.SetItemType(type);
		pickUpEvent.SetAmount(amount);
		pickUpEvent.SetRM(GameObject.FindGameObjectWithTag(playah).GetComponentInChildren<ResourceManager>());
		pickUpEvent.FireEvent();
		playah = null;
		
	}
}
