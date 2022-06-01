using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using EventCallbacks;

public class ScoreSystem : MonoBehaviour
{
    // [SerializeField] private TMP_Text waveText;
    [SerializeField] private ZombieDeathListener zombieKilled;
    [SerializeField] private TMP_Text zombieKilledText;
    [SerializeField] private TMP_Text timeTakenText;
    private float timeValue;

    private ZombieObjectPooled spawner;
    private EnemyAI enemyAI;

    private void Start()
    {
        //spawner = gameObject.GetComponentInChildren<ZombieObjectPooled>();
        //enemyAI = gameObject.GetComponentInChildren<EnemyAI>();
    }

    private void Update()
    {
        timeValue += Time.deltaTime;
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeTakenText.text = minutes + ":" + seconds;
    }

    public void DisplayZombieWave()
    {
        //waveText.text = spawner.getCurrentWave().ToString();
        //Debug.Log(waveText);
    }

    public void DisplayZombiesKilled()
    {
        zombieKilledText.text = "Zombie Killed: " + zombieKilled.GetDeathCounter().ToString();
    }
    public void UpdateValues()
    {
        DisplayTime(timeValue);
        DisplayZombieWave();
        DisplayZombiesKilled();
    }
}
