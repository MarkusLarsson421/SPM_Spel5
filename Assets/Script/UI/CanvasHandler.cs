using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CanvasHandler : MonoBehaviour // @Khaled Alraas
{
    [SerializeField] private GameObject CanvasObject;
    [SerializeField] private GameObject deathCanvasObject;
    [SerializeField] private int sceneToIndex;
    static private int MainMenuSceneIsIndex = 0;
    [SerializeField] GameObject player;
    [SerializeField] private CanvasGroup tookDamgeCanvas;
    private int currentHealth;
    private bool fadeIn = false;
    private bool fadeOut = false;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentHealth = player.GetComponent<PlayerStats>().getHealth();
        tookDamgeCanvas.alpha = 0;
    }
    // Update is called once per frame
    void Update()
    {
        EnemyAttackedMe();
        if (player.GetComponent<PlayerStats>().getHealth() <= 0)
        {
            ChangeCanvasToDeathCanvas();
        }
        
    }
    public void ReastartLevel()
    {
        int y = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(y);

    }
    void LoadLevel()
    {
        SceneManager.LoadScene(sceneToIndex);
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(MainMenuSceneIsIndex);
    }
    /**
     * khaled Ahlraas
	 * @Simon Hessling Oscarson - gjorde public.
	 * 
	 */
    public void ChangeCanvasToDeathCanvas()
    {
        CanvasObject.SetActive(false);
        deathCanvasObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    void EnemyAttackedMe()
    {
        if(player.GetComponent<PlayerStats>().getHealth()!= currentHealth)
        {
            //Script to write....
            // see witch side the zombie attacked and based on it show the correct canvas
            //Tips...
            //1- get zombie that attacked object 
            //2- get the Dot product from it
            //3- show the correct canvas
            fadeIn = true;
            currentHealth = player.GetComponent<PlayerStats>().getHealth();
        }
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
            tookDamgeCanvas.alpha += Time.deltaTime*20;
            if(tookDamgeCanvas.alpha >= 1)
            {
                fadeIn = false;
                fadeOut = true;
            }
        }
        //tookDamgeCanvas.alpha = 1;
    }

    void hideTookDamgeCanvas()
    {
        if (tookDamgeCanvas.alpha > 0)
        {
            tookDamgeCanvas.alpha -= Time.deltaTime*2;
            if (tookDamgeCanvas.alpha == 0)
            {
                fadeOut = false;
            }
        }
    }

}
