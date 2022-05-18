using UnityEngine;

public class DataStorage : MonoBehaviour{
	[SerializeField] private GameObject player1;
	[SerializeField] private GameObject player2;
	[SerializeField] private GameObject triggerOnceGenerator;

	private void Update(){
		if(player1 != null){
			player1 = GameObject.FindWithTag("player1");
		}

		if(player2 != null){
			player2 = GameObject.FindWithTag("player2");
		}
	}
}
