using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    private TMP_Text waveText;
    private TMP_Text zombieKilledText;
    private TMP_Text timeTakenText;
    private float timeValue;

    private ZombieObjectPooled spawner;
    private EnemyAI enemyAI;

    private void Start()
    {
        spawner = gameObject.GetComponentInChildren<ZombieObjectPooled>();
        enemyAI = gameObject.GetComponentInChildren<EnemyAI>();
    }

    private void Update()
    {
        timeValue += Time.deltaTime;
        DisplayTime(timeValue);
        DisplayZombieWave();
        DisplayZombiesKilled();
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeTakenText.text = minutes + ":" + seconds;
    }

    public void DisplayZombieWave()
    {
        waveText.text = spawner.getCurrentWave().ToString();
    }

    public void DisplayZombiesKilled()
    {
        zombieKilledText.text = enemyAI.getCounter().ToString();
    }


}
