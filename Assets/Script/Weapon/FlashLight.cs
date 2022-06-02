using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class FlashLight : Toggleable{
	private const int MaxBatteryCharge = 100;
	
	public ResourceManager rm;
    [SerializeField] [Range(1, MaxBatteryCharge)] private float batteryCharge = 100.0f;
    [SerializeField] private float batteryDrainMultiplier = 0.1f;
    [SerializeField] private Slider batterySlider;

    private Light flashLight;

    private void Start()
    {
        flashLight = GetComponent<Light>();
    }

    private void Update()
    {
        if(state)
        {
			Debug.Log("hi");
            batteryCharge -= batteryDrainMultiplier * Time.deltaTime;
        }

		if (state && batteryCharge <= 0.0f)
        {
            if(rm.Get(ResourceManager.ItemType.Battery) >= 1){
				Recharge(); 
			}
            else{
                SetState(false);
            }
		}
		
		batterySlider.value = batteryCharge;
    }
    /**
	 * @Author Martin Wallmark
	 */
    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Toggle();
        }
    }

	public override void SetTrue()
    {
        if (batteryCharge <= 0 && rm.Get(ResourceManager.ItemType.Battery) <= 0)
        {
			Recharge();
        }
		state = true;
        flashLight.enabled = true;
    }

    public override void SetFalse()
    {
        state = false;
        flashLight.enabled = false;
    }

	/**
	 * @Simon Hessling Oscarson
	 */
    private void Recharge()
    {
        if (rm.Get(ResourceManager.ItemType.Battery) > 0)
        {
            rm.Offset(ResourceManager.ItemType.Battery, -1);
			batteryCharge = MaxBatteryCharge;
		}
    }

	public float GetCharge => batteryCharge;
	
	public override object CaptureState(){
		return new SaveData{
			state = state,
			batteryCharge = batteryCharge,
		};
	}

	public override void RestoreState(object state){
		SaveData saveData = (SaveData)state;
		this.state = saveData.state;
		batteryCharge = saveData.batteryCharge;
		SetState(saveData.state);
	}

	[Serializable]
	private struct SaveData{
		public bool state;
		public float batteryCharge;
	}
}