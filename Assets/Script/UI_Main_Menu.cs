using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Main_Menu : MonoBehaviour //Khaled Alraas
{
       [SerializeField] private GameObject MenuCanvas;
    [SerializeField] private GameObject OptionsCanvas;
    [SerializeField] private GameObject ExitConfirmationCanvas;
    [SerializeField] private Button StartButton;
    [SerializeField] private int sceneToIndex;
    [SerializeField] private Button OptionsButton;
    [SerializeField] private Button OptionsBackButton;
    [SerializeField] private Button ExitButton;
    [SerializeField] private Button YesExitButton;
    [SerializeField] private Button NoExitButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ListenToButtons();
    }
    void ListenToButtons()
    {
        StartButton.onClick.AddListener(LoadNextLevel);
        ExitButton.onClick.AddListener(OpenExitConfirmationCanvas);
        NoExitButton.onClick.AddListener(CloseExitConfirmationCanvas);
        YesExitButton.onClick.AddListener(Exit);
        OptionsButton.onClick.AddListener(ChangeMenuCanvasToOptionsCanvas);
        OptionsBackButton.onClick.AddListener(BackToMenuCanvas);
    }

    void ChangeMenuCanvasToOptionsCanvas()
    {
        MenuCanvas.SetActive(false);
        OptionsCanvas.SetActive(true);
    }
    private void BackToMenuCanvas()
    {
        MenuCanvas.SetActive(true);
        OptionsCanvas.SetActive(false);
    }

    void OpenExitConfirmationCanvas()
    {
        ExitConfirmationCanvas.SetActive(true);
    }
    void CloseExitConfirmationCanvas()
    {
        ExitConfirmationCanvas.SetActive(false);
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
