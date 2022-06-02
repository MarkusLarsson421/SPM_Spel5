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
    private SubsScript ss;
    private SubsScript ss2;
    [SerializeField] private GameObject player1Prefab;
    [SerializeField] private GameObject player2Prefab;
    [SerializeField] private GameObject startCamera;
    [SerializeField] private GameObject startUIPicture;

    [SerializeField] private float player1Rotation;
    [SerializeField] private float player2Rotation;
    [SerializeField] private PlayerSettings playerSettings;

    private float timer;
    public bool playerHasJoined = false;
    public bool player2hasjoined;
    private bool isEventSystemReset;

    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;

    [SerializeField] private Animator startUIAnimator;

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


        playerInput.gameObject.GetComponent<PlayerStartInfo>().SetPlayerID(playerInput.playerIndex + 1);

        if(playerInput.gameObject.GetComponent<PlayerStartInfo>().GetPlayerID() == 1)
        {
          
            ss = playerInput.gameObject.GetComponentInChildren<SubsScript>();
            DestroyStartImage();
            player1 = playerInput.gameObject;
            player1.GetComponent<PlayerStartInfo>().SetStartPosition(playerOneSpawnPoint.position);
            player1.GetComponent<PlayerStartInfo>().SetPlayerRotation(player1Rotation);
            player1.tag = "Player1";
            playerSettings.addRM(player1.GetComponentInChildren<ResourceManager>());
            playerInputManager.playerPrefab = player2Prefab;
            if (LevelLoader.isSceneLoaded)
            {
                playerSettings.SetPlayerOneRM();
            }
            
            if (ss != null)
            {
                //ss.FixCarLinePlay();
                ss.PlayInfoAboutStuff();
            }
            
            
        }
        else
        {
            ss2 = playerInput.gameObject.GetComponentInChildren<SubsScript>();
            player2 = playerInput.gameObject;
            player2.GetComponent<PlayerStartInfo>().SetStartPosition(playerTwoSpawnPoint.position);
            player2.GetComponent<PlayerStartInfo>().SetPlayerRotation(player2Rotation);
            player2.tag = "Player2";
            playerSettings.addRM2(player2.GetComponentInChildren<ResourceManager>());
            player2hasjoined = true;

            if (LevelLoader.isSceneLoaded)
            {
                playerSettings.SetPlayerTwoRM();
            }

            if (ss2 != null)
            {
                ss2.PlayInfoAboutStuff();
                //ss.PlayInfoAboutStuff();
            }
            
            

        }
        SetPlayerSensitivity(playerInput);
        
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

    private void DestroyStartImage()
    {
        Destroy(startCamera);
        startUIAnimator.SetTrigger("FadeOut");
    }

    public GameObject GetPlayer1()
    {
        return player1;
    }

    public GameObject GetPlayer2()
    {
        return player2;
    }

}
