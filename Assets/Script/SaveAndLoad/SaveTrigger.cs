using UnityEngine;

public class SaveTrigger : MonoBehaviour{
	private bool hasBeenTriggered;

	private void OnCollisionEnter(Collision collision){
		GameObject go = collision.gameObject;
		if((go.CompareTag("Player1") || go.CompareTag("Player2")) && hasBeenTriggered == false){
			SaveSystem.Save();
		}
	}
}
