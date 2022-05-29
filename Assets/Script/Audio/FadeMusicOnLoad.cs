using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

//Nyman

public class FadeMusicOnLoad : MonoBehaviour
{

    private AudioSource audioSource;
    [SerializeField] private AudioMixerSnapshot fadeInSnapShot;
    [SerializeField] private AudioMixerSnapshot fadeOutSnapShot;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        FadeMusicIn();
    }


    public void FadeMusicIn()
    {
        fadeInSnapShot.TransitionTo(1.5f);
    }

    public void FadeMusicOut()
    {
        fadeOutSnapShot.TransitionTo(1.5f);
    }

}
