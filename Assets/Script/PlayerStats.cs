using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private int health;
    private int stamina;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        stamina = 100;
    }

    // Update is called once per frame
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
        int randomNr = Random.Range(15, 26);
        health -= randomNr;
        Debug.Log(health);

    }

    private void PlayerDeath()
    {
        Debug.Log("ded");
        GetComponent<Movement>().enabled = false;
    }
    
}
