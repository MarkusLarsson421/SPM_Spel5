using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Main_Menu : MonoBehaviour //Khaled Alraas
{
    [SerializeField] private GameObject MenuCanvas;
    [SerializeField] private GameObject OptionsCanvas;
    [SerializeField] private GameObject ExitConfirmationCanvas;
    [SerializeField] private int sceneToIndex;

    public void ChangeMenuCanvasToOptionsCanvas()
    {
        MenuCanvas.SetActive(false);
        OptionsCanvas.SetActive(true);
    }
    public void BackToMenuCanvas()
    {
        MenuCanvas.SetActive(true);
        OptionsCanvas.SetActive(false);
    }

    public void OpenExitConfirmationCanvas()
    {
        ExitConfirmationCanvas.SetActive(true);
    }
    public void CloseExitConfirmationCanvas()
    {
        ExitConfirmationCanvas.SetActive(false);
    }
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel());
    }
    public void Exit()
    {
        Debug.Log("exit");
        Application.Quit();
    }
    IEnumerator LoadLevel()
    {
        yield return null;
        SceneManager.LoadScene(sceneToIndex);
    }
}
