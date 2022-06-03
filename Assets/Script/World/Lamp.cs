using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

/**
 * @Author Markus Larsson
 */
public class Lamp : Toggleable{
	//Array filled with the children which has light components.
	 [SerializeField]private Light[] lights;

	//Materials to be used for the light bulb when active and or inactive.
	[SerializeField] private Color colour;
	[SerializeField] private int materialIndex = -1;
	private Renderer meshRenderer;
	
	//Blinking variables
	[Header("Blinking variables")]
	[Tooltip("Whether or not the current lamp is flickering.")]
	[SerializeField] private bool isFlickering;
	[Tooltip("How much how many potential extra seconds there should be. \n " +
			"Formula: Random value between 0 and 1 multiplied by randomness")] 
	[SerializeField] private float randomness = 0.0f;
	[Tooltip("How long the light will be off.")]
	[SerializeField] private float blinkInterval = 5.0f;
	[Tooltip("How long the light will be on.")]
	[SerializeField] private float blinkLength = 5.0f;
	private bool currentlyFlickering;

	private void Start(){
		if(materialIndex < 0){
			Debug.LogWarning("Material Index for " + name + " is not set!");
		}

		//Reference to render.
		meshRenderer = GetComponent<MeshRenderer>();

		lights = new Light[transform.childCount];
		for(int i = 0; i < transform.childCount; i++){
			Light comp = transform.GetChild(i).GetComponent<Light>();
			if(comp != null){
				lights[i] = comp;
			}
		}

		if(lights.Length <= 0){
			Debug.LogWarning(
				name + " has no children with light objects. Did you put this script on the light source? \n" + 
				"This object needs children with light objects.");
		}
		
		//Set the inspector state to the current state.
		SetState(state);
	}

	private void Update(){
		if(currentlyFlickering == false && isFlickering){
			currentlyFlickering = true;
			StartCoroutine(Flickering());
		}
	}

	public override void SetTrue(){
		state = true;
		
		SetChildState(true);
		ChangeColour(true);
	}

	public override void SetFalse(){
		state = false;

		SetChildState(false);
		ChangeColour(false);
	}

	/**
	 * Flickers the lights until isFlickering is set to 'false'.
	 */
	private IEnumerator Flickering(){
		while(isFlickering){
			//Lights on.
			SetFalse();
			yield return new WaitForSeconds(blinkInterval + Random.value * randomness);
			
			//Lights off.
			SetTrue();
			yield return new WaitForSeconds(blinkLength + Random.value * randomness);
		}
		currentlyFlickering = false;
	}

	/**
	 * Loops through all child objects and either enables or disabled them.
	 *
	 * @Param desiredState What the state of the children is desired.
	 */
	private void SetChildState(bool desiredState)
	{
		for(int i = 0; i < lights.Length; i++){
			if (lights[i] != null)
			{
				lights[i].enabled = desiredState;
			}
		}
	}

	/**
	 * Change the colour of the material for the object with the given material index.
	 *
	 * @Param emission Whether or not emission should be turned on or not.
	 */
	private void ChangeColour(bool emissionState){
		if(materialIndex < 0){return;}

		//Gets the array and replaces the material index with the desired state material.
		//Unity requires the entire array to be replaced.
		//'sharedMaterials' is required as otherwise it might leak materials into the
		// scenes according to Unity.
		//Got a NullReferenceException here and looked it up. Might need to use "materials" instead of "sharedMaterials"
		// according to the source bellow but is immediately causing errors!
		//https://answers.unity.com/questions/228744/material-versus-shared-material.html
		Material[] materials = meshRenderer.sharedMaterials;
		if(materials[0] == null){return;}
		Material material = materials[materialIndex];
		
		if(emissionState){
			material.EnableKeyword("_EMISSION");
			material.SetColor(Shader.PropertyToID("_EmissionColor"), colour);
		} else{
			material.DisableKeyword("_EMISSION");
		}
		
		material.color = colour;
		materials[materialIndex] = material;
		meshRenderer.sharedMaterials = materials;
	}

	private void OnValidate(){
		Start();
	}
	
	public override object CaptureState(){
		return new SaveData{
			state = state,
			isFlickering = isFlickering,
		};
	}

	public override void RestoreState(object state){
		SaveData saveData = (SaveData)state;
		this.state = saveData.state;
		this.isFlickering = saveData.isFlickering;
		SetState(saveData.state);
	}

	[Serializable]
	private struct SaveData{
		public bool state;
		public bool isFlickering;
	}
}
