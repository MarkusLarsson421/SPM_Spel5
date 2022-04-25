using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CanvasHandler : MonoBehaviour // @Khaled Alraas
{
    [SerializeField] private Button tryAgainButton;
    [SerializeField] private Button LoseExitToMainMenuButton;
    [SerializeField] private Button RestartButton;
    [SerializeField] private Button WinExitToMainMenuButton;
    [SerializeField] private GameObject CanvasObject;
    [SerializeField] private GameObject deathCanvasObject;
    [SerializeField] private int sceneToIndex;
    static private int MainMenuSceneIsIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.None; //varför finns detta i canvas handler?
        tryAgainButton.onClick.AddListener(ReastartLevel);
        LoseExitToMainMenuButton.onClick.AddListener(GoTOMainMenu);
        RestartButton.onClick.AddListener(ReastartLevel);
        WinExitToMainMenuButton.onClick.AddListener(GoTOMainMenu);
    }
    GameObject player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        
        if (player.GetComponent<PlayerStats>().getHealth() <= 0)
        {
            ChangeCanvasToDeathCanvas();
        }
        
    }
    void ReastartLevel()
    {
        Debug.Log("You have clicked the tryAgainButton!");
        SceneManager.LoadScene(sceneToIndex);
    }
    void GoTOMainMenu()
    {
        Debug.Log("You have clicked the ExitToMaiinMenuButton!");
        SceneManager.LoadScene(MainMenuSceneIsIndex);
    }
    void ChangeCanvasToDeathCanvas() //khaled
    {
        CanvasObject.SetActive(false);
        deathCanvasObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
}
