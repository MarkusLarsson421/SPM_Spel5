using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Nyman

public class UIAudio : MonoBehaviour
{
    [SerializeField] AudioClip[] buttonSounds;
    [SerializeField] private AudioSource audioSource;
    private int lastIndex = 69;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    //Plays random sound from list of buttonsounds
    public void PlayButtonSound()
    {
        RandomizePitch();
        audioSource.PlayOneShot(RandomClip(buttonSounds));
    }

    //Returns random clip and make sure the same clip does not repeat
    private AudioClip RandomClip(AudioClip[] buttonSounds)
    {
        int randomIndex = Random.Range(0,buttonSounds.Length);
        if(buttonSounds.Length > 1 && lastIndex == randomIndex)
        {
            RandomClip(buttonSounds);
        }
        return buttonSounds[randomIndex];
    }

    private void RandomizePitch()
    {
        audioSource.pitch = Random.Range(0.8f, 1f);
    }

}
