using UnityEngine;

public class DataStorage : MonoBehaviour{
	[SerializeField] private GameObject player1;
	[SerializeField] private GameObject player2;
	[SerializeField] private GameObject triggerOnceGenerator;

	private void Update(){
		if(player1 != null && player2 != null){
			player1 = GameObject.FindWithTag("player1");
			player2 = GameObject.FindWithTag("player2");
		}
	}

	public GameObject GetPlayer1(){
		return player1;
	}
	
	public GameObject GetPlayer2(){
		return player2;
	}
	
	public GameObject GetTriggerOnceGenerator(){
		return triggerOnceGenerator;
	}
}
