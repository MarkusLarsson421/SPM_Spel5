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

    
    //Metoden används av inputsystemet för att spawna in en spelare när den tar emot input från spelarens handkontroller/tangentbord
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
        SetPlayerSensitivity(playerInput);
        SetPauseManager(playerInput);
        
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


    private void SetPauseManager(PlayerInput playerInput)
    {
        //GameObject pauseManager = GameObject.FindGameObjectWithTag("PauseManager");
        
        //playerInput.gameObject.GetComponent<PlayerInput>().actions.FindAction("PauseGame").AddBinding(pauseManager.GetComponent<PauseGame>().ToString());
    }
}
