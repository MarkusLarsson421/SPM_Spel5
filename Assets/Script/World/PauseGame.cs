using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseGame : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isPaused;

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            togglePause();
        }
    }

    private void togglePause()
    {
        if (!isPaused)
        {
            Time.timeScale = 1;
            isPaused = true;
        }
        else
        {
            Time.timeScale = 0;
            isPaused = false;
        }
            
    }
    
}
