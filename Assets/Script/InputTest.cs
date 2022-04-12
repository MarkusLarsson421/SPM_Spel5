using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputTest : MonoBehaviour
{
    Gamepad gp;

    Vector2 move;

    void Awake()
    {
        gp = new Gamepad();
        gp.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        gp.Gameplay.Move.canceled += ctx => move = Vector2.zero;
    }

    void Update()
    {
        Vector2 m = new Vector2(-move.x, move.y) * Time.deltaTime;
        transform.Translate(m, Space.World);
    }

}
