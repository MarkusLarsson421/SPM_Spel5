using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Martin Wallmark
/*
 * Anv�nds f�r att ange en spawnposition f�r spelare 1 och spelare 2
 */
public class PlayerStartInfo : MonoBehaviour
{
    public int playerID;
    
    public Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPosition;
    }
}
