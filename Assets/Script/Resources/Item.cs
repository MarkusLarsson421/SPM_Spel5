using UnityEngine;

public class Item : MonoBehaviour{

	public string playah;
	[SerializeField] private int amount;
	[SerializeField] private ResourceManager.ItemType type;
    private PickupPool pickupPool;
	private APU_SimonPrototype apu;
	private BPU_SimonPrototype bpu;
	private SPU_SimonPrototype spu;
	public SubsScript ss;
    private static bool doOnce1 = true;
    private static bool doOnce2 = true;
    private PickupObjectPooled pickupSpawner;

    private GameObject ammo, scrap, battery;

    private bool isPickedUp;

    private void Start()
    {
        pickupPool = GameObject.Find("PickupPool").GetComponent<PickupPool>();
        pickupSpawner = GameObject.Find("PickupSpawner").GetComponent<PickupObjectPooled>();
        Debug.Log(pickupSpawner);
        apu = gameObject.GetComponent<APU_SimonPrototype>();
		bpu = gameObject.GetComponent<BPU_SimonPrototype>();
		spu = gameObject.GetComponent<SPU_SimonPrototype>();   
    }

    private void Update()
    {
        if (isPickedUp && playah !=null)
        {
			DespawnItems();
		}
    }

    public void PickUp(){
		isPickedUp = true;
	}

	private void DespawnItems(){
		
        pickupPool.ReturnToPool(gameObject);
        PickUpEvent pickUpEvent = new PickUpEvent();
		pickUpEvent.Description = "Item: " + type + " x " + amount + " has been picked up.";
		pickUpEvent.SetItemType(type);
		pickUpEvent.SetAmount(amount);
		pickUpEvent.SetRM(GameObject.FindGameObjectWithTag(playah).GetComponentInChildren<ResourceManager>());
		pickUpEvent.FireEvent();
		if (ss != null && type.ToString() == "Scrap") { ss.ScrapsUsedForCarLine(); }
		playah = null;
		
	}
}
