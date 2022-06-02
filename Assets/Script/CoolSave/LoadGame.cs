using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
/*
 * 
 */
public class LoadGame : MonoBehaviour
{

    [SerializeField] ZombieObjectPooled zOP;
    private void Start()
    {
        if (LevelLoader.isSceneLoaded)
        {
            LoadTheGame();
        }
        
    }

    public void LoadTheGame()
    {

        zOP = GameObject.FindGameObjectWithTag("TheSpawnPoint").GetComponent<ZombieObjectPooled>();

        // 1
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {


            // 2
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();



            // 4
            zOP.SetCurrentWave(save.currentWave);

            Debug.Log("Game Loaded");
        }
        else
        {
            Debug.Log("No game saved!");
        }

    }
}
