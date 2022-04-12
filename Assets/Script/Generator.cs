using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] private float fuel;
    [SerializeField] private float secondDelay; //time until fuel-level decreases
    [SerializeField] private Light fuelLevelIndicator;
    private float timer;
    private float maxFuel;
    private bool isEmpty;

    private Color fullGeneratorColor = new Color(0, 133, 0, 255);
    private Color halfEmptyGeneratorColor = new Color(188, 174, 0, 255);
    private Color emptyGeneratorColor = new Color(188, 0, 0, 255);


    void Start()
    {
        maxFuel = fuel;
        fuelLevelIndicator.color = fullGeneratorColor;
    }

    void Update()
    {
        if (!isEmpty)
        {
            timer += Time.deltaTime;

            if (timer >= secondDelay)
            {
                DecreaseFuelLevel();
                timer = 0;
            }
        }
        if (!isEmpty && fuel <= maxFuel/2)
        {
            fuelLevelIndicator.color = halfEmptyGeneratorColor;
        }     
    }

    public void Refill()
    {
        fuel = 100;
        fuelLevelIndicator.color = fullGeneratorColor;
        isEmpty = false;
    }

    //script for testing
    private void setEmpty()
    {
        fuel = 0;
        fuelLevelIndicator.color = emptyGeneratorColor;
        isEmpty = true;
    }

    private void DecreaseFuelLevel()
    {
        fuel--;
        if(fuel <= 0)
        {
            isEmpty = true;
            fuelLevelIndicator.color = emptyGeneratorColor;
        }
    }
}
