using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    private int currentWave = 0;
    private int zombiesKilled = 0;
    private float timeValue;

    // Update is called once per frame
    void Update()
    {
        DisplayTime(timeValue);
    }
    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
    }
}
