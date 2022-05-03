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
    private bool isDead = false;
    void Start()
    {
        health = 100;
    }

    void Update()
    {
        setHealthtext();
        if (health <= 0)
        {
            health = 0;
            PlayerDeath();
        }
    }

    public int getHealth()  { return health; }
    public int setHealth(int healthAmount) { return healthAmount; }
    public int getStamina() { return stamina; }
    private void setHealthtext() { healthText.text = health.ToString(); }
    //private void setStaminaText() { staminaText.text = stamina.ToString(); }

    float temp = 0;

    public void HitByZombie()
    {
        if(temp < 1)
        {
            temp += Time.deltaTime;
        }
        else
        {
            int randomNr = Random.Range(15, 26);
            //health -= randomNr;
            temp = 0;
        }
        // Hur mycket skada man tar av en zombie varierar
    }
    private void PlayerDeath()
    {
        //Mest till för att testa, inte bestämt vad som ska hända när man dör
        GetComponent<Movement>().enabled = false;
        isDead = true;
    }
    public bool IsDead() { return isDead; }

}
