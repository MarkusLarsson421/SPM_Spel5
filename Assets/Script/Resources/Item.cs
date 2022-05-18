using UnityEngine;

public class Item : MonoBehaviour{

	public string playah;
	[SerializeField] private int amount;
	[SerializeField] private ResourceManager.ItemType type;
	private AmmoPool ammoPool;
    private PickupPool pickupPool;
	private APU_SimonPrototype apu;
	private BPU_SimonPrototype bpu;
	private SPU_SimonPrototype spu;
	public SubsScript ss;
	private ScrapPool scrapPool;
	private BatteryPool batteryPool;
    private static bool doOnce1 = true;
    private static bool doOnce2 = true;
    [SerializeField] private BatteryObjectPooled batteryObj;
    [SerializeField] private PickupObjectPooled pickupObj;

    private GameObject ammo, scrap, battery;

    private bool isPickedUp;

    private void Start()
    {
        pickupPool = GameObject.Find("PickupPool").GetComponent<PickupPool>();
        pickupObj = GameObject.Find("PickupSpawner").GetComponent<PickupObjectPooled>();
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
		isPickedUp = true;
	}

	private void Die(){
        pickupPool.ReturnToPool(this.gameObject);
        pickupObj.SetAbleToSpawn(true);
        PickUpEvent pickUpEvent = new PickUpEvent();
		pickUpEvent.Description = "Item: " + type + " x " + amount + " has been picked up.";
		pickUpEvent.SetItemType(type);
		pickUpEvent.SetAmount(amount);
		pickUpEvent.SetRM(GameObject.FindGameObjectWithTag(playah).GetComponentInChildren<ResourceManager>());
		pickUpEvent.FireEvent();
		playah = null;
		
	}
}
