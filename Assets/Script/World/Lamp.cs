using UnityEngine;

/**
 * @Author Markus Larsson
 */
public class Lamp : MonoBehaviour{
	//Changing the state inside the inspector.
	[SerializeField] private bool isOn;

	//Materials to be used for the light bulb when active and or inactive.
	[SerializeField] private Material activeMaterial;
	[SerializeField] private Material inactiveMaterial;
	[SerializeField] private int materialIndex = -1;
	private Renderer meshRenderer;

	private void Start(){
		if(materialIndex < 0){
			Debug.LogWarning("Material Index for " + name + " is not set!" + "\n" + "Setting index to 0.");
			materialIndex = 0;
		}

		if(activeMaterial == null || inactiveMaterial == null){
			Debug.LogWarning("Active and inactive material for " + name + " is not set!");
		}
		
		//Reference to render.
		meshRenderer = GetComponent<Renderer>();
		
		//Set the inspector state to the current state.
		SetState(isOn);
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
		ChangeMaterial(materialIndex, activeMaterial);
	}
	
	/**
	 * Turn the light off.
	 */
	public void TurnOff(){
		isOn = false;
		
		SetChildState(isOn);
		ChangeMaterial(materialIndex, inactiveMaterial);
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
	 * Change the material with the given index.
	 *
	 * @Param index Which material at the given index to be changed.
	 * @Param material What material to replace the given index with.
	 */
	private void ChangeMaterial(int index, Material material){
		//Gets the array and replaces the material index with the desired state material.
		//Unity requires the entire array to be replaced.
		//sharedMaterials is required as otherwise it might
		//	leak materials into the scenes according to Unity.
		Material[] materials = meshRenderer.sharedMaterials;
		materials[index] = material;
		meshRenderer.materials = materials;
	}

	/**
	 * Updates the light if the inspectorState value has been updated.
	 */
	private void OnValidate(){
		meshRenderer = GetComponent<Renderer>();
		
		SetState(isOn);
	}
}
