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
    private AudioClip generatorOnSound;
    private AudioClip generatorOffSound;
    private AudioClip subtitlesSound;
    private AudioClip doorToggleSound;
    //PlayerSounds
    private AudioClip shootSound;
    private AudioClip meleeSound;
    private AudioClip reloadSound;
    private AudioClip pickUpSound;


    //EnemySounds
    private AudioClip zombieDeathSound;
    private AudioClip zombieTakesDamageSound;
    private AudioClip headshotSound;
    private AudioClip headshotSound2;

    //Player AudioSources
    private AudioSource shootSoundSource;
    private AudioSource meleeAttackSoundSource;
    private AudioSource reloadSoundSource;
    private AudioSource pickUpSoundSource;
    private AudioSource subtitlesSoundSource;
    private AudioSource danHitSoundSource;
    private AudioSource kateHitSoundSource;


    //Enemy AudioSources
    private AudioSource zombieDeathSource;
    private AudioSource zombieTakesDamageSoundSource;
    private AudioSource zombieRoarSoundSource; //AudioSourcen har ljudet på sig.
    //World AudioSources
    private AudioSource intenseMusic; 
    
    private AudioSource newWaveAudioSource;
    private AudioSource generatorSource;
    private AudioSource generatorSourceOn;
    private AudioSource doorToggleSource;


    private float volLowRan = 0.3f;
    private float volHighRan = 1.0f;
    private float lowPitchRan = 0.3f;
    private float highPitchRan = 1.0f;
    private float minHumDelay = 25.0f;
    private float maxHumDelay = 200.0f;

    [SerializeField] private AudioClip[] danHitSounds;
    [SerializeField] private AudioClip[] kateHitSounds;

    void Start()
    {
        //World Sources
        intenseMusic = GameObject.Find("IntenseMusic").GetComponent<AudioSource>();
        newWaveAudioSource = GameObject.Find("NewWaveAudioSource").GetComponent<AudioSource>();
        generatorSource = GameObject.Find("GeneratorAudioSource").GetComponent<AudioSource>();
        generatorSourceOn = GameObject.Find("GeneratorOnAudioSource").GetComponent<AudioSource>();
        subtitlesSoundSource = GameObject.Find("SubtitlesAudioSource").GetComponent<AudioSource>();
        doorToggleSource = GameObject.Find("DoorToggleAudioSource").GetComponent<AudioSource>();

        //Player sources
        shootSoundSource = GameObject.Find("ShootAudioSource").GetComponent<AudioSource>();
        reloadSoundSource = GameObject.Find("ReloadAudioSource").GetComponent<AudioSource>();
        meleeAttackSoundSource = GameObject.Find("MeleeAudioSource").GetComponent<AudioSource>();
        pickUpSoundSource = GameObject.Find("PickUpSoundSource").GetComponent<AudioSource>();
        danHitSoundSource = GameObject.Find("DanHitAudioSource").GetComponent<AudioSource>();
        kateHitSoundSource = GameObject.Find("KateHitAudioSource").GetComponent<AudioSource>();


        //Enemy sources
        zombieDeathSource = GameObject.Find("ZombieDeathAudioSource").GetComponent<AudioSource>();
        zombieRoarSoundSource = GameObject.Find("ZombieRoarAudioSource").GetComponent<AudioSource>();
        zombieTakesDamageSoundSource = GameObject.Find("ZombieTakesDamageAudioSource").GetComponent<AudioSource>();

        //PlayerSounds
        meleeSound = Resources.Load<AudioClip>("Swing");
        shootSound = Resources.Load<AudioClip>("GunShot");
        reloadSound = Resources.Load<AudioClip>("Reload");
        pickUpSound = Resources.Load<AudioClip>("PickUp");
        subtitlesSound = Resources.Load<AudioClip>("Subtitles");
        //EnemySounds
        zombieDeathSound = Resources.Load<AudioClip>("ZombieDies");
        zombieTakesDamageSound = Resources.Load<AudioClip>("BulletImpact");
        headshotSound = Resources.Load<AudioClip>("headshotSound");
        headshotSound2 = Resources.Load<AudioClip>("headshotSound2");
        //WorldSounds
        newWave = Resources.Load<AudioClip>("NewWave");
        generatorOnSound = Resources.Load<AudioClip>("GeneratorOn");
        generatorOffSound = Resources.Load<AudioClip>("GeneratorOff");
        doorToggleSound = Resources.Load<AudioClip>("DoorToggle");
        
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
            //Debug.Log("normalMusic");
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
        if (clip == "pickUp") //Interactor
        {
            PickUp();
        }
        if (clip == "subtitlesSound") //SubsScript
        {
            Subtitles();
        }
        if (clip == "zombieDeathSound") //enemyAI
        {
              ZombieDeathSound();
            Debug.Log("zombieDiedd");
        }
        if (clip == "zombieDamagedSound") //enemyAI
        {
            ZombieDamagedSound();
        }
        if (clip == "headshotSound") //enemyAI
        {
            ZombieHeadshotSound();
        }
        if (clip == "generatorOn") //Generator
        {
              GeneratorTurnedOn();
            Debug.Log("generator turned on");
        }
        if (clip == "generatorOff") //Generator
        {
            GeneratorBroke();
            Debug.Log("generator broke");
        }
        if (clip == "newWave") //Generator
        {
            NewWave();
        }
        if(clip == "danHit") //Dan take damage
        {
            RandomClip(danHitSounds, danHitSoundSource);
            DanHitSound();
        }
        if(clip == "kateHit") //Kate take damage
        {
            RandomClip(kateHitSounds, kateHitSoundSource);
            KateHitSound();
        }
        if (clip == "toggleDoor") //Doors
        {
            ToggleDoorSound();
        }

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
    private void PickUp()
    {
        pickUpSoundSource.pitch = Random.Range(0.8f, highPitchRan);//kanske ska ha samma pitch hela tiden?
        pickUpSoundSource.PlayOneShot(pickUpSound);
    }

    private void Subtitles()
    {
        subtitlesSoundSource.pitch = Random.Range(0.8f, highPitchRan);//kanske ska ha samma pitch hela tiden?
        subtitlesSoundSource.PlayOneShot(subtitlesSound);
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
    private void ZombieHeadshotSound()
    {
        float vol = Random.Range(volLowRan, volHighRan);
        zombieTakesDamageSoundSource.pitch = Random.Range(0.8f, 1.2f);
        zombieTakesDamageSoundSource.PlayOneShot(headshotSound, vol);
        

    }
    private void ReloadSound()
    {
        reloadSoundSource.pitch = Random.Range(0.6f, highPitchRan);
        reloadSoundSource.PlayOneShot(reloadSound);
    }
    private void NewWave()
    {
        newWaveAudioSource.pitch = Random.Range(0.8f, highPitchRan);
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
        generatorSourceOn.pitch = Random.Range(0.8f, highPitchRan);
        generatorSourceOn.PlayOneShot(generatorOnSound);
    }
    private void GeneratorBroke()
    {
        generatorSource.pitch = Random.Range(0.8f, highPitchRan);
        generatorSource.time = 4;
        generatorSource.PlayOneShot(generatorOffSound);
    }

    private void DanHitSound()
    {
        danHitSoundSource.pitch = Random.Range(0.8f, highPitchRan);
        danHitSoundSource.PlayOneShot(danHitSoundSource.clip);
    }

    private void KateHitSound()
    {
        kateHitSoundSource.pitch = Random.Range(0.8f, highPitchRan);
        kateHitSoundSource.PlayOneShot(kateHitSoundSource.clip);
    }

    private void ToggleDoorSound()
    {
        if (!doorToggleSource.isPlaying)
        {
            doorToggleSource.pitch = Random.Range(0.8f, highPitchRan);
            doorToggleSource.PlayOneShot(doorToggleSound);
        }
    }

    //Nyman
    //Returns random clip and make sure the same clip does not repeat
    private void RandomClip(AudioClip[] sounds, AudioSource source)
    {
        int randomIndex = Random.Range(0, sounds.Length);
        if (source.clip == sounds[randomIndex])
        {
            RandomClip(sounds, source);
        }
        source.clip = sounds[randomIndex];
    }

}
