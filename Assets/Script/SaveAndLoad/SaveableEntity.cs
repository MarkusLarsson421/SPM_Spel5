using System;
using System.Collections.Generic;
using UnityEngine;

public class SaveableEntity : MonoBehaviour{
	[SerializeField] private string id;
	public string GetId => id;

	private Saveable[] saveables;
	
	private void Start(){
		saveables = GetComponents<Saveable>();
	}

	public Dictionary<string, object> CaptureState(){
		Dictionary<string, object> state = new Dictionary<string, object>();
		for(int i = 0; i < saveables.Length; i++){
			state[saveables[i].GetType().ToString()] = saveables[i].CaptureState();
		}
		return state;
	}

	public void RestoreState(object state){
		Dictionary<string, object> stateDict = (Dictionary<string, object>)state;
		for(int i = 0; i < saveables.Length; i++){
			string typeName = saveables[i].GetType().ToString();
			if(stateDict.TryGetValue(typeName, out object value)){
				saveables[i].RestoreState(value);
			}
		}
	}
	
	[ContextMenu("Generate ID")]
	public void GenerateId() => id = Guid.NewGuid().ToString();
}
