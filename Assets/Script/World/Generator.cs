using System;
using UnityEngine;

public class Generator : Toggleable{
	private const int maxFuel = 100;
	
	[SerializeField] private Interactable interactable;
    [SerializeField] private SoundManager sM;

	//Fuel
    [Header("Fuel settings")]
	[SerializeField][Range(1, maxFuel)] private float fuel;
	[SerializeField] private float fuelDrainMultiplier = 1.0f;

	//Colours to display the current fuel stage to the player.
	[SerializeField] private Color[] fuelIndicatorColours;

	[Header("Generator interactions")]
	[SerializeField] private GameObject[] doors;
	[Tooltip("Normal powered state of the generator and its components.")]
	[SerializeField] private GameObject[] highPowerLights;
	[Tooltip("Powered objects when the power is turned off. Such as emergency lights.")]
	[SerializeField] private GameObject[] lowPowerLights;

	[SerializeField] private Light fuelIndicator;
	
	[SerializeField] private GameObject interactingPlayer;
	public string interactingTag;
	private bool isToggled;
	private bool hasRegistered;
	private bool doorsOpen;
	[SerializeField] private ResourceManager rm;

	//Comps = Components
	private Lamp[] highPowerComps;
	private Lamp[] lowPowerComps;
	private Door[] doorComps;

	private void Start(){
        //sM = GameObject.Find("SM").GetComponent<SoundManager>();
        fuelIndicator = transform.GetChild(0).gameObject.GetComponent<Light>();

		highPowerComps = GetComponentsFromArray<Lamp>(highPowerLights);
		lowPowerComps = GetComponentsFromArray<Lamp>(lowPowerLights);
		doorComps = GetComponentsFromArray<Door>(doors);

		SetState(state);
		FuelIndicator();
	}

	private void Update(){

        if (isToggled && !hasRegistered)
        {
			interactingPlayer = interactable.interactingGameObject.transform.parent.gameObject;
			rm = interactable.interactingGameObject.GetComponentInChildren<ResourceManager>();
			if(rm.Get(ResourceManager.ItemType.Scrap) >= 1 && !state)
            {
                sM.SoundPlaying("generatorOn");

                RefillFuel(100);
				OpenDoors();
				rm.Offset(ResourceManager.ItemType.Scrap, -1);
			}
			
			hasRegistered = true;
		}
		DrainFuel();
		FuelIndicator();
	}

	public void SetInteractingPlayer()
    {
		isToggled = true;
		hasRegistered = false;
    }
	
	/**
	 * @Author Martin Wallmark and Markus Larsson
	 */
	public void RefillFuel(float amount){
		if(fuel + amount > maxFuel){
			amount = maxFuel - fuel;
		}
		fuel += amount;
		SetTrue();
	}
	
	public override void SetTrue(){
		if(fuel <= 0){return;}
		state = true;
		SetLampState(true, highPowerComps);
		SetLampState(false, lowPowerComps);
		fuelIndicator.enabled = true;
		call();
    }
	public void call()
    {
		GameObject[] zombies;
		zombies = GameObject.FindGameObjectsWithTag("Zombie");
		foreach (GameObject zombie in zombies)
		{
			//zombie.GetComponent<EnemyAI>().iRTCN.setChasingRange(1000);

		}
		////Khaled 
		//GneratorIsOnEvent generatorIsOn = new GneratorIsOnEvent();
		//EventSystem.Current.FireEvent(generatorIsOn);
		////Khaled
		//Debug.Log("i work Generator");
	}

	public override void SetFalse(){
		state = false;
		SetLampState(false, highPowerComps);
		SetLampState(true, lowPowerComps);
		fuelIndicator.enabled = false;
		sM.MuteSource("generatorOn");
	}

	public void OpenDoors(){
		SetDoorState(true, doorComps);
	}

	public void SetFuel(float fuel) => this.fuel = fuel;
	public float GetFuel => fuel;

	/**
	 * Drains fuel each frame.
	 *
	 * @Author Markus Larsson and Martin Wallmark
	 */
	private void DrainFuel(){
		if(state){
			fuel -= fuelDrainMultiplier * Time.deltaTime;
		}
		if(fuel <= 0){
			fuel = 0;
			SetFalse();
		}
	}

	/**
	 * @Author Markus Larsson
	 */
	private void FuelIndicator(){
		float fuelRatio = fuel / maxFuel;
		if(fuelRatio < .25f){
			fuelIndicator.color = fuelIndicatorColours[2];
		}else if(fuelRatio < .5f){
			fuelIndicator.color = fuelIndicatorColours[1];
		} else if(fuelRatio < 1.0f){
			fuelIndicator.color = fuelIndicatorColours[0];
		}
	}

	/*
	 * Tells the Lamps to be either powered or unpowered.
	 * 
	 * @Param desiredState What state the Lamp is desired to be in.
	 * @Param doors Array of which Lamp components to set to the desired state.
	 * 
	 * @Author Martin Wallmark and Markus Larsson
	 */
	private void SetLampState(bool desiredState, Lamp[] lamps){
		for(int i = 0; i < lamps.Length; i++){
			if(lamps[i] != null){
				lamps[i].SetState(desiredState);
			}
		}
	}
	
	/*
	 * Tells the doors to either open or close.
	 *
	 * @Param desiredState What state the Door is desired to be in.
	 * @Param doors Array of which Door components to set to the desired state.
	 * @Author Martin Wallmark and Markus Larsson
	 */
	private void SetDoorState(bool desiredState, Door[] doors){
		for(int i = 0; i < doors.Length; i++){
			if(doors[i] != null){
				doors[i].SetState(desiredState);
			}
		}
	}

	/*
	 * Gets all Components of the specified type inside all game objects from the list and returns a list of those
	 * Components.
	 *
	 * @Param gameObjects The Array of GameObjects to copy the Components from.
	 * @Return Array of the Components.
	 * @Author Markus Larsson
	 */
	private static T[] GetComponentsFromArray<T>(GameObject[] gameObjects){
		T[] comps = new T[gameObjects.Length];
		
		for(int i = 0; i < gameObjects.Length; i++){
			T comp = gameObjects[i].GetComponent<T>();
			if(comp != null){
				gameObjects[i].GetComponent<T>();
				comps[i] = comp;
			}
		}
		
		//Sending array's back is not a good design decision but it makes it more readable
		return comps;
	}

	public override object CaptureState(){
		return new SaveData{
			state = state,
			fuel = fuel,
		};
	}

	public override void RestoreState(object state){
		SaveData saveData = (SaveData)state;
		this.state = saveData.state;
		fuel = saveData.fuel;
		SetState(saveData.state);
	}

	[Serializable]
	private struct SaveData{
		public bool state;
		public float fuel;
	}
}