using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//Martin Wallmark
public class PlayerSpawnManager : MonoBehaviour
{

    [SerializeField] private Transform playerOneSpawnPoint;
    [SerializeField] private Transform playerTwoSpawnPoint;
    [SerializeField] private PlayerInputManager playerInputManager;

    /*
    private void Awake()
    {
        playerInputManager.JoinPlayer();
        playerInputManager.JoinPlayer();
    }
    */
    

    public void OnPlayerJoined(PlayerInput playerInput)
    {
        Debug.Log("Player joined " + playerInput.playerIndex);

        playerInput.gameObject.GetComponent<PlayerStartInfo>().playerID = playerInput.playerIndex + 1;

        if(playerInput.gameObject.GetComponent<PlayerStartInfo>().playerID == 1)
        {
            playerInput.gameObject.GetComponent<PlayerStartInfo>().startPosition = playerOneSpawnPoint.position;
            playerInput.gameObject.tag = "Player1";


        }
        else
        {
            playerInput.gameObject.GetComponent<PlayerStartInfo>().startPosition = playerTwoSpawnPoint.position;
            playerInput.gameObject.tag = "Player2";
        }

        
    }
}
