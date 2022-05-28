using EventCallbacks;
using UnityEngine;

public class Generator : MonoBehaviour{
	private const int maxFuel = 100;
	
	//Whether or not the generator is on.
	[SerializeField] private bool isOn;
	[SerializeField] private Interactable interactable;
    [SerializeField] private SoundManager sM;


    //Fuel
    [Header("Fuel settings")]
	[SerializeField][Range(1, maxFuel)] private float fuel;
	[SerializeField] private float fuelDrainMultiplier = 1.0f;

	//Colours to display the current fuel stage to the player.
	[SerializeField] private Color[] fuelIndicatorColours;

	[Header("Generator interactions")]
	[SerializeField] private GameObject[] doors;
	[Tooltip("Normal powered state of the generator and its components.")]
	[SerializeField] private GameObject[] highPowerLights;
	[Tooltip("Powered objects when the power is turned off. Such as emergency lights.")]
	[SerializeField] private GameObject[] lowPowerLights;

	private Light fuelIndicator;
	[SerializeField] private GameObject interactingPlayer;
	public string interactingTag;
	private bool isToggled;
	private bool hasRegistered;
	[SerializeField] private ResourceManager rm;

	private void Start(){
		fuelIndicator = transform.GetChild(0).gameObject.GetComponent<Light>();
		SetState(isOn);
		FuelIndicator();
	}

	private void Update(){

        if (isToggled && !hasRegistered)
        {
			interactingPlayer = interactable.interactingGameObject.transform.parent.gameObject;
			rm = interactable.interactingGameObject.GetComponentInChildren<ResourceManager>();
			if(rm.Get(ResourceManager.ItemType.Scrap) >= 1 && !isOn)
            {
				RefillFuel(100);
				OpenDoors();
				rm.Offset(ResourceManager.ItemType.Scrap, -1);
			}
			
			hasRegistered = true;
		}
		DrainFuel();
		FuelIndicator();

		
	}

	public void SetInteractingPlayer()
    {
		isToggled = true;
		hasRegistered = false;
    }
	
	/**
	 * @Author Martin Wallmark and Markus Larsson
	 */
	public void RefillFuel(float amount){
		if(fuel + amount > maxFuel){
			amount = maxFuel - fuel;
		}
		fuel += amount;
		TurnOn();
	}
	
	public void SetState(bool desiredState){
		if(desiredState){
			TurnOn();
		} else{
			TurnOff();
		}
	}

	public void TurnOn(){
		if(fuel <= 0){return;}
		isOn = true;
		SetLightState(true);
		fuelIndicator.enabled = true;
		call();
    }
	public void call()
    {
		GameObject[] zombies;
		zombies = GameObject.FindGameObjectsWithTag("Zombie");
		foreach (GameObject zombie in zombies)
		{
			zombie.GetComponent<EnemyAI>().setChasingRange(1000);

		}
		////Khaled 
		//GneratorIsOnEvent generatorIsOn = new GneratorIsOnEvent();
		//EventSystem.Current.FireEvent(generatorIsOn);
		////Khaled
		//Debug.Log("i work Generator");
	}

	public void TurnOff(){
		isOn = false;
		SetLightState(false);
		fuelIndicator.enabled = false;
	}

	public void OpenDoors(){
		SetDoorState(true);
	}

	public void SetFuel(float fuel){
		this.fuel = fuel;
	}

	public float GetFuel()
	{
		return fuel;
	}

	public bool GetState()
	{
		return isOn;
	}

	/**
	 * Drains fuel each frame.
	 *
	 * @Author Markus Larsson and Martin Wallmark
	 */
	private void DrainFuel(){
		if(isOn){
			fuel -= fuelDrainMultiplier * Time.deltaTime;
		}
		if(fuel <= 0){
			fuel = 0;
			TurnOff();
		}
	}

	/**
	 * @Author Markus Larsson
	 */
	private void FuelIndicator(){
		float fuelRatio = fuel / maxFuel;
		if(fuelRatio < .25f){
			fuelIndicator.color = fuelIndicatorColours[2];
		}else if(fuelRatio < .5f){
			fuelIndicator.color = fuelIndicatorColours[1];
		} else if(fuelRatio < 1.0f){
			fuelIndicator.color = fuelIndicatorColours[0];
		}
	}

	/*
	 * Toggles the state of the generator.
	 */
	private void ToggleGenerator(){
		SetState(!isOn);
	}

	/*
	 * @Author Martin Wallmark and Markus Larsson
	 */
	private void SetLightState(bool desiredState){
		foreach(GameObject go in highPowerLights){
			go.GetComponent<Lamp>().SetState(desiredState);
		}

		foreach(GameObject go in lowPowerLights){
			go.GetComponent<Lamp>().SetState(!desiredState);
		}
	}
	
	/*
	 * Tells the doors to either open or close.
	 *
	 * @Param desiredState What state the door is desired to be in.
	 * @Author Martin Wallmark and Markus Larsson
	 */
	private void SetDoorState(bool desiredState){
		foreach(GameObject go in doors){
			go.GetComponent<Door>().SetState(desiredState);
		}
	}

	/*
	 * When generator is half full the light intensity will lerp from 2 to 1 before shutting off
	 * 
	 * @Author Martin Wallmark
	 */
	private void LerpingLights(){
		/*foreach(Light light in lights){
			float lerpTimer = Time.deltaTime / 3f;
			light.intensity = Mathf.Lerp(light.intensity, 1f, lerpTimer);
		}*/
	}

	private void OnValidate()
	{
		Start();
	}
}