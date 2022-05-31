using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//Martin Wallmark

/*
 * Används av LocalCo-opManager för att kunna hantera in-spawningen av spelare samt identifiera spelarna med varsit id och tag.
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

    private float timer;
    public bool playerHasJoined = false;
    private bool player2hasjoined;
    private bool isEventSystemReset;

    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;

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
    //Metoden används av inputsystemet för att spawna in en spelare när den tar emot input från spelarens handkontroller/tangentbord
    public void OnPlayerJoined(PlayerInput playerInput)
    {
        Debug.Log("Player joined " + playerInput.playerIndex);

        playerInput.gameObject.GetComponent<PlayerStartInfo>().SetPlayerID(playerInput.playerIndex + 1);

        if(playerInput.gameObject.GetComponent<PlayerStartInfo>().GetPlayerID() == 1)
        {

            ss = playerInput.gameObject.GetComponentInChildren<SubsScript>();
            DestroyStartImage();
            player1 = playerInput.gameObject;
            player1.GetComponent<PlayerStartInfo>().SetStartPosition(playerOneSpawnPoint.position);
            player1.GetComponent<PlayerStartInfo>().SetPlayerRotation(player1Rotation);
            player1.tag = "Player1";
            playerInputManager.playerPrefab = player2Prefab;
            
            if (ss != null)
            {
                ss.FixCarLinePlay();
            }
            
            
        }
        else
        {
            ss2 = playerInput.gameObject.GetComponentInChildren<SubsScript>();
            player2 = playerInput.gameObject;
            player2.GetComponent<PlayerStartInfo>().SetStartPosition(playerTwoSpawnPoint.position);
            player2.GetComponent<PlayerStartInfo>().SetPlayerRotation(player2Rotation);
            player2.tag = "Player2";
            player2hasjoined = true;
            
            if (ss2 != null)
            {
                ss2.FixCarLinePlay();
            }
            
            ss.FixCarLinePlay();

        }
        SetPlayerSensitivity(playerInput);
        
        playerHasJoined = true;
    }

    //Anpassar sensitivity baserat på om spelaren har handkontroller eller mus
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

    //Player1s evensystem stängs av och sätts på när player2 joinar. Görs bara för att komma runt en bugg i unity
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
        Destroy(startUIPicture);
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
