using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem{
	private const string exention = ".sin";
	private const string saveLocation = "/saves/";

	public static void Save<T>(string saveSubLocation, string saveName, T save, string key){
		BinaryFormatter formatter = new BinaryFormatter();
		string path = SaveLocation(saveSubLocation, saveName);
		using (FileStream stream = new FileStream(path, FileMode.Create))
		{
			formatter.Serialize(stream, save);
		}
	}

	public static T Load<T>(string saveSubLocation, string saveName, string key){
		string path = SaveLocation(saveSubLocation, saveName);
		BinaryFormatter formatter = new BinaryFormatter();
		T output;
		using (FileStream stream = new FileStream(path, FileMode.Open))
		{
			output = (T)formatter.Deserialize(stream);
		}

		return output;
	}

	private static string SaveLocation(string saveSubLocation, string saveName)
	{
		return Path.Combine(Application.persistentDataPath, saveLocation, saveSubLocation, saveName + exention);
	}
}