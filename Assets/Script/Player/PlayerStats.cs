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
    [SerializeField] private ColorModifer tookDamge;
    private float timer;
    private bool isDead = false;
    private bool isHit;

    private SoundManager sm;

    void Start()
    {
        UpdatePlayerStatsCnvas();
        runImage.enabled = false;
        walkImage.enabled = true;
        sm = FindObjectOfType<SoundManager>();
    }

    void Update()
    {
        //UpdatePlayerStatsCnvas();

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
                UpdatePlayerStatsCnvas();
            }

        }
        if (health <= 0 && !isDead)
        {
            health = 0;
            PlayerDeath();
        }
        //handler.SetCurrentHealth(health); // Används inte längre


        //staminaSlider.value = stamina;
    }

    float Timer = 0;
    public void HitByZombie()
    {
        if (Timer < 1) Timer += Time.deltaTime;
        else
        {
            int randomNr = Random.Range(15, 26);        // Hur mycket skada man tar av en zombie varierar
            health -= randomNr;
            Timer = 0;
            UpdatePlayerStatsCnvas();
            ch.setFadeIn(true);
            ch.EnemyAttackedMe();
            //PlayerGetHitByZombieEvent playerGetHitByZombie = new PlayerGetHitByZombieEvent();
            //playerGetHitByZombie.player = gameObject;
            //playerGetHitByZombie.FireEvent();
            isHit = true;
            timer = 0;
            if (gameObject.tag == "Player1")
            {
                sm.SoundPlaying("danHit");
            }
            else if(gameObject.tag == "Player2")
            {
                sm.SoundPlaying("kateHit");
            }
        }

    }

    private void PlayerDeath()
    {
        PlayerDieEvent player = new PlayerDieEvent();
        player.UnitGO = gameObject;
        player.FireEvent();
        isDead = true;
    }

    public bool IsDead() { return isDead; }

    void UpdatePlayerStatsCnvas()
    {
        tookDamge.setValue(GetHealth());
        //PlayerHealthChangeEvent playerHealthChange = new PlayerHealthChangeEvent();
        //playerHealthChange.PlayerHealth = health;
        //playerHealthChange.FireEvent();

    }

    /**
     * Martin Wallmark
     * 
     * Uppdaterar ikonen på gubben baserat på om man springer eller inte.
     */
    public void StaminaUpdater(bool isRunning)
    {
        if (stamina < 100 && !isRunning)
        {
            stamina++;
            runImage.enabled = false;
            walkImage.enabled = true;
        }
        else if (stamina > 0 && isRunning)
        {
            stamina--;
            runImage.enabled = true;
            walkImage.enabled = false;
        }
        else if (stamina <= 0 && isRunning)
        {
            runImage.enabled = false;
            walkImage.enabled = true;
        }
    }

    public int getStamina()
    {
        return stamina;
    }

    public int GetHealth()
    {
        return health;
    }
}
