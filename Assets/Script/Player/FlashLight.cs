using UnityEngine;
using UnityEngine.InputSystem;

public class FlashLight : MonoBehaviour{
	public RM rm;
	[SerializeField] [Range(1, 100)] private double batteryCharge = 100.0;
	[SerializeField] private double batteryDrainMultiplier = 0.1;
	
	private bool flashLightState;

	private bool isToggled;


	private float switchTimer;

	private bool canSwitch;
	private void Start(){
		gameObject.transform.GetChild(0).gameObject.SetActive(false);
	}

	void Update(){
		batteryCharge -= batteryDrainMultiplier * Time.deltaTime;

		if(batteryCharge == 0){
			SetState(false);
		}


		switchTimer += Time.deltaTime;

		if (switchTimer >= 0.2f)
		{
			canSwitch = true;
		}

        if (canSwitch)
        {
			UserInput();
		}
		
	}

	public void OnFire(InputAction.CallbackContext context)
	{
		if (context.performed)
		{
			isToggled = true;
		}

		if (context.canceled)
		{
			isToggled = false;
		}

	}


		/**
		 * @Author Markus Larsson
		 */
		private void UserInput()
	{
		if(isToggled || Input.GetKeyDown(KeyCode.F)){
			Toggle();
		}

		if(Input.GetKeyDown(KeyCode.R)){
			
			Recharge();
		}
		canSwitch = false;
		switchTimer = 0;
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
	/**
	 * @Simon Hessling Oscarson
	 * 
	 */
	private void Recharge(){
		if (rm.GetCurrentBatteries() != 0)
		{
			rm.SetCurrentBatteries(rm.GetCurrentBatteries() - 1);
			RechargeAmount(100);
		}
	}
	/**
	 * @Simon Hessling Oscarson
	 * 
	 */
	private void RechargeAmount(byte setCharge){
		batteryCharge = setCharge;
	}
}