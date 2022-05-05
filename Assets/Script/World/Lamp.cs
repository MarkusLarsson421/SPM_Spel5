using UnityEngine;

/**
 * @Author Markus Larsson
 */
public class Lamp : MonoBehaviour{
	//Changing the state inside the inspector.
	[SerializeField] private bool isOn;

	//Materials to be used for the light bulb when active and or inactive.
	[SerializeField] private Color colour;
	[SerializeField] private int materialIndex = -1;
	private Renderer meshRenderer;

	private void Start(){
		if(materialIndex < 0){
			Debug.LogWarning("Material Index for " + name + " is not set!");
		}

		//Reference to render.
		meshRenderer = GetComponent<Renderer>();
		
		//Set the inspector state to the current state.
		SetState(isOn);
		
		for(int i = 0; i < transform.childCount; i++){
			Light comp = transform.GetChild(i).gameObject.GetComponent<Light>();
			if(comp != null){
				comp.color = colour;
			}
		}
	}

	/**
	 * Toggle the state of the light.
	 */
	public void ToggleState(){
		SetState(!isOn);
	}
	
	/**
	 * Set the state of the light.
	 *
	 * @param State the desired state of the light.
	 */
	public void SetState(bool desiredState){
		if(desiredState && isOn){
			return;
		}
		if(desiredState){
			TurnOn();
		} else{
			TurnOff();
		}
	}

	/**
	 * Turn the light on.
	 */
	public void TurnOn(){
		isOn = true;
		
		SetChildState(isOn);
		ChangeColour(true);
	}
	
	/**
	 * Turn the light off.
	 */
	public void TurnOff(){
		isOn = false;

		SetChildState(isOn);
		ChangeColour(false);
	}

	/**
	 * Loops through all child objects and either enables or disabled them.
	 *
	 * @Param desiredState What the state of the children is desired.
	 */
	private void SetChildState(bool desiredState){
		for(int i = 0; i < transform.childCount; i++){
			transform.GetChild(i).gameObject.SetActive(desiredState);
		}
	}

	/**
	 * Change the colour of the material for the object with the given material index.
	 *
	 * @Param emission Whether or not emission should be turned on or not.
	 */
	private void ChangeColour(bool emission){
		if(materialIndex < 0){return;}

		//Gets the array and replaces the material index with the desired state material.
		//Unity requires the entire array to be replaced.
		//'sharedMaterials' is required as otherwise it might leak materials into the
		//	scenes according to Unity.
		Material[] materials = meshRenderer.sharedMaterials;
		Material material = materials[materialIndex];
		
		if(emission){
			material.EnableKeyword("_EMISSION");
			material.SetColor(Shader.PropertyToID("_EmissionColor"), colour);
		} else{
			material.DisableKeyword("_EMISSION");
		}
		
		material.color = colour;
		materials[materialIndex] = material;
		meshRenderer.sharedMaterials = materials;
	}

	/**
	 * Updates the light if the inspectorState value has been updated.
	 */
	private void OnValidate(){
		Start();
		
		SetState(isOn);
	}
}
