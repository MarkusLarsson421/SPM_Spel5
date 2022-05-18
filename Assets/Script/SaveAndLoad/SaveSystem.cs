using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem{
	private const string exention = ".sin";
	private const string saveLocation = "/saves/";

	public static void Save(string saveSubLocation){
		BinaryFormatter formatter = new BinaryFormatter();
		string path = SaveLocation(saveSubLocation);
		FileStream stream = new FileStream(path, FileMode.Create);

		//Data to save
		PlayerData player1Data = new PlayerData(pistol, flashLight, rm, stats);
		PlayerData player2Data = new PlayerData(pistol, flashLight, rm, stats);
		TriggerOnceGeneratorData triggerOnceGenerator = new TriggerOnceGeneratorData();

		formatter.Serialize(stream, player1Data);
		formatter.Serialize(stream, player2Data);
		formatter.Serialize(stream, triggerOnceGenerator);
		stream.Close();
	}

	public static PlayerData Load(string saveSubLocation){
		string path = SaveLocation(saveSubLocation);
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