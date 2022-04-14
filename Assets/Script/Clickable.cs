using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Clickable : MonoBehaviour
{
    public UnityEvent onInteract; //Vad som händer när man interagerar med något.
    public Sprite interactIcon; //vilken Ikon ska man ha på interaktionen.
    public Vector2 iconSize; // vilken storlek har ikonen.
    public int ID;
    // Start is called before the first frame update
    void Start()
    {
        ID = Random.Range(0, 99999);
    }

}
