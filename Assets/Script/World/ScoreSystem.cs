using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    private TMP_Text waveText;
    private TMP_Text zombieKilledText;
    private TMP_Text timeTakenText;
    private int currentWave = 0;
    private int zombiesKilled = 0;
    private float timeValue;

    private ZombieObjectPooled spawner;

    private void Start()
    {
        spawner = gameObject.GetComponentInChildren<ZombieObjectPooled>();
        DisplayZombieWave();
        DisplayTime(timeValue);
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
    }

    void DisplayZombieWave()
    {
        waveText.text = spawner.getCurrentWave().ToString();
    }
}
