using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SoundManager : MonoBehaviour
{
    //Counter counter;
/*
    public static AudioClip pointSound;
    public static AudioClip swooshSound;
    public static AudioClip balloonPopSound;

    private static AudioSource audioSrc;

    public AudioMixerSnapshot intenseSnapshot; //bör göras om till [SerializedField] private
    public AudioMixerSnapshot normalSnapshot;
    public AudioMixerSnapshot paused;
    public AudioMixerSnapshot gameOver;

    public AudioSource birdHum;
    public AudioSource ambienceDay;
    public AudioSource pianoMusic;

    public AudioSource[] triggerSounds;

    private AudioSource swoosh;
    private AudioSource pointSoundSource;
    private AudioSource balloonPop;

    private float volLowRan = 0.3f;
    private float volHighRan = 1.0f;
    private float lowPitchRan = 0.3f;
    private float highPitchRan = 1.0f;
    private float minHumDelay = 5.0f;
    private float maxHumDelay = 25.0f;
    void Start()
    {
       // counter = GameObject.Find("CO").GetComponent<Counter>();

        pointSound = Resources.Load<AudioClip>("PointSound");
        swooshSound = Resources.Load<AudioClip>("Ghost Swish");
        balloonPopSound = Resources.Load<AudioClip>("Balloon Pop Sound");

        audioSrc = GetComponent<AudioSource>();

        swoosh = triggerSounds[0];
        pointSoundSource = triggerSounds[1];
        balloonPop = triggerSounds[2];

        ambienceDay.time = Random.Range(0, 60);
        pianoMusic.time = Random.Range(0, 60);

        SoundPlaying("normalSnapshot");
    }
    void Update()
    {
        RandomiseSoundPlayback();
    }

    public void SoundPlaying(string clip)
    { //hanterar vilket ljud som spelas. kallas på i andra scripts.
        if (clip == "paused")
        {
            paused.TransitionTo(0.0f);
        }
        if (clip == "intenseSnapshot")
        {
            intenseSnapshot.TransitionTo(0.0f);
        }
        if (clip == "normalSnapshot")
        {
            normalSnapshot.TransitionTo(0.0f);
        }
        if (clip == "gameOver")
        {
            GameOver();
        }
        if (clip == "swoosh")
        {
            Swoosh();
        }
        if (clip == "pointSound")
        {
            PointSound();
        }
    }
    private void GameOver()
    {
        //balloonPop.pitch = (counter.GetTimePassed() / 10);
        balloonPop.PlayOneShot(balloonPopSound);
        gameOver.TransitionTo(0.0f);
    }
    private void Swoosh()
    {
        swoosh.pitch = Random.Range(0.6f, highPitchRan);
        swoosh.PlayOneShot(swooshSound);
    }
    private void PointSound()
    {
        float vol = Random.Range(volLowRan, volHighRan);
        pointSoundSource.pitch = Random.Range(lowPitchRan, highPitchRan);
        pointSoundSource.PlayOneShot(pointSound, vol);
    }

    private void RandomiseSoundPlayback()
    { //Gör att ett ljud körs random.
        if (!birdHum.isPlaying)
        {
            birdHum.pitch = Random.Range(lowPitchRan, highPitchRan);
            float t = Random.Range(minHumDelay, maxHumDelay);
            birdHum.PlayDelayed(t);
        }
    }
*/
}
