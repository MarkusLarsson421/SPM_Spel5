using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestMovement : MonoBehaviour
{
    PlayerControls controls;
    Vector2 moveF;
    Vector2 moveB;
    Vector2 moveL;
    Vector2 moveR;

    private void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.MoveForward.performed += ctx => moveF = ctx.ReadValue<Vector2>();
        controls.Gameplay.MoveForward.canceled += ctx => moveF = Vector2.zero;
        /*controls.Gameplay.MoveForward.performed += ctx => moveB = ctx.ReadValue<Vector2>();
        controls.Gameplay.MoveForward.performed += ctx => moveL = ctx.ReadValue<Vector2>();
        controls.Gameplay.MoveForward.performed += ctx => moveR = ctx.ReadValue<Vector2>();*/
    }

    private void Update()
    {
        Vector2 mF = new Vector2(moveF.x, moveF.y) * Time.deltaTime;
        transform.Translate(mF, Space.World);
        /*Vector2 mB = new Vector2(moveB.x, moveF.y) * Time.deltaTime;
        transform.Translate(mB, Space.World);*/
    }
}
