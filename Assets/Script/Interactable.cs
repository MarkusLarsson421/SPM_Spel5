using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{

    //L�gg denna klass p� ett gameobjekt f�r att g�ra s� man kan interagera med det.
    //�ndra Layer mask till nr7 interactable.
    public UnityEvent onInteract; //Vad som h�nder n�r man interagerar med n�got.
    public Sprite interactIcon; //vilken Ikon ska man ha p� interaktionen.
    public Vector2 iconSize; // vilken storlek har ikonen.
    public int ID;
    // Start is called before the first frame update
    void Start()
    {
        ID = Random.Range(0, 99999);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
