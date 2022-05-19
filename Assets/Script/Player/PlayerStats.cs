using UnityEngine;
using EventCallbacks;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    PlayerStats instance;
    [SerializeField] private int health = 100; 
    [SerializeField] private int stamina;
    [SerializeField] private Slider staminaSlider;
    [SerializeField] private Image walkImage;
    [SerializeField] private Image runImage;

    private bool isDead = false;
    void Start()
    {
        UpdatePlayerStatsCnvas();
        runImage.enabled = false;
        walkImage.enabled = true;
        
        
    }

    void Update()
    {
        if (health <= 0 && !isDead)
        {
            health = 0;
            PlayerDeath();
        }
        staminaSlider.value = stamina;
    }

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

    /**
     * Martin Wallmark
     */
    public void StaminaUpdater(bool isRunning)
    {
        if(stamina < 100 && !isRunning)
        {
            stamina++;
            runImage.enabled = false;
            walkImage.enabled = true;
        }
        else if(stamina > 0 && isRunning)
        {
            stamina--;
            runImage.enabled = true;
            walkImage.enabled = false;
        }
        else if(stamina <= 0 && isRunning)
        {
            runImage.enabled = false;
            walkImage.enabled = true;
        }
    }

    public int getStamina()
    {
        return stamina;
    }

	public int GetHealth(){
		return health;
	}
}
