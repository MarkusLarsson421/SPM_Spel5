using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour //Khaled Alraas
{
    [Header("Level to Load")]
    [SerializeField] private string sceneNameToLoad;

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
        SceneManager.LoadScene(sceneNameToLoad);
    }
}
