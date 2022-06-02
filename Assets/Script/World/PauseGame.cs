using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

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

    private bool isPaused;

    private void Awake()
    {

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

}
