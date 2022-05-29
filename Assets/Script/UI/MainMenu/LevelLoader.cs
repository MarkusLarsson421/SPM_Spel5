using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
     * 
     * @Author Martin Nyman
     */

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Animator anim;

    [SerializeField] private float transitionTime = 1.5f;

    [SerializeField] private bool doTransitionOnStart = true;
    [SerializeField] private bool doTransitionOnEnd = true;

    private void Start()
    {
        if (doTransitionOnStart)
        {
           anim.SetTrigger("Open");
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
        }


        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneIndex);
    }

}
