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


    public void HitByZombie()
    {
        Debug.Log("HitByZombie");
        // Hur mycket skada man tar av en zombie varierar
        StartCoroutine(Timer());
    }
    private void PlayerDeath()
    {
        //Mest till för att testa, inte bestämt vad som ska hända när man dör
        Debug.Log("dead");
        GetComponent<Movement>().enabled = false;
    }
    IEnumerator Timer()
    {
        int randomNr = Random.Range(15, 26);
        yield return new WaitForSeconds(1);
        health -= randomNr;
    }

}
