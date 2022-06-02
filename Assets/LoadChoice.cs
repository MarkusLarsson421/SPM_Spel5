using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadChoice : MonoBehaviour
{
    [SerializeField] private bool isLoading;
    void Start()
    {
        DontDestroyOnLoad(gameObject); 
    }

    // Update is called once per frame
    public void setLoad(bool value)
    {
        isLoading = value;
    }

    public bool GetLoad()
    {
        return isLoading;
    }
}
