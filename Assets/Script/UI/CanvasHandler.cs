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
    [SerializeField] private GameObject winCanvasObject;
    [SerializeField] private GameObject tookDamgeCanvasObject;
    [SerializeField] private GameObject popOutTextCanvas;
    [SerializeField] private TextMeshProUGUI nearCarText;
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
    private void Update()
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
    public void ChangeCanvasToWinCanvas()
    {
        CanvasObject.SetActive(false);
        winCanvasObject.SetActive(true);
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

        if (tookDamgeCanvas.alpha < 1)
        {
            Debug.Log("hej");
            tookDamgeCanvas.alpha += Time.deltaTime * 20;
            if (tookDamgeCanvas.alpha >= 0.9)
            {
                Debug.Log("hej2");
                hideTookDamgeCanvas();
                fadeIn = false;
                fadeOut = true;
            }
        }
    }

    void hideTookDamgeCanvas()
    {
        if (tookDamgeCanvas.alpha > 0)
        {
            Debug.Log("hej3");
            tookDamgeCanvas.alpha -= Time.deltaTime * 20;
            if (tookDamgeCanvas.alpha <= 0.1)
            {
                Debug.Log("hej4");
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
    float timer = 0;
    public void showPopOutText(string text)
    {
        popOutTextCanvas.SetActive(true);
        nearCarText.text = text;
        timer += Time.deltaTime;
        if(timer >= 3)
        {
            popOutTextCanvas.SetActive(false);
        }
    }

}
