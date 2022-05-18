using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class FlashLight : MonoBehaviour{
	private const int maxBatteryCharge = 100;
	
	public ResourceManager rm;
    [SerializeField] [Range(1, maxBatteryCharge)] private float batteryCharge = 100.0f;
    [SerializeField] private float batteryDrainMultiplier = 0.1f;
    [SerializeField] private Slider batterySlider;

    private Light flashLight;
    private bool isOn = true;

    private void Start()
    {
        flashLight = GetComponent<Light>();
    }

    private void Update()
    {
        if(batteryCharge > 0f && isOn)
        {
            batteryCharge -= batteryDrainMultiplier * Time.deltaTime;
        }
        batterySlider.value = batteryCharge;

        if (isOn && batteryCharge <= 0)
        {
            if(rm.Get(ResourceManager.ItemType.Battery) >= 1)
            {
                Recharge();
            }
            else
            {
                SetState(false);
            }

            
        }
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Toggle();
        }
    }

    public void SetDrainMultiplier(float nDrainMultiplier)
    {
        batteryDrainMultiplier = nDrainMultiplier;
    }

    public void TurnOn()
    {
        if (batteryCharge <= 0 && rm.Get(ResourceManager.ItemType.Battery) == 0)
        {
            return;
        }
        else if(batteryCharge <= 0 && rm.Get(ResourceManager.ItemType.Battery) != 0)
        {
            Recharge();
        }
        isOn = true;
        flashLight.enabled = true;
    }

    public void TurnOff()
    {
        isOn = false;
        flashLight.enabled = false;
    }

    /**
	 * @Author Markus Larsson
	 */
    private void SetState(bool desiredState)
    {
        if (desiredState)
        {
            TurnOn();
        }
        else
        {
            TurnOff();
        }
    }

    private void Toggle()
    {
        SetState(!isOn);
    }

    /**
	 * @Simon Hessling Oscarson
	 */
    private void Recharge()
    {
        if (rm.Get(ResourceManager.ItemType.Battery) > 0)
        {
            rm.Offset(ResourceManager.ItemType.Battery, -1);
			batteryCharge = maxBatteryCharge;
		}
    }

	public float GetBatteryCharge(){
		return batteryCharge;
	}
}