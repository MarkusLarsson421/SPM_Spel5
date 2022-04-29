using System.Collections;
using UnityEngine;

public class LightControl : MonoBehaviour
{
    [SerializeField] private GameObject[] lights;
    [SerializeField] private bool isOn;
    [SerializeField] private bool isBlinking = false;
    [SerializeField] private float blinkInterval = 5.0f;
    [SerializeField] private float blinkLength = 5.0f;
    
    [SerializeField] private bool isRunning = false;

    private void Update()
    {
        if (isOn && isRunning)
        {
            isRunning = true;
            StartCoroutine(Blink());
        }
    }

    public void Toggle()
    {
        isOn = !isOn;
    }

    private static IEnumerator Blink()
    {
        yield return new WaitForSeconds(2.0f);
    }
}
