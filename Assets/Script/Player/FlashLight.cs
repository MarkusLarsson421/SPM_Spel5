using UnityEngine;

public class FlashLight : MonoBehaviour{
	[SerializeField] [Range(1, 100)] private double batteryCharge = 100.0;
	[SerializeField] private double batteryDrainMultiplier = 0.1;
	
	private bool flashLightState;

	private void Start(){
		gameObject.transform.GetChild(0).gameObject.SetActive(false);
	}

	void Update(){
		batteryCharge -= batteryDrainMultiplier * Time.deltaTime;

		if(batteryCharge == 0){
			SetState(false);
		}
		
		UserInput();
	}

	/**
	 * @Author Markus Larsson
	 */
	private void UserInput()
	{
		if(Input.GetKeyDown(KeyCode.F)){
			Toggle();
		}

		if(Input.GetKeyDown(KeyCode.R)){
			Recharge();
		}
	}

	/**
	 * @Author Markus Larsson
	 */
	private void SetState(bool desiredState){
		if(desiredState && batteryCharge > 0){
			//Turn on flash light (if it has battery)
			gameObject.transform.GetChild(0).gameObject.SetActive(true);
			flashLightState = true;
		}else{
			//Turn off flash light.
			gameObject.transform.GetChild(0).gameObject.SetActive(false);
			flashLightState = false;
		}
	}
	
	private void Toggle(){
		SetState(!flashLightState);
	}

	private void Recharge(){
		Recharge(100);
	}
	private void Recharge(byte setCharge){
		batteryCharge = setCharge;
	}
}