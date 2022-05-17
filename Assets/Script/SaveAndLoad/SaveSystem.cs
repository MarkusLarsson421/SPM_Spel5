using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem{
	private const string exention = ".sin";
	private const string saveLocation = "/saves/";

	public static void Save(string saveSubLocation, string saveName, DataStorage dataStorage){
		BinaryFormatter formatter = new BinaryFormatter();
		string path = SaveLocation(saveSubLocation, saveName);
		FileStream stream = new FileStream(path, FileMode.Create);

		//PlayerData playerData = new PlayerData(pistol, flashLight, rm, stats); // remove commint

		//formatter.Serialize(stream, playerData); // remove commint
		stream.Close();
	}

	public static PlayerData Load(string saveSubLocation, string saveName){
		string path = SaveLocation(saveSubLocation, saveName);
		if(!File.Exists(path)){
			Debug.LogError("Save file " + saveName + " not found in Path: " + path);
			return null;
		}

		BinaryFormatter formatter = new BinaryFormatter();
		FileStream stream = new FileStream(path, FileMode.Open);
		PlayerData playerData = formatter.Deserialize(stream) as PlayerData;
		return playerData;
	}

	private static string SaveLocation(string saveSubLocation, string saveName){
		return Application.persistentDataPath + saveLocation + "/" + saveSubLocation + "/" + saveName + exention;
	}
}