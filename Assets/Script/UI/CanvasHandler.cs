using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//https://www.youtube.com/watch?v=tF9RMjF9wDc
public class CanvasHandler : MonoBehaviour // @Khaled Alraas
{
    [SerializeField] private GameObject CanvasObject;
    [SerializeField] private GameObject deathCanvasObject;
    [SerializeField] private GameObject winCanvasObject;
    [SerializeField] private GameObject popOutTextCanvas;
    [SerializeField] private TextMeshProUGUI nearCarText;
    [SerializeField] private int sceneToIndex;
    [SerializeField] private EventSystem player1Event;
    static private int MainMenuSceneIsIndex = 0;
    [SerializeField] private Image tookDamgeImage;
    [SerializeField] private TextMeshProUGUI playerHealthText;
    [SerializeField] private Color color;
    [SerializeField] private GameObject mainMenuButton;
    private bool fadeIn = false;
    private bool fadeOut = false;


    private void Awake()
    {
        color.a = 0;
    }
    private void Update()
    {
        tookDamgeImage.color = color;
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
        player1Event.SetSelectedGameObject(mainMenuButton);
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

        if (tookDamgeImage.color.a < 1)
        {
            
            color.a += Time.deltaTime * 20;
            if (color.a >= 1)
            { 
                hideTookDamgeCanvas();
                fadeIn = false;
                fadeOut = true;
            }
        }
    }

    void hideTookDamgeCanvas()
    {
        if (color.a > 0)
        {
           
            color.a -= Time.deltaTime * 2;
            if (color.a <= 0)
            {
                fadeOut = false;
            }
        }
    }
    public void setFadeIn(bool value)
    {
        fadeIn = value;
    }

    //public void UpdatePlayerStats(int playerHealth)
    //{
    //    playerHealthText.text = playerHealth.ToString();
    //}
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
