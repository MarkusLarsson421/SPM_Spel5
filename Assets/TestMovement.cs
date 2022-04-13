using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    [SerializeField] InputSystem input;
    [SerializeField] Vector3 move;
    [SerializeField] Vector3 rotate;

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
        Vector3 m = new Vector3(move.x,0f,move.y).normalized * Time.deltaTime;
        transform.Translate(m, Space.Self);

        Vector3 r = new Vector3(0f , rotate.y, 0f).normalized * 100 * Time.deltaTime;
        transform.Rotate(r, Space.Self);

        //transform.Rotate(r.x, 0.0f, r.z);

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

