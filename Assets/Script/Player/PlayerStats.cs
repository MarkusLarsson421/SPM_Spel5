using UnityEngine;
using EventCallbacks;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int health; // set the amount of health in unity
    [SerializeField] private int stamina; //set the stamina of health in unity
    private bool isDead = false;
    void Start()
    {
        health = 100;
        UpdatePlayerStatsCnvas();
    }

    void Update()
    {
        if (health <= 0 && !isDead)
        {
            health = 0;
            PlayerDeath();
        }
    }

    public int getHealth() { return health; }
    public int setHealth(int healthAmount) { return healthAmount; }
    public int getStamina() { return stamina; }

    float temp = 0;

    public void HitByZombie()
    {
        if (temp < 1)
        {
            temp += Time.deltaTime;
        }
        else
        {
            int randomNr = Random.Range(15, 26);
            health -= randomNr;
            temp = 0;
            UpdatePlayerStatsCnvas();
            PlayerGetHitByZombieEvent playerGetHitByZombie = new PlayerGetHitByZombieEvent();
            playerGetHitByZombie.UnitGO = gameObject;
            EventSystem.Current.FireEvent(playerGetHitByZombie);
        }
        // Hur mycket skada man tar av en zombie varierar

    }
    private void PlayerDeath()
    {
        PlayerDieEvent udei = new PlayerDieEvent();
        udei.EventDescription = "Unit " + gameObject.name + " has died.";
        udei.UnitGO = gameObject;
        EventSystem.Current.FireEvent(udei);
        isDead = true;

    }
    public bool IsDead() { return isDead; }

    void UpdatePlayerStatsCnvas()
    {
        PlayerHealthChangeEvent playerHealthChange = new PlayerHealthChangeEvent();
        playerHealthChange.UnitGO = gameObject;
        EventSystem.Current.FireEvent(playerHealthChange);
    }

}
