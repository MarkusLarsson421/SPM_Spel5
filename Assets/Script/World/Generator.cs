using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] private float fuel;
    [SerializeField] private float secondDelay; //time until fuel-level decreases
    [SerializeField] private Light fuelLevelIndicator; // light that changes color based on the fuel-level
    private float timer;
    private float maxFuel;
    private bool isEmpty;
    private bool isTurnedOn;
    private bool doorsDisabled = false;

    //colors for the fuelLevelIndicator
    private Color fullGeneratorColor = new Color(0, 133, 0, 255);
    private Color halfEmptyGeneratorColor = new Color(188, 174, 0, 255);
    private Color emptyGeneratorColor = new Color(188, 0, 0, 255);

    [SerializeField] private Light[] lights;
    [SerializeField] private SingleDoor[] singleDoors;

    void Start()
    {
        isTurnedOn = true;
        maxFuel = fuel;
        fuelLevelIndicator.color = fullGeneratorColor;
    }

    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            GeneratorOnOff();
        }

        if (isTurnedOn)
        {
            if (!isEmpty)
            {
                timer += Time.deltaTime;

                if (timer >= secondDelay)
                {
                    DecreaseFuelLevel();
                    timer = 0;
                }
            }

            if (!isEmpty && fuel <= maxFuel / 2)
            {
                fuelLevelIndicator.color = halfEmptyGeneratorColor;

                LerpingLights();
            }
            //For testing, set fuel to 0
            if (Input.GetKeyDown("l"))
            {
                SetEmpty();
            }
            //For testing, set fuel to 100
            if (Input.GetKeyDown("k"))
            {
                Refill();
            }

        }

    }

	/*
	 * @Author Martin Wallmark
	 */
    public void Refill()
    {
        fuel = maxFuel;
        fuelLevelIndicator.color = fullGeneratorColor;
        isEmpty = false;
        ToggleLights();
        OpenDoor();
    }

	/*
	 * @Author Martin Wallmark
	 */
    private void SetEmpty()
    {
        fuel = 0;
        fuelLevelIndicator.color = emptyGeneratorColor;
        isEmpty = true;
    }
	
	/*
	 * @Author Martin Wallmark
	 */
    private void DecreaseFuelLevel()
    {
        fuel--;
        if (fuel <= 0)
        {
            isEmpty = true;
            fuelLevelIndicator.color = emptyGeneratorColor;
            ToggleLights();
        }
    }
	
	/*
	 * @Author Martin Wallmark
	 */
    private void GeneratorOnOff()
    {
        if (isTurnedOn)
        {
            isTurnedOn = false;
        }
        else
            isTurnedOn = true;
    }

	/*
	 * @Author Martin Wallmark
	 */
    private void ToggleLights()
    {

        for (int i = 0; i < lights.Length; i++)
        {
            if (isEmpty || !isTurnedOn)
            {
                lights[i].intensity = 0;
            }
            else
            {
                lights[i].intensity = 2;
            }

        }
    }

	/*
	 * @Author Martin Wallmark
	 */
    private void OpenDoor()
    {
        if (singleDoors.Length == 0 && doorsDisabled) { return; }
        for (int i = 0; i < singleDoors.Length; i++)
        {
            singleDoors[i].ToggleOpen();
            doorsDisabled = true;
        }
	}

	/*
	 * When generator is half full the light intensity will lerp from 2 to 1 before shutting off
	 * 
	 * @Author Martin Wallmark
	 */
	private void LerpingLights()
    {
        foreach(Light light in lights){
            float lerpTimer = Time.deltaTime / 3f;
            light.intensity = Mathf.Lerp(light.intensity, 1f, lerpTimer);
        }
        
    }

}
