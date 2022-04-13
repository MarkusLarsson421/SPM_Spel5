using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] private float fuel;
    [SerializeField] private float secondDelay; //time until fuel-level decreases
    [SerializeField] private Light fuelLevelIndicator; // light that changes color based on the fuel-level
    private float timer;
    private float maxFuel;
    private bool isEmpty;
    private bool isTurnedOn;

    //colors for the fuelLevelIndicator
    private Color fullGeneratorColor = new Color(0, 133, 0, 255);
    private Color halfEmptyGeneratorColor = new Color(188, 174, 0, 255);
    private Color emptyGeneratorColor = new Color(188, 0, 0, 255);

    [SerializeField] private Light[] lights;

    void Start()
    {
        isTurnedOn = true;
        maxFuel = fuel;
        fuelLevelIndicator.color = fullGeneratorColor;
    }

    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            GeneratorOnOff();
        }

        if (isTurnedOn)
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

            if (!isEmpty && fuel <= maxFuel / 2)
            {
                fuelLevelIndicator.color = halfEmptyGeneratorColor;
            }
            //For testing, set fuel to 0
            if (Input.GetKeyDown("l"))
            {
                setEmpty();
            }
            //For testing, set fuel to 100
            if (Input.GetKeyDown("k"))
            {
                Refill();
            }

        }
        
    }

    public void Refill()
    {
        fuel = maxFuel;
        fuelLevelIndicator.color = fullGeneratorColor;
        isEmpty = false;
        toggleLights();
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
            toggleLights();
        }
    }

    private void GeneratorOnOff()
    {
        if (isTurnedOn)
        {
            isTurnedOn = false;
        }
        else
            isTurnedOn = true;
    }

    private void toggleLights()
    {
        
        for(int i = 0; i < lights.Length; i++)
        {
            if (isEmpty || !isTurnedOn)
            {
                lights[i].intensity = 0;
            }
            else
            {
                lights[i].intensity = 2;
            }
            
        }
    }
}
