using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using EventCallbacks;

public class ScoreSystem : MonoBehaviour
{
    [Header("WaveText")]
    [SerializeField] private InreaseWaveListener increasedWave;
    [SerializeField] private TMP_Text waveText;
    [SerializeField] private TMP_Text waveText2;
    [SerializeField] private TMP_Text winWaveText;
    [SerializeField] private TMP_Text winWaveText2;
    [SerializeField] private ZombieDeathListener zombieKilled;
    [Header("ZombieKilled")]
    [SerializeField] private TMP_Text zombieKilledText;
    [SerializeField] private TMP_Text zombieKilledText2;
    [SerializeField] private TMP_Text winZombieKilledText;
    [SerializeField] private TMP_Text winZombieKilledText2;
    [Header("HeadShots")]
    [SerializeField] private HeadShootListener headShots;
    [SerializeField] private TMP_Text headShotText;
    [SerializeField] private TMP_Text winHeadShotText;
    [SerializeField] private TMP_Text headShotTextp2;
    [SerializeField] private TMP_Text winHeadShotTextp2;
    [Header("Time")]
    [SerializeField] private TMP_Text timeTakenText;
    [SerializeField] private TMP_Text timeTakenText2;
    [SerializeField] private TMP_Text winTimeTakenText;
    [SerializeField] private TMP_Text winTimeTakenText2;
    private float timeValue;
    private bool isUpdatingTime = true;


    private void Start()
    {
        //spawner = gameObject.GetComponentInChildren<ZombieObjectPooled>();
        //enemyAI = gameObject.GetComponentInChildren<EnemyAI>();
    }

    private void Update()
    {
        if (isUpdatingTime)
        {
            timeValue += Time.deltaTime;
        }
        
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeTakenText.text = "time: "+ minutes + "." + seconds;
        timeTakenText2.text = "time: " + minutes + "." + seconds;
        winTimeTakenText.text = "time: " + minutes + "." + seconds;
        winTimeTakenText2.text = "time: " + minutes + "." + seconds;

    }

    public void DisplayZombieWave()
    {
        isUpdatingTime = false;
        waveText.text = "Waves: " +  increasedWave.GetCurrentWave().ToString();
        waveText2.text = "Waves: " + increasedWave.GetCurrentWave().ToString();
        winWaveText.text = "Waves: " + increasedWave.GetCurrentWave().ToString();
        winWaveText2.text = "Waves: " + increasedWave.GetCurrentWave().ToString();
    }

    public void DisplayZombiesKilled()
    {
        
        zombieKilledText.text = "Zombies Killed: " + zombieKilled.GetDeathCounter().ToString();

        winZombieKilledText.text = "Zombies Killed: " + zombieKilled.GetDeathCounter().ToString();
    }
    public void DisplayZombiesKilled2()
    {
        if (!zombieKilled.CheckPlayer2())
        {
            zombieKilledText2.text = "Zombies Killed: 0";
            winZombieKilledText2.text = "Zombies Killed: 0";
        }
        zombieKilledText2.text = "Zombies Killed: " + zombieKilled.GetDeathCounter2().ToString();
        winZombieKilledText2.text = "Zombies Killed: " + zombieKilled.GetDeathCounter2().ToString();
    }

    public void DisplayHeadShots()
    {
        headShotText.text = "Headshots: " + headShots.GetHeadShotCounter().ToString();
        winHeadShotText.text = "Headshots: " + headShots.GetHeadShotCounter().ToString();
    }
    public void DisplayHeadShots2()
    {
        if (!headShots.CheckPlayer2()) { 
            headShotTextp2.text = "Headshots: 0";
            winHeadShotTextp2.text = "Headshots: 0";
        }

        headShotTextp2.text = "Headshots: " + headShots.GetHeadShotCounter2().ToString();
        winHeadShotTextp2.text = "Headshots: " + headShots.GetHeadShotCounter2().ToString();
    }
    public void UpdateValues()
    {
        DisplayTime(timeValue);
        DisplayZombieWave();
        DisplayZombiesKilled();
        DisplayZombiesKilled2();
        DisplayHeadShots();
        DisplayHeadShots2();
    }

    public void SetIsUpdatingTime(bool value)
    {
        isUpdatingTime = value;
    }
}
