using System;
using System.Collections.Generic;
using UnityEngine;

public class SaveableEntity : MonoBehaviour{
	[SerializeField] private string id = "";
	public string GetId => id;

	[ContextMenu("Generate ID")]
	private void GenerateId() => id = Guid.NewGuid().ToString();

	public Dictionary<string, object> CaptureState(){
		Dictionary<string, object> state = new Dictionary<string, object>();
		Saveable[] saveables = GetComponents<Saveable>();
		for(int i = 0; i < saveables.Length; i++){
			state[saveables[i].GetType().ToString()] = saveables[i].CaptureState();
		}

		return state;
	}

	public void RestoreState(object state){
		Dictionary<string, object> stateDict = (Dictionary<string, object>)state;
		Saveable[] saveables = GetComponents<Saveable>();
		for(int i = 0; i < saveables.Length; i++){
			string typeName = saveables[i].GetType().ToString();
			if(stateDict.TryGetValue(typeName, out object value)){
				saveables[i].RestoreState(value);
			}
		}
	}
}
