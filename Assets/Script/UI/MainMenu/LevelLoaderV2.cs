using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class LevelLoaderV2 : MonoBehaviour
{
    //public static LevelLoaderV2 Instance;
    //[SerializeField]private GameObject _loaderCanvas;
    //[SerializeField] private Image _progressBar;

    //public Animator anim;
    //public float transitionTime = 1f;
    //public bool doTransitionOnStart = true;

    //private void Awake()
    //{
    //    if (Instance == null)
    //    {
    //        Instance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }

    //}
    //void Start()
    //{
    //    if (doTransitionOnStart)
    //    {
    //        anim.SetTrigger("StartTransition");
    //    }
    //}

    //public async void LoadScene(string sceneName)
    //{
    //    Debug.Log(sceneName);

    //    var scene = SceneManager.LoadSceneAsync(sceneName);
    //    scene.allowSceneActivation = false;
    //    _loaderCanvas.SetActive(true);
    //    do
    //    {
    //        await Task.Delay(1000);
    //        _progressBar.fillAmount = scene.progress;
    //    } while (scene.progress < 0.9f);
    //    scene.allowSceneActivation = true;
    //    _loaderCanvas.SetActive(false);
    //}
    //public void LoadNextLevel()
    //{
    //    StartCoroutine(LoadLevel());
    //}

    //IEnumerator LoadLevel()
    //{
    //    anim.SetTrigger("EndTransition");

    //    yield return new WaitForSeconds(transitionTime);
    //}
}
