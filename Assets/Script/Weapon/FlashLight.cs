using UnityEngine;
using UnityEngine.InputSystem;

public class FlashLight : MonoBehaviour{
	private const int maxBatteryCharge = 100;
	
	public ResourceManager rm;
    [SerializeField] [Range(1, maxBatteryCharge)] private double batteryCharge = 100.0;
    [SerializeField] private double batteryDrainMultiplier = 0.1;

    private Light flashLight;
    private float switchTimer;
    private bool isOn;
    private bool isToggled;
    private bool canSwitch;

    private void Start()
    {
        //gameObject.SetActive(false);
        flashLight = GetComponent<Light>();
    }

    private void Update()
    {
        batteryCharge -= batteryDrainMultiplier * Time.deltaTime;

        if (batteryCharge == 0 && isOn)
        {
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

    public void SetDrainMultiplier(double nDrainMultiplier)
    {
        batteryDrainMultiplier = nDrainMultiplier;
    }


    /**
     * @Author Markus Larsson
     */
    private void UserInput()
    {
        if (isToggled || Input.GetKeyDown(KeyCode.F))
        {
            Toggle();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Recharge();
        }

        canSwitch = false;
        switchTimer = 0;
    }

    /**
	 * @Author Markus Larsson
	 */
    private void SetState(bool desiredState)
    {
        if (desiredState && batteryCharge > 0)
        {
            //Turn on flash light (if it has battery)
            //gameObject.SetActive(true);
            isOn = true;
            flashLight.intensity = 200;
            Debug.Log("on");
        }
        else
        {
            //Turn off flash light.
            //gameObject.SetActive(false);
            Debug.Log("off");
            flashLight.intensity = 0;
            isOn = false;
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

	public void setFlashLightColor(float red, float green, float blue)
    {
        flashLight.color = new Color(red, green, blue);
    }
}