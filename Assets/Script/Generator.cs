using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] private float fuel;
    [SerializeField] private float secondDelay;
    [SerializeField] private Light fuelLevelIndicator;
    private float timer;

    private Color fullTankColor = new Color(0, 133, 0, 255);
    private Color halfEmptyTankColor = new Color(188, 174, 0, 255);
    private Color emptyTankColor = new Color(188, 0, 0, 255);

    private float maxFuel;
    private bool isEmpty;

    // Start is called before the first frame update
    void Start()
    {
        maxFuel = fuel;
        fuelLevelIndicator.color = fullTankColor;
    }

    // Update is called once per frame
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

        if (fuel == maxFuel/2)
        {
            fuelLevelIndicator.color = halfEmptyTankColor;
        }
        
    }

    public void Refill()
    {
        fuel = 100;
        fuelLevelIndicator.color = fullTankColor;
    }

    private void DecreaseFuelLevel()
    {
        fuel--;
        if(fuel <= 0)
        {
            isEmpty = true;
            fuelLevelIndicator.color = emptyTankColor;
        }
    }
}
