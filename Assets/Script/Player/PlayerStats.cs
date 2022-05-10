using UnityEngine;
using EventCallbacks;

public class PlayerStats : MonoBehaviour
{
    PlayerStats instance;
    [SerializeField] private int health = 100; 
    [SerializeField] private int stamina; //set the stamina of health in unity
    private bool isDead = false;
    void Start()
    {
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
    //public int setHealth(int healthAmount) { return healthAmount; } Delete me
    //public int getStamina() { return stamina; } Delete me

    float Timer = 0;

    public void HitByZombie()
    {
        if (Timer < 1)
        {
            Timer += Time.deltaTime;
        }
        else
        {
            int randomNr = Random.Range(15, 26);
            health -= randomNr;
            Timer = 0;
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
        udei.UnitGO = gameObject;
        EventSystem.Current.FireEvent(udei);
        isDead = true;

    }
    public bool IsDead() { return isDead; }

    void UpdatePlayerStatsCnvas()
    {
        PlayerHealthChangeEvent playerHealthChange = new PlayerHealthChangeEvent();
        playerHealthChange.PlayerHealth = health;
        EventSystem.Current.FireEvent(playerHealthChange);
    }

}
