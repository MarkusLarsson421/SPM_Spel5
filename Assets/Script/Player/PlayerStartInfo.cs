using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Martin Wallmark
/*
 * Används för att ange en spawnposition för spelare 1 och spelare 2
 */
public class PlayerStartInfo : MonoBehaviour
{
    private int playerID;
    private float playerRotation;
    
    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPosition;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + playerRotation,transform.eulerAngles.z);
    }

    public int GetPlayerID()
    {
        return playerID;
    }

    public void SetPlayerID(int nPlayerID)
    {
        playerID = nPlayerID;
    }

    public void SetStartPosition(Vector3 nStartPosition)
    {
        startPosition = nStartPosition;
    }

    public void SetPlayerRotation(float rotation)
    {
        playerRotation = rotation;
    }


}
