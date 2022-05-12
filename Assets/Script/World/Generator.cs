using UnityEngine;

public class Generator : MonoBehaviour{
	private const int maxFuel = 100;
	
	//Whether or not the generator is on.
	[SerializeField] private bool isOn;
	
	//Fuel
	[Header("Fuel settings")]
	[SerializeField][Range(1, maxFuel)] private float fuel;
	[SerializeField] private float fuelDrainMultiplier = 1.0f;

	//Colours to display the current fuel stage to the player.
	[SerializeField] private Color[] fuelIndicatorColours;

	[Header("Generator interactions")]
	[SerializeField] private GameObject[] lights;
	[SerializeField] private Door[] doors;
	[SerializeField] private GameObject[] emergencyLights;

	private Light fuelIndicator;

	private void Start(){
		fuelIndicator = transform.GetChild(0).gameObject.GetComponent<Light>();
		isOn = true;
		fuel = maxFuel;
	}

	private void Update(){
		DrainFuel();
		FuelIndicator();
	}
	
	/**
	 * @Author Martin Wallmark and Markus Larsson
	 */
	public void RefillFuel(float amount){
		if(fuel + amount > maxFuel){
			amount = maxFuel - fuel;
		}
		fuel += amount;
		ToggleGenerator();
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
		SetDoorState(true);
	}
	
	public void TurnOff(){
		isOn = false;
		SetLightState(false);
		SetDoorState(false);
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

	private void FuelIndicator(){
		float fuelRatio = fuel / maxFuel;
		if(fuelRatio < 0.95f){
			fuelIndicator.color = fuelIndicatorColours[0];
		}else if(fuelRatio < 0.5f){
			fuelIndicator.color = fuelIndicatorColours[1];
		} else if(fuelRatio < 0.25f){
			fuelIndicator.color = fuelIndicatorColours[2];
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
		foreach(GameObject go in lights){
			go.GetComponent<Lamp>().SetState(desiredState);
		}
	}
	
	/*
	 * @Author Markus Larsson
	 */
	/*private void SetEmergencyLightState(bool desiredState){
		foreach(GameObject go in lights){
			go.GetComponent<Lamp>().SetState(desiredState);
		}
	}*/

	/*
	 * Tells the door to either open or close depending on the parameter.
	 *
	 * @Param desiredState What state the door is desired to be in.
	 * @Author Martin Wallmark and Markus Larsson
	 */
	private void SetDoorState(bool desiredState){
		foreach(Door door in doors){
			door.SetState(desiredState);
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

	private void OnValidate(){
		if(fuel <= 0){
			isOn = false;
		}
		SetState(isOn);
	}
}