using System;
using UnityEngine;

/**
 * Used with objects that have on and off functionality.
 * Comes with several methods to assist and implements save functionality.
 * 
 * @Author Markus Larsson
 */
public abstract class Toggleable : MonoBehaviour, Saveable{
	//Whether or not it is on.
	[SerializeField] protected bool state = false;

	/**
	 * Toggle the state of the object.
	 */
	public void Toggle(){
		SetState(!state);
	}
	
	/**
	 * Set the state of the object.
	 *
	 * @param desiredState The desired state of the object.
	 */
	public void SetState(bool desiredState){
		if(desiredState){
			SetTrue();
		} else{
			SetFalse();
		}
	}

	public virtual void SetTrue(){}
	public virtual void SetFalse(){}

	public bool GetState => state;
	
	public virtual object CaptureState(){
		return new SaveData{
			state = state,
		};
	}

	public virtual void RestoreState(object state){
		SaveData saveData = (SaveData)state;
		this.state = saveData.state;
		SetState(saveData.state);
	}

	[Serializable]
	private struct SaveData{
		public bool state;
	}
}
