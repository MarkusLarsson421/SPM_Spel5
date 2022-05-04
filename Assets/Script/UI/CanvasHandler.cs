using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

//https://www.youtube.com/watch?v=tF9RMjF9wDc
public class CanvasHandler : MonoBehaviour // @Khaled Alraas
{
    [SerializeField] private GameObject CanvasObject;
    [SerializeField] private GameObject deathCanvasObject;
    [SerializeField] private GameObject tookDamgeCanvasObject;
    [SerializeField] private int sceneToIndex;
    static private int MainMenuSceneIsIndex = 0;
    [SerializeField] private CanvasGroup tookDamgeCanvas;
    [SerializeField] private TextMeshProUGUI playerHealthText;
    private bool fadeIn = false;
    private bool fadeOut = false;


    private void Awake()
    {
        tookDamgeCanvasObject.SetActive(true);
        tookDamgeCanvas.alpha = 0;

    }
    void Update()
    {
        EnemyAttackedMe();
    }
    public void ReastartLevel()
    {
        int y = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(y);

    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(MainMenuSceneIsIndex);
    }
    /**
     * khaled Alraas
	 * @Simon Hessling Oscarson - gjorde public.
	 * 
	 */
    public void ChangeCanvasToDeathCanvas()
    {
        CanvasObject.SetActive(false);
        deathCanvasObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void EnemyAttackedMe()
    {
        if (fadeIn)
        {
            showTookDamgeCanavs();
        }
        if (fadeOut)
        {
            hideTookDamgeCanvas();
        }
    }

    void showTookDamgeCanavs()
    {

        if (tookDamgeCanvas.alpha < 1 && fadeIn)
        {
            tookDamgeCanvas.alpha += Time.deltaTime * 20;
            if (tookDamgeCanvas.alpha >= 1)
            {
                fadeIn = false;
                fadeOut = true;
            }
        }
    }

    void hideTookDamgeCanvas()
    {
        if (tookDamgeCanvas.alpha > 0)
        {
            tookDamgeCanvas.alpha -= Time.deltaTime * 2;
            if (tookDamgeCanvas.alpha == 0)
            {
                fadeOut = false;
            }
        }
    }
    public void setFadeIn(bool value)
    {
        fadeIn = value;
    }

    public void UpdatePlayerStats(int playerHealth)
    {
        playerHealthText.text = playerHealth.ToString();
    }

}
