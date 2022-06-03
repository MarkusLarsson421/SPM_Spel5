using System;
using UnityEngine;
using EventCallbacks;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PlayerStats : MonoBehaviour, Saveable
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
        UpdatePlayerHealth();
        runImage.enabled = false;
        walkImage.enabled = true;
		
		SaveableEntity entity = GetComponent<SaveableEntity>();
		entity.GenerateId();
		GameObject.FindGameObjectWithTag("SaveSystem").GetComponent<SaveSystem>().AddEntity(entity);
	}

    private void Awake()
    {
        sm = FindObjectOfType<SoundManager>();
    }

    void Update()
    {
        UpdatePlayerHealth();

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
                UpdatePlayerHealth();
            }

        }
        if (health <= 0 && !isDead)
        {
            health = 0;
            PlayerDeath();
        }
        //handler.SetCurrentHealth(health); // Anv�nds inte l�ngre


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
            UpdatePlayerHealth();
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
        /*
        PlayerDieEvent player = new PlayerDieEvent();
        player.UnitGO = gameObject;
        player.FireEvent();
        */
        CanvasHandler deathCanvas = GetComponentInChildren<CanvasHandler>();
        deathCanvas.ChangeCanvasToDeathCanvas();
        isDead = true;
    }

    public bool IsDead() { return isDead; }

    void UpdatePlayerHealth()
    {
        tookDamge.setValue(GetHealth());
        //PlayerHealthChangeEvent playerHealthChange = new PlayerHealthChangeEvent();
        //playerHealthChange.PlayerHealth = health;
        //playerHealthChange.FireEvent();

    }

    /**
     * Martin Wallmark
     * 
     * Uppdaterar ikonen p� gubben baserat p� om man springer eller inte.
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

	public object CaptureState(){
		Debug.Log("TEST SAVE PLAYER SHIT");
		Vector3 pos = transform.position;
		Quaternion rot = transform.rotation;
		return new SaveData{
			pos = new[]{pos.x, pos.y, pos.z},
			rot = new []{rot.x, rot.y, rot.z, rot.w},
			health = health,
			isDead = isDead,
		};
	}

	public void RestoreState(object state){
		Debug.Log("TEST LOAD PLAYER SHIT");
		SaveData saveData = (SaveData)state;
		transform.position = new Vector3(saveData.pos[0], saveData.pos[1], saveData.pos[2]);
		transform.rotation = new Quaternion(saveData.rot[0], saveData.rot[1], saveData.rot[2], saveData.rot[3]);
		health = saveData.health;
		isDead = saveData.isDead;
	}

	[Serializable]
	private struct SaveData{
		public float[] pos;
		public float[] rot;
		public int health;
		public bool isDead;
	}
}
