using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject resumeButton;
    [SerializeField] private GameObject menuButton;
    
    private bool isPaused;

    private void Awake()
    {
        resumeButton.SetActive(false);
        menuButton.SetActive(false);
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
            }
            else
            {
                Time.timeScale = 0;
                isPaused = true;
                resumeButton.SetActive(true);
                menuButton.SetActive(true);
            }

    }

    public void Resume()
    {
        togglePause();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main menu");
    }

}
