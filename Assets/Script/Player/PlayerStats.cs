using UnityEngine;
using EventCallbacks;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    PlayerStats instance;
    [SerializeField] private int health = 100; 
    [SerializeField] private int stamina; //set the stamina of health in unity
    //[SerializeField] private Slider staminaSlider;
    [SerializeField] private Image walkImage;
    [SerializeField] private Image runImage;
    [SerializeField] private CanvasHandler ch;
    [SerializeField] private UIHandler handler;
    private float timer;
    private bool isDead = false;
    private bool isHit;

    void Start()
    {
        UpdatePlayerStatsCnvas();
        runImage.enabled = false;
        walkImage.enabled = true;    
    }

    void Update()
    {
        UpdatePlayerStatsCnvas();

        if (isHit)
        {
            timer += Time.deltaTime;
            if (timer >= 4)
            {
                isHit = false;
                timer = 0;
            }
        }
        if (!isHit && health != 100)
        {
            timer += Time.deltaTime;
            if (timer >= 0.5)
            {
                health++;
                timer = 0;
            }
            
        }
        if (health <= 0 && !isDead)
        {
            health = 0;
            PlayerDeath();
        }
        handler.SetCurrentHealth(health);

        
        //staminaSlider.value = stamina;
    }

    float Timer = 0;
    public void HitByZombie()
    {
        if (Timer < 1)Timer += Time.deltaTime;
        else
        {
            int randomNr = Random.Range(15, 26);        // Hur mycket skada man tar av en zombie varierar
            health -= randomNr;
            Timer = 0;
            UpdatePlayerStatsCnvas();
            PlayerGetHitByZombieEvent playerGetHitByZombie = new PlayerGetHitByZombieEvent();
            playerGetHitByZombie.UnitGO = gameObject;
            playerGetHitByZombie.FireEvent();
            isHit = true;
            timer = 0;

        }

    }
    private void PlayerDeath()
    {
        PlayerDieEvent udei = new PlayerDieEvent();
        udei.UnitGO = gameObject;
        udei.FireEvent();
        isDead = true;

    }
    public bool IsDead() { return isDead; }

    void UpdatePlayerStatsCnvas()
    {
        PlayerHealthChangeEvent playerHealthChange = new PlayerHealthChangeEvent();
        playerHealthChange.PlayerHealth = health;
        playerHealthChange.FireEvent();
        
    }

    /**
     * Martin Wallmark
     * 
     * Uppdaterar ikonen på gubben baserat på om man springer eller inte.
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
