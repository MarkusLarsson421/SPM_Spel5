using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//Martin Wallmark

/*
 * Anv�nds av LocalCo-opManager f�r att kunna hantera in-spawningen av spelare samt identifiera spelarna med varsit id och tag.
 */
public class PlayerSpawnManager : MonoBehaviour
{

    [SerializeField] private Transform playerOneSpawnPoint;
    [SerializeField] private Transform playerTwoSpawnPoint;
    [SerializeField] private PlayerInputManager playerInputManager;
    [SerializeField] private GameObject player1Prefab;
    [SerializeField] private GameObject player2Prefab;
    [SerializeField] private GameObject startCamera;
    [SerializeField] private GameObject startUIPicture;
    private float timer;
    public bool playerHasJoined = false;
    private bool player2hasjoined;
    private bool isEventSystemReset;

    private void Start()
    {
        playerInputManager.playerPrefab = player1Prefab;
    }

    private void Update()
    {
        if (player2hasjoined && !isEventSystemReset)
        {
            FixPlayerOneEventSystem();
        }
    }
    //Metoden anv�nds av inputsystemet f�r att spawna in en spelare n�r den tar emot input fr�n spelarens handkontroller/tangentbord
    public void OnPlayerJoined(PlayerInput playerInput)
    {
        Debug.Log("Player joined " + playerInput.playerIndex);

        playerInput.gameObject.GetComponent<PlayerStartInfo>().playerID = playerInput.playerIndex + 1;

        if(playerInput.gameObject.GetComponent<PlayerStartInfo>().playerID == 1)
        {
            Destroy(startCamera);
            Destroy(startUIPicture);
            playerInput.gameObject.GetComponent<PlayerStartInfo>().startPosition = playerOneSpawnPoint.position;
            playerInput.gameObject.tag = "Player1";
            playerInputManager.playerPrefab = player2Prefab;
        }
        else
        {
            playerInput.gameObject.GetComponent<PlayerStartInfo>().startPosition = playerTwoSpawnPoint.position;
            //playerInputManager.playerPrefab = player2Prefab;
            playerInput.gameObject.tag = "Player2";
            player2hasjoined = true;
            
        }
        SetPlayerSensitivity(playerInput);
        SetPauseManager(playerInput);
        playerHasJoined = true;
    }

    //Anpassar sensitivity baserat p� om spelaren har handkontroller eller mus
    private void SetPlayerSensitivity(PlayerInput playerInput)
    {
        if (playerInput.currentControlScheme == "Keyboard+mouse")
        {
            playerInput.gameObject.GetComponentInChildren<GamePadCamera>().SetSensitivity(20);
        }
        else if (playerInput.currentControlScheme == "Gamepad")
        {
            playerInput.gameObject.GetComponentInChildren<GamePadCamera>().SetSensitivity(150);
        }
    }


    private void SetPauseManager(PlayerInput playerInput)
    {
        //GameObject pauseManager = GameObject.FindGameObjectWithTag("PauseManager");
        
        //playerInput.gameObject.GetComponent<PlayerInput>().actions.FindAction("PauseGame").AddBinding(pauseManager.GetComponent<PauseGame>().ToString());
    }

    //Player1s evensystem st�ngs av och s�tts p� n�r player2 joinar. G�rs bara f�r att komma runt en bugg i unity
    private void FixPlayerOneEventSystem()
    {
        GameObject player1 = GameObject.FindGameObjectWithTag("Player1");
        GameObject eventSystem = player1.transform.Find("EventSystem").gameObject;
        eventSystem.SetActive(false);
        timer += Time.deltaTime;
        if(timer >= 0.2)
        {
            eventSystem.SetActive(true);
            isEventSystemReset = true;
        }
        
    }

}
