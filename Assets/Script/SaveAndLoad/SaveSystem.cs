using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem : MonoBehaviour{
	private const string extention = ".sin";
	private const string defaultSaveName = "autosave";

	private string SavePath(string saveName) => Application.persistentDataPath + "/" + saveName + extention;

	[ContextMenu("Save")]
	public void Save(){
		Save(defaultSaveName);
	}
	
	public void Save(string saveName){
		Dictionary<string, object> state = LoadFile(saveName);
		CaptureState(state);
		SaveFile(state, saveName);
	}


	[ContextMenu("Load")]
	public void Load(){
		Load(defaultSaveName);
	}
	
	public void Load(string saveName){
		Dictionary<string, object> state = LoadFile(saveName);
		RestoreState(state);
	}
	
	private void SaveFile(object state, string saveName){
		using(FileStream stream = File.Open(SavePath(saveName), FileMode.Create)){
			BinaryFormatter formatter = new BinaryFormatter();
			formatter.Serialize(stream, state);
		}
	}

	private Dictionary<string, object> LoadFile(string saveName){
		if(File.Exists(SavePath(saveName)) == false){
			return new Dictionary<string, object>();
		}

		using(FileStream stream = File.Open(SavePath(saveName), FileMode.Open)){
			BinaryFormatter formatter = new BinaryFormatter();
			return formatter.Deserialize(stream) as Dictionary<string, object>;
		}
	}

	private void CaptureState(Dictionary<string, object> state){
		SaveableEntity[] entities = FindObjectsOfType<SaveableEntity>();
		for(int i = 0; i < entities.Length; i++){
			state[entities[i].GetId] = entities[i].CaptureState();
		}
	}

	private void RestoreState(Dictionary<string, object> state){
		SaveableEntity[] entities = FindObjectsOfType<SaveableEntity>();
		for(int i = 0; i < entities.Length; i++){
			if(state.TryGetValue(entities[i].GetId, out object value)){
				entities[i].RestoreState(value);
			}
		}
	}
}
