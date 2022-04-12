using UnityEngine;
using UnityEngine.UIElements;

public class FlashLight : MonoBehaviour{
	[SerializeField] [Range(1, 100)] private double batteryCharge = 100.0;
	[SerializeField] private double batteryDrainMultiplier = 0.1;
	
	private bool flashLightState;

	public bool Toggle(){
		return SetState(!flashLightState);
	}
	
	public bool SetState(bool state){
		if(batteryCharge > 0){
			flashLightState = state;
		}
		return flashLightState;
	}

	public void Recharge(){
		Recharge(100);
	}
	public void Recharge(byte setCharge){
		batteryCharge = setCharge;
	}

	private void Update(){
		batteryCharge -= batteryDrainMultiplier * Time.deltaTime;
		
		//TODO Check if the user pressed the flashlight button.
	}
}