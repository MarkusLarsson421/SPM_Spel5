using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class LevelLoaderV2 : MonoBehaviour
{
    public static LevelLoaderV2 Instance;
    [SerializeField]private GameObject _loaderCanvas;
    [SerializeField] private Image _progressBar;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    public async void LoadScene(string sceneName)
    {
        var scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;
        _loaderCanvas.SetActive(true);
        do
        {
            await Task.Delay(100);
            _progressBar.fillAmount = scene.progress;
        } while (scene.progress < 0.9f);
        scene.allowSceneActivation = true;
        _loaderCanvas.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
