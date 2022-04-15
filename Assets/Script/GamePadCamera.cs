using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//testscript för att få till handkontrollern
public class GamePadCamera : MonoBehaviour
{
    [SerializeField] private float sensitity;
    
    private InputSystem input;
    private Vector2 look;
    private float xRotation = 0f;

    private Transform player;
    // Start is called before the first frame update
    void Awake()
    {
        player = transform.parent;

        input = new InputSystem();

    }



    // Update is called once per frame
    void Update()
    {
        LookAround();
    }

    private void LookAround()
    {
        look = input.Gameplay.Rotate.ReadValue<Vector2>();

        float xAxis = look.x * sensitity * Time.deltaTime;
        float yAxis = look.y * sensitity * Time.deltaTime;

        xRotation -= yAxis;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        player.Rotate(Vector3.up * xAxis);
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }
}
