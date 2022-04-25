using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawnManager : MonoBehaviour
{
   
    public void OnPlayerJoined(PlayerInput playerInput)
    {
        Debug.Log("Player joined " + playerInput.playerIndex);
    }
}
