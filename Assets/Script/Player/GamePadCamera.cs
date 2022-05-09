using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//testscript för att få till handkontrollern
//Martin Wallmark
public class GamePadCamera : MonoBehaviour
{
    [SerializeField] private float sensitity;
    
    private InputSystem input;
    private Vector2 look;
    private float xRotation = 0f;

    private float xAxis;
    private float yAxis;
    private float smallRotationInput = 0.15f;

    private Transform player;
    // Start is called before the first frame update
    void Awake()
    {
        player = transform.parent;
        if (transform.parent.tag.Equals("Player1"))
        {
            //GetComponent<Camera>().rect = new Rect(0f, 0.5f, 1f, 0.5f);
        }
        else if(transform.parent.tag.Equals("Player2"))
        {
            //transform.position = new Vector2(0, -1);
            GameObject.FindWithTag("Player1").GetComponentInChildren<Camera>().rect = new Rect(0f, 0.5f, 1f, 0.5f);
            GetComponent<Camera>().rect = new Rect(0f, 0f, 1f, 0.5f);
        }

        input = new InputSystem();

    }

    public void OnRotate(InputAction.CallbackContext callback)
    {
        look = callback.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        LookAround();
    }

    private void LookAround()
    {
        //look = input.Gameplay.Rotate.ReadValue<Vector2>();
        if(look.magnitude > smallRotationInput)
        {
            xAxis = look.x * sensitity * Time.deltaTime;
            yAxis = look.y * sensitity * Time.deltaTime;
        }
       
        else
        {
            xAxis = 0 * sensitity * Time.deltaTime;
            yAxis = 0 * sensitity * Time.deltaTime;
        }


        xRotation -= yAxis;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        player.Rotate(Vector3.up * xAxis);
    }

    public void SetSensitivity(float nSensitivty)
    {
        sensitity = nSensitivty;
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
