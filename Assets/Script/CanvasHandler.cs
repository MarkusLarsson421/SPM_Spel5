using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CanvasHandler : MonoBehaviour // @Khaled Alraas
{
    [SerializeField] private Button tryAgainButton;
    [SerializeField] private Button ExitToMaiinMenuButton;
    [SerializeField] private GameObject CanvasObject;
    [SerializeField] private GameObject deathCanvasObject;
    [SerializeField] private int sceneToIndex;
    //[SerializeField] private GameObject player;
    static private int MainMenusceneToIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.None; //varför finns detta i canvas handler?
        tryAgainButton.onClick.AddListener(ReastartLevel);
        ExitToMaiinMenuButton.onClick.AddListener(GoTOMainMenu);
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
        SceneManager.LoadScene(MainMenusceneToIndex);
    }
    void ChangeCanvasToDeathCanvas() //khaled
    {
        CanvasObject.SetActive(false);
        deathCanvasObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
}
