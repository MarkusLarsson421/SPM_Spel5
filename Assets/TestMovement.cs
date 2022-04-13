using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    InputSystem input;
    Vector2 move;
    Vector2 rotate;

    void Awake()
    {
        input = new InputSystem();

        input.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        input.Gameplay.Rotate.performed += ctx => rotate = ctx.ReadValue<Vector2>();

        input.Gameplay.Move.canceled += ctx => move = Vector2.zero;
        input.Gameplay.Rotate.canceled += ctx => rotate = Vector2.zero;
    }

    private void Update()
    {
        Vector3 m = new Vector3(move.x,0f,move.y) * Time.deltaTime;
        transform.Translate(m, Space.World);

        Vector3 r = new Vector3(rotate.x,0f) * 100f * Time.deltaTime;
        transform.Rotate(r, Space.World);
    }

    private void OnEnable()
    {
        input.Gameplay.Enable();
    }

    private void OnDisable()
    {
        input.Gameplay.Disable();
    }
}

