using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
/*
     * 
     * @Author Simon Hessling Oscarson
     * Används i Weapon.
     * Används i enemyAI.
     * Används i maleeWeapon
     */
public class SoundManager : MonoBehaviour
{
    

    

    //PlayerSounds
    private  AudioClip shootSound;
    private AudioClip meleeSound;
    private AudioClip reloadSound;
    //EnemySounds
    public static AudioClip zombieDeathSound;

    

    //WorldSounds
    public AudioMixerSnapshot intenseSnapshot; //bör göras om till [SerializedField] private
    public AudioMixerSnapshot normalSnapshot;
    /*public AudioMixerSnapshot paused;
    public AudioMixerSnapshot gameOver;*/

    
    
    //Player AudioSources
    private AudioSource shootSoundSource;
    private AudioSource meleeAttackSoundSource;
    private AudioSource reloadSoundSource;

    //Enemy AudioSources
    private AudioSource zombieDeathSource;
    private AudioSource zombieRoarSoundSource;

    private AudioSource intenseMusic;

    private float volLowRan = 0.3f;
    private float volHighRan = 1.0f;
    private float lowPitchRan = 0.3f;
    private float highPitchRan = 1.0f;
    private float minHumDelay = 5.0f;
    private float maxHumDelay = 25.0f;
    void Start()
    {
        intenseMusic = GameObject.Find("IntenseMusic").GetComponent<AudioSource>();
        //AudioSources
        shootSoundSource = GameObject.Find("ShootAudioSource").GetComponent<AudioSource>();
        reloadSoundSource = GameObject.Find("ReloadAudioSource").GetComponent<AudioSource>();

        //zombieDeathSource;
        //meleeAttackSoundSource;
        //zombieRoarSoundSource;

        meleeSound = Resources.Load<AudioClip>("Swing");
        shootSound = Resources.Load<AudioClip>("BulletImpact");
        reloadSound = Resources.Load<AudioClip>("Reload");
        zombieDeathSound = Resources.Load<AudioClip>("ADD_SOUND_NAME");
         
         
         //ambienceDay.time = Random.Range(0, 60);
         //pianoMusic.time = Random.Range(0, 60);

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
            //paused.TransitionTo(0.0f);
            Debug.Log("DOESNTEXISTYET");
        }
        if (clip == "intenseSnapshot")
        {
            intenseSnapshot.TransitionTo(0.0f);
            if (!intenseMusic.isPlaying)
                intenseMusic.Play();
            Debug.Log("intenseMusic");
        }
        if (clip == "normalSnapshot")
        {
            normalSnapshot.TransitionTo(0.0f);
            intenseMusic.Stop();
            Debug.Log("normalMusic");
        }
        if (clip == "gameOver")
        {
            // GameOver();
            Debug.Log("DOESNTEXISTYET");
        }
        if (clip == "shootSound") //Weapon
        {
            Shoot();
        }
        if (clip == "reload") //Weapon
        {
            ReloadSound();
        }
        if (clip == "meleeAttack") //Weapon
        {
            MeleeAttackSound();
            Debug.Log("meleeAttackSounds");
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
    private void MeleeAttackSound()
    {
        meleeAttackSoundSource.pitch = Random.Range(0.6f, highPitchRan);//kanske ska ha samma pitch hela tiden?
        meleeAttackSoundSource.PlayOneShot(meleeSound);
    }
    private void ZombieDeathSound()
    {
        float vol = Random.Range(volLowRan, volHighRan);
        zombieDeathSource.pitch = Random.Range(lowPitchRan, highPitchRan);
        zombieDeathSource.PlayOneShot(zombieDeathSound, vol);
    }
    private void ReloadSound()
    {
        reloadSoundSource.pitch = Random.Range(0.6f, highPitchRan);
        reloadSoundSource.PlayOneShot(reloadSound);
    }

    private void RandomiseSoundPlayback()
    { //Gör att ett ljud körs random.
        if (!zombieRoarSoundSource.isPlaying)
        {
            zombieRoarSoundSource.pitch = Random.Range(lowPitchRan, highPitchRan);
            float t = Random.Range(minHumDelay, maxHumDelay);
            zombieRoarSoundSource.PlayDelayed(t);

        }
    }
    private void GeneratorTurnedOn()
    {

    }
    private void GeneratorBroke()
    {

    }

}
