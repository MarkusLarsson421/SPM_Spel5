using UnityEngine;

public class Generator : MonoBehaviour{
	[SerializeField] private float fuel;
	[SerializeField] private float maxFuel = 100.0f;
	[SerializeField] private float fuelDrainMultiplier = 1.0f;
	private bool isOn;

	private Color[] materials;

	//colors for the fuelLevelIndicator
	private Color fullGeneratorColor = new Color(0, 133, 0, 255);
	private Color halfEmptyGeneratorColor = new Color(188, 174, 0, 255);
	private Color emptyGeneratorColor = new Color(188, 0, 0, 255);

	[SerializeField] private Light[] lights;
	[SerializeField] private Door[] doors;

	private void Start(){
		isOn = true;
		fuel = maxFuel;
	}

	private void Update(){
		DrainFuel();

		FuelIndicator();
	}

	private void DrainFuel(){
		if(isOn){
			fuel -= fuelDrainMultiplier * Time.deltaTime;
		}
	}

	private void FuelIndicator(){
		
	}

	/*
	 * @Author Martin Wallmark
	 */
	public void Refill(){
		fuel = maxFuel;
		ToggleLights();
		OpenDoor();
	}

	/*
	 * @Author Martin Wallmark
	 */
	private void ToggleGenerator(){
		isOn = !isOn;
	}

	/*
	 * @Author Martin Wallmark
	 */
	private void ToggleLights(){
		foreach(var l in lights){
			l.intensity = !isOn ? 0 : 2;
		}
	}

	/*
	 * @Author Martin Wallmark
	 */
	private void OpenDoor(){
		foreach(Door door in doors){
			door.ToggleState();
		}
	}

	/*
	 * When generator is half full the light intensity will lerp from 2 to 1 before shutting off
	 * 
	 * @Author Martin Wallmark
	 */
	private void LerpingLights(){
		foreach(Light light in lights){
			float lerpTimer = Time.deltaTime / 3f;
			light.intensity = Mathf.Lerp(light.intensity, 1f, lerpTimer);
		}
	}
}