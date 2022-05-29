using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator anim;

    public float transitionTime = 1f;
    public int sceneToIndex;

    public bool doTransitionOnStart = true;

    private void Start()
    {
        if (doTransitionOnStart)
        {
           anim.SetTrigger("Open");
        }
    }


    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        anim.SetTrigger("Close");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneToIndex);
    }

}
