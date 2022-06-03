using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem : MonoBehaviour{
	[SerializeField] private LoadChoice loader;
	
	private const string defaultSaveName = "autosave";
	private const string extention = ".sin";
	private bool isLoadingSave;
	private SaveableEntity[] entities;

	private GameObject player1;
	private GameObject player2;

	private string SavePath(string saveName) => Application.persistentDataPath + "/" + saveName + extention;

	private void Awake(){
		entities = FindObjectsOfType<SaveableEntity>();
		//loader = GameObject.Find("Loader").GetComponent<LoadChoice>();
	}

    private void Start()
    {
        if (LevelLoader.isSceneLoaded)
        {
			Debug.Log("wadasda");
			Load(defaultSaveName);
			LevelLoader.isSceneLoaded = false;
		}
		
    }

	[ContextMenu("Save")]
	public void Save(){
		Save(defaultSaveName);
	}
	
	public void Save(string saveName){
		Debug.Log("Saved: " + saveName + "!");
		Dictionary<string, object> state = LoadFile(saveName);
		CaptureState(state);
		SaveFile(state, saveName);
	}

	[ContextMenu("Load")]
	public void Load(){
		Load(defaultSaveName);
	}
	
	public void Load(string saveName){
		Debug.Log("Loaded: " + saveName + "!");
		Dictionary<string, object> state = LoadFile(saveName);
		RestoreState(state);
	}

	public void AddEntity(SaveableEntity entity){
		SaveableEntity[] tmp = new SaveableEntity[entities.Length + 1];
		entities.CopyTo(tmp, 0);
		tmp[tmp.Length - 1] = entity;
		entities = tmp;
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
		for(int i = 0; i < entities.Length; i++){
			state[entities[i].GetId] = entities[i].CaptureState();
		}
	}

	private void RestoreState(Dictionary<string, object> state){
		for(int i = 0; i < entities.Length; i++){
			if(state.TryGetValue(entities[i].GetId, out object value)){
				entities[i].RestoreState(value);
			}
		}
	}
}
