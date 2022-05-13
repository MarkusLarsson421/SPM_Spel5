using UnityEngine;
using UnityEngine.InputSystem;

public class FlashLight : MonoBehaviour{
	private const int maxBatteryCharge = 100;
	
	public ResourceManager rm;
    [SerializeField] [Range(1, maxBatteryCharge)] private double batteryCharge = 100.0;
    [SerializeField] private double batteryDrainMultiplier = 0.1;

    private Light flashLight;
    private bool isOn;

    private void Start()
    {
        flashLight = GetComponent<Light>();
    }

    private void Update()
    {
        batteryCharge -= batteryDrainMultiplier * Time.deltaTime;

        if (isOn && batteryCharge == 0)
        {
            SetState(false);
        }
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Toggle();
        }
    }

    public void SetDrainMultiplier(double nDrainMultiplier)
    {
        batteryDrainMultiplier = nDrainMultiplier;
    }

    public void TurnOn()
    {
        if (batteryCharge <= 0)
        {
            return;
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
}