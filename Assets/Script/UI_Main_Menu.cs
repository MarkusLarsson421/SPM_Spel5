using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Main_Menu : MonoBehaviour
{
    [SerializeField] private Button StartButton;
    [SerializeField] private int sceneToIndex;
    [SerializeField] private Button OptionsButton;
    [SerializeField] private Button ExitButton;
    [SerializeField] private GameObject ExitConfirmationCanvas;
    [SerializeField] private Button YesExitButton;
    [SerializeField] private Button NoExitButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartButton.onClick.AddListener(LoadNextLevel);
        ExitButton.onClick.AddListener(Exit);

    }
    void ChangeCanvas()
    {
        ExitConfirmationCanvas.SetActive(true);
        LoadNextLevel();
    }
    void LoadNextLevel()
    {
        SceneManager.LoadScene(sceneToIndex);
    }
    private void Exit()
    {
        Debug.Log("exit");
        Application.Quit();
    }
}
