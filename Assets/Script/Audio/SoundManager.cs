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
    //Snapshots
    public AudioMixerSnapshot intenseSnapshot; //bör göras om till [SerializedField] private
    public AudioMixerSnapshot normalSnapshot;

    //WorldSounds
    private AudioClip newWave;

    //PlayerSounds
    private AudioClip shootSound;
    private AudioClip meleeSound;
    private AudioClip reloadSound;
    //EnemySounds
    private AudioClip zombieDeathSound;
    private AudioClip zombieTakesDamageSound;
    //Player AudioSources
    private AudioSource shootSoundSource;
    private AudioSource meleeAttackSoundSource;
    private AudioSource reloadSoundSource;
    //Enemy AudioSources
    private AudioSource zombieDeathSource;
    private AudioSource zombieTakesDamageSoundSource;
    private AudioSource zombieRoarSoundSource; //AudioSourcen har ljudet på sig.
    //World AudioSources
    private AudioSource intenseMusic; 
    private AudioSource newWaveAudioSource;


    private float volLowRan = 0.3f;
    private float volHighRan = 1.0f;
    private float lowPitchRan = 0.3f;
    private float highPitchRan = 1.0f;
    private float minHumDelay = 5.0f;
    private float maxHumDelay = 25.0f;
    void Start()
    {
        //World Sources
        intenseMusic = GameObject.Find("IntenseMusic").GetComponent<AudioSource>();
        newWaveAudioSource = GameObject.Find("NewWaveAudioSource").GetComponent<AudioSource>();

        //Player sources
        shootSoundSource = GameObject.Find("ShootAudioSource").GetComponent<AudioSource>();
        reloadSoundSource = GameObject.Find("ReloadAudioSource").GetComponent<AudioSource>();
        meleeAttackSoundSource = GameObject.Find("MeleeAudioSource").GetComponent<AudioSource>();
        //Enemy sources
        zombieDeathSource = GameObject.Find("ZombieDeathAudioSource").GetComponent<AudioSource>();
        zombieRoarSoundSource = GameObject.Find("ZombieRoarAudioSource").GetComponent<AudioSource>();
        zombieTakesDamageSoundSource = GameObject.Find("ZombieTakesDamageAudioSource").GetComponent<AudioSource>();

        //PlayerSounds
        meleeSound = Resources.Load<AudioClip>("Swing");
        shootSound = Resources.Load<AudioClip>("GunShot");
        reloadSound = Resources.Load<AudioClip>("Reload");

        //EnemySounds
        zombieDeathSound = Resources.Load<AudioClip>("ZombieDies");
        zombieTakesDamageSound = Resources.Load<AudioClip>("BulletImpact");

        //WorldSounds
        newWave = Resources.Load<AudioClip>("NewWave");

        //ambienceDay.time = Random.Range(0, 60);
        //pianoMusic.time = Random.Range(0, 60);

        SoundPlaying("normalSnapshot");
    }
    void Update()
    {
       // RandomiseSoundPlayback();
    }

    public void SoundPlaying(string clip)
    { //hanterar vilket ljud som spelas. kallas på i andra scripts.

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
              ZombieDeathSound();
            Debug.Log("zombieDiedd");
        }
        if (clip == "zombieDamagedSound") //enemyAI
        {
            ZombieDamagedSound();
            Debug.Log("zombieTookDamage");
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
        if (clip == "newWave") //Generator
        {
            NewWave();
            Debug.Log("generator broke");
        }
    }
    private void GameOver()
    {
        normalSnapshot.TransitionTo(0.0f);
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
    private void ZombieDamagedSound()
    {
        float vol = Random.Range(volLowRan, volHighRan);
        zombieTakesDamageSoundSource.pitch = Random.Range(lowPitchRan, highPitchRan);
        zombieTakesDamageSoundSource.PlayOneShot(zombieTakesDamageSound, vol);
    }
    private void ReloadSound()
    {
        reloadSoundSource.pitch = Random.Range(0.6f, highPitchRan);
        reloadSoundSource.PlayOneShot(reloadSound);
    }
    private void NewWave()
    {
        newWaveAudioSource.pitch = Random.Range(0.6f, highPitchRan);
        newWaveAudioSource.PlayOneShot(newWave);
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
