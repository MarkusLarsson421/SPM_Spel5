using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int health; // set the amount of health in unity
    [SerializeField] private int stamina; //set the stamina of health in unity
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private GameObject CanvasObject;
    [SerializeField] private GameObject deathCanvasObject;
    [SerializeField] private Button tryAgainButton;

    void Start()
    {

    }

    void Update()
    {
        setHealthtext();
        //setStaminaText();
        if (health <= 0)
        {
            health = 0;
            PlayerDeath();
            DisableCanvas();
        }
    }

    public int getHealth()  { return health; }
    public int getStamina() { return stamina; }
    private void setHealthtext() { healthText.text = health.ToString(); }
    //private void setStaminaText() { staminaText.text = stamina.ToString(); }


    public void HitByZombie()
    {
        // Hur mycket skada man tar av en zombie varierar
        int randomNr = Random.Range(15, 26);
        health -= randomNr;
        Debug.Log(health);

    }

    private void PlayerDeath()
    {
        //Mest till för att testa, inte bestämt vad som ska hända när man dör
        Debug.Log("dead");
        GetComponent<Movement>().enabled = false;
        //Kanske respawn??
    }

    void DisableCanvas()
    {
        CanvasObject.SetActive(false);
        deathCanvasObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        tryAgainButton.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        RestartGame();
    }
    public void RestartGame()
    {
        Debug.Log("restart");
        SceneManager.LoadScene("Whitebox");
    }

}
