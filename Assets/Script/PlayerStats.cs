using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int health; // set the amount of health in unity
    [SerializeField] private int stamina; //set the stamina of health in unity
    void Start()
    {

    }

    void Update()
    {
        if(health <= 0)
        {
            PlayerDeath();  
        }
    }

    public int getHealth()
    {
        return health;
    }

    public int getStamina()
    {
        return stamina;
    }

    
    public void HitByZombie()
    {
        // Hur mycket skada man tar av en zombie varierar
        int randomNr = Random.Range(15, 26);
        health -= randomNr;
        Debug.Log(health);

    }

    private void PlayerDeath()
    {
        //Mest till f�r att testa, inte best�mt vad som ska h�nda n�r man d�r
        Debug.Log("dead");
        GetComponent<Movement>().enabled = false;
        //Kanske respawn??
    }
    
}
