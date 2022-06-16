using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

//Martin Wallmark
/*
 * Används för att kunna pausa spelet
 */
public class PauseGame : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject resumeButton;
    [SerializeField] private GameObject menuButton;
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private PlayerSettings playerSettings;
    private ZombieObjectPooled zOP;
    //private SaveSystem saveSystem;
    //private LoadChoice loader;

    private bool isPaused;

    private void Awake()
    {
        playerSettings = GameObject.FindGameObjectWithTag("Saver").GetComponent<PlayerSettings>();
        zOP = GameObject.FindGameObjectWithTag("TheSpawnPoint").GetComponent<ZombieObjectPooled>();
        //saveSystem = GameObject.Find("SaveAndLoad").GetComponent<SaveSystem>();
        //loader = GameObject.Find("Loader").GetComponent<LoadChoice>();
        resumeButton.SetActive(false);
        menuButton.SetActive(false);
        pauseCanvas.SetActive(false);
    }
    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            togglePause();
        }

    }
    private void togglePause()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
            resumeButton.SetActive(false);
            menuButton.SetActive(false);
            pauseCanvas.SetActive(false);
        }
        else
        {
            eventSystem.SetSelectedGameObject(resumeButton);
            Time.timeScale = 0;
            isPaused = true;
            resumeButton.SetActive(true);
            menuButton.SetActive(true);
            pauseCanvas.SetActive(true);
        }

    }

    public void Resume()
    {
        togglePause();
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main menu");
    }

    /*
    private Save CreateSaveGame()
    {
        Save save = new Save();
        save.currentWave = zOP.GetCurrentWave();
        return save;
    }
    */
    /*
    private void SaveGame()
    {
        Save save = CreateSaveGame();

        // 2
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();
        Debug.Log("Game Saved");
    }
    */
}
