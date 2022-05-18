using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour //Khaled Alraas
{
    [Header("Valume Settings")]
    [SerializeField] private TMP_Text valumeTextValue = null;
    [SerializeField] private Slider valumeSlider= null;
    [SerializeField] private float defualtValume = 0.5f;

    [Header("Confirmation")]
    [SerializeField] private GameObject confirmationPrompt = null;

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
    public void SetValume(float valume)
    {
        AudioListener.volume = valume;
        valumeTextValue.text = valume.ToString("0.0");
    }
    public void ValumeApply()
    {
        PlayerPrefs.SetFloat("masterValume", AudioListener.volume);
        StartCoroutine(ConfirmationBox());
    }

    public void ResetButton(string menuType)
    {
        if(menuType == "Audio")
        {
            AudioListener.volume = defualtValume;
            valumeSlider.value = defualtValume;
            valumeTextValue.text = defualtValume.ToString("0.0");
            ValumeApply();
        }
    }
    public IEnumerator ConfirmationBox()
    {
        confirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2);
        confirmationPrompt.SetActive(false);
    }
}
