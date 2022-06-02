using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

/*
     * 
     * @Author Martin Nyman
     * Loads level and play Scenetransitions
     */

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Animator anim;

    [SerializeField] private float transitionTime = 1.5f;

    [SerializeField] private bool doTransitionOnStart = true;
    [SerializeField] private bool doTransitionOnEnd = true;
    private AudioSource audioSource;
    [SerializeField] private AudioClip doorTransitionOpenSound;
    [SerializeField] private AudioClip doorTransitionCloseSound;
    [SerializeField] private SaveSystem saveSystem;
    [SerializeField] private LoadChoice loader;
    public static bool isSceneLoaded;


    private void Awake()
    {
        GameObject.Find("Loader").GetComponent<LoadChoice>();
        audioSource = GetComponent<AudioSource>();
        if (doTransitionOnStart)
        {
           anim.SetTrigger("Open");
           RandomizePitch();
           audioSource.PlayOneShot(doorTransitionOpenSound);
        }

    }


    public void LoadNextLevel(string sceneToLoad)
    {
        StartCoroutine(LoadLevel(sceneToLoad));
    }

    IEnumerator LoadLevel(string sceneIndex)
    {
        if (doTransitionOnEnd)
        {
            anim.SetTrigger("Close");
            RandomizePitch();
            audioSource.PlayOneShot(doorTransitionCloseSound);
        }


        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneIndex);
    }

    private void RandomizePitch()
    {
        audioSource.pitch = audioSource.pitch = Random.Range(0.8f, 1f);
    }

    public void LoadSavedLevel()
    {
        isSceneLoaded = true;
        //loader.setLoad(true);
        SceneManager.LoadScene("Level1");
        
    }


}
