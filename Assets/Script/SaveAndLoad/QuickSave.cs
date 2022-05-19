using UnityEngine;

public class QuickSave : MonoBehaviour{
	[SerializeField] private DataStorage dataStorage;
	
	private const string saveSubLocation = "Quicksave";
	private const string saveName = "Quicksave";
	
	void Update()
    {
		if(Input.GetKeyDown(KeyCode.F5)){
			SaveSystem.Save(saveSubLocation, saveName, dataStorage.GetComponent<DataStorage>().GetGenerator(), "wack");
		}else if(Input.GetKeyDown(KeyCode.F8)){
			//SaveSystem.Load(saveName);
		}
    }
}
