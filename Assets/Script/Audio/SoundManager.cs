using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SoundManager : MonoBehaviour
{
    /*
     * 
     * @Author Simon Hessling Oscarson
     * Används i Weapon.
     * Används i enemyAI.
     * 
     */

    //Counter counter;
    public static AudioClip shootSound;
    public static AudioClip zombieDeathSound;

    //  public static AudioClip balloonPopSound;*/

    private static AudioSource audioSrc;

    public AudioMixerSnapshot intenseSnapshot; //bör göras om till [SerializedField] private
    public AudioMixerSnapshot normalSnapshot;
    /*public AudioMixerSnapshot paused;
    public AudioMixerSnapshot gameOver;*/
    
    public AudioSource zombieRoar;
    //public AudioSource ambienceDay;
    //public AudioSource pianoMusic;
    
    public AudioSource[] triggerSounds;

    private AudioSource shootSoundSource;
    private AudioSource zombieDeathSource;
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

       /* zombieDeathSound = Resources.Load<AudioClip>("ADD_SOUND_NAME");

        shootSound = Resources.Load<AudioClip>("ADD_SOUND_NAME");
        //balloonPopSound = Resources.Load<AudioClip>("Balloon Pop Sound");

        audioSrc = GetComponent<AudioSource>();

        shootSoundSource = triggerSounds[0];
        zombieDeathSource = triggerSounds[1];
        balloonPop = triggerSounds[2];
        
        ambienceDay.time = Random.Range(0, 60);
        pianoMusic.time = Random.Range(0, 60);
        
        SoundPlaying("normalSnapshot");*/
    }
    void Update()
    {
        //RandomiseSoundPlayback();
    }

    public void SoundPlaying(string clip)
    { //hanterar vilket ljud som spelas. kallas på i andra scripts.
        if (clip == "paused")
        {
            //paused.TransitionTo(0.0f);
            Debug.Log("DOESNTEXISTYET");
        }
        if (clip == "intenseSnapshot")
        {
            //intenseSnapshot.TransitionTo(0.0f);
            Debug.Log("intenseMusic");
        }
        if (clip == "normalSnapshot")
        {
            //normalSnapshot.TransitionTo(0.0f);
            Debug.Log("normalMusic");
        }
        if (clip == "gameOver")
        {
            // GameOver();
            Debug.Log("DOESNTEXISTYET");
        }
        if (clip == "shootSound") //Weapon
        {
            // Shoot();
            Debug.Log("shootSound");
        }
        if (clip == "zombieDeathSound") //enemyAI
        {
            //  ZombieDeathSound();
            Debug.Log("zombieDiedd");
        }
        if (clip == "generatorTurnedOn") //Generator
        {
            //  GeneratorTurnedOn();
            Debug.Log("generator turned on");
        }
        if (clip == "generatorBroke") //Generator
        {
            //  GeneratorBroke();
            Debug.Log("generator broke");
        }
    }
    private void GameOver()
    {
        normalSnapshot.TransitionTo(0.0f);
        //balloonPop.pitch = (counter.GetTimePassed() / 10);
        // balloonPop.PlayOneShot(balloonPopSound);
        //  gameOver.TransitionTo(0.0f);
    }
    private void Shoot()
    {
        shootSoundSource.pitch = Random.Range(0.6f, highPitchRan);//kanske ska ha samma pitch hela tiden?
        shootSoundSource.PlayOneShot(shootSound);
    }
    private void ZombieDeathSound()
    {
        float vol = Random.Range(volLowRan, volHighRan);
        zombieDeathSource.pitch = Random.Range(lowPitchRan, highPitchRan);
        zombieDeathSource.PlayOneShot(zombieDeathSound, vol);
    }

    private void RandomiseSoundPlayback()
    { //Gör att ett ljud körs random.
        if (!zombieRoar.isPlaying)
        {
            zombieRoar.pitch = Random.Range(lowPitchRan, highPitchRan);
            float t = Random.Range(minHumDelay, maxHumDelay);
            zombieRoar.PlayDelayed(t);
        }
    }
    private void GeneratorTurnedOn()
    {

    }
    private void GeneratorBroke()
    {

    }

}
