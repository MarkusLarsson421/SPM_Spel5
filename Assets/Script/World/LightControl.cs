using System;
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
        if (isOn && isRunning == false)
        {
            isRunning = true;
            StartCoroutine(Blink());
        }

        if (isOn == false && isRunning)
        {
	        isRunning = false;
	        StopCoroutine(Blink());
        }
    }

    public void Toggle()
    {
        isOn = !isOn;
    }

    private IEnumerator Blink()
    {
	    SetLightState(true);
	    
        yield return new WaitForSeconds(2.0f);
        
        SetLightState(false);
    }

    private void SetLightState(bool setState)
    {
	    foreach(GameObject go in lights)
	    {
		    go.gameObject.transform.GetChild(0).gameObject.SetActive(setState);
	    }
    }
}
