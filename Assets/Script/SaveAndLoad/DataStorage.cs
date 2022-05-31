using UnityEngine;

public class DataStorage : MonoBehaviour
{
	[SerializeField] private GameObject[] players = new GameObject[2];
	[SerializeField] private GameObject triggerOnceGenerator;
	[SerializeField] private GameObject generator;

	private void Update(){
		if(players[0] == null)
		{
			players[0] = GameObject.FindWithTag("Player1");
		}

		if(players[1] == null)
		{
			players[1] = GameObject.FindWithTag("Player2");
		}
	}

	public PlayerData GetPlayer(int player)
	{
		//PlayerData playerData = new PlayerData(players[player].GetComponent<>())
		return null;
	}

	public GeneratorData GetGenerator()
	{
		Generator script = generator.GetComponent<Generator>();
		GeneratorData generatorData = new GeneratorData(script.GetState(), script.GetFuel());
		return generatorData;
	}
}
