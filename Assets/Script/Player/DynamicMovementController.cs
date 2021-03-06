using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//Martin Wallmark
public class DynamicMovementController : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] private float speed;
    [SerializeField] private float initialMaxSpeed;
    [SerializeField] private float sprintMaxSpeed;
    [SerializeField] private float staticFrictionCoefficient;
    [SerializeField] private float kineticFloatCoefficent;
    
    [SerializeField] private LayerMask collisionMask;
    [SerializeField] private Animator anim;
    
    private InputSystem controls;
    private CapsuleCollider collider;
    private PlayerStats stats;
    private Vector2 move;
    private Vector3 velocity;

    private float maxSpeed;
    private float acceleration = 2f;
    private float deceleration = 1f;
    private float gravity = 15f;
    private float timer;
    private float collisionMargin = 0.2f;
    private float groundCheckDistance = 0.3f;
    private float smallInput = 0.5f;
    
    private bool isSprinting;

    

    public void OnMove(InputAction.CallbackContext callback)
    {
        move = callback.ReadValue<Vector2>();
        
    }

    public void OnSprint(InputAction.CallbackContext callback)
    {
        
        if (callback.performed)
        {
            
            if (stats.getStamina() >= 0)
            {
                isSprinting = true;
            }
            
        }

        if (callback.canceled)
        {
            isSprinting = false;
            maxSpeed = 5;
;       }
    }
    void Awake()
    {
        controls = new InputSystem();
        collider = GetComponent<CapsuleCollider>();
        Cursor.lockState = CursorLockMode.Locked;
        stats = gameObject.GetComponent<PlayerStats>();
        maxSpeed = initialMaxSpeed;
    }

    void Update()
    {
        
        
        if (IsGrounded())
        {
            Movement();
        }
        UpdateVelocity();
        ForceDown();
        
        handleSprint(isSprinting);

        if (isSprinting)
        {
            MaxSpeedHandler();
        }
        
        //Open door
        if (Input.GetKeyDown(KeyCode.E)) { Interact(); }
    }

    private void ForceDown()
    {
            Vector3 forceDown = Vector3.down * gravity * Time.deltaTime;
            velocity += forceDown;
   
    }

    private void Movement()
    {
        
        //move = controls.Gameplay.Move.ReadValue<Vector2>();
        if(move.magnitude > smallInput)
        {
            Vector3 movement = (move.y * transform.forward) + (move.x * transform.right);
            velocity += movement * speed * Time.deltaTime;
            velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

            if (move.magnitude > float.Epsilon)
            {
                //print("accelerate!");
                Accelerate(move);
            }
            else
            {
                Decelerate();
                //print("stahp!");
            }
        }
        
        

        anim.SetFloat("Speed", move.x);
        anim.SetFloat("Direction", move.y);

    }


    void Accelerate(Vector2 move)
    {
        velocity += (Vector3)move * acceleration * Time.deltaTime;

        if (velocity.magnitude > Mathf.Abs(maxSpeed))
        {
            velocity = velocity.normalized * maxSpeed;
        }


    }

    void Decelerate()
    {
        Vector3 projection = new Vector3(velocity.x, 0.0f).normalized;
        velocity -= projection * deceleration * Time.deltaTime;

    }


    /**
     * @Author Khaled Alraas
     * Handles collisions and updates the velocity of the player
     */
    void UpdateVelocity()
    {
        RaycastHit hit;
        int temp = 0;
        do
        {

            Vector3 point1 = transform.position + collider.center + Vector3.up * (collider.height / 2 - collider.radius);
            Vector3 point2 = transform.position + collider.center + Vector3.down * (collider.height / 2 - collider.radius);
            bool check = Physics.CapsuleCast(point1, point2, collider.radius, velocity.normalized, out hit, velocity.magnitude / 30 + collisionMargin, collisionMask);
            if (check)
            {
                Vector3 normalForce = NormalForce(velocity, hit.normal);
                velocity += normalForce;
                FrictionCalculator(normalForce);
                temp++;
                //Debug.Log(temp);
            }
        } while (hit.collider && temp < 3);

        transform.position += velocity * Time.deltaTime;

    }



    Vector3 NormalForce(Vector3 velocity, Vector3 normal)
    {

        float dotProduct = Vector3.Dot(velocity, normal);

        Vector3 projection;
        if (dotProduct > 0)
        {
            return Vector3.zero;
        }
        else
        {
            projection = Vector3.Dot(velocity, normal) * normal;
        }
        return -projection;
    }


    private void FrictionCalculator(Vector3 normalForce)
    {

        if (velocity.magnitude < normalForce.magnitude * staticFrictionCoefficient)
        {
            velocity = Vector3.zero;
        }
        else
        {
            velocity -= velocity.normalized * normalForce.magnitude * kineticFloatCoefficent;
        }

    }

    private void handleSprint(bool isSprinting)
    {
        
        timer += Time.deltaTime;
        if(timer >= 0.1)
        {
            stats.StaminaUpdater(isSprinting);
            timer = 0;
        }
    }

    /**
    * @Author Markus Larsson
    * 
    * Opens or closes the door the user is looking at.
    * Shoots raycast from the main camera.
    */
    private void Interact()
    {
        RaycastHit hit;
        //Possibly replace Camera.main.transform with a reference to the camera.
        Transform cameraTransform = Camera.main.transform;
        if (!Physics.Raycast(cameraTransform.position, cameraTransform.forward * 2, out hit, 10)) { return; }
        Door door = hit.transform.gameObject.GetComponent<Door>();
        if (door == null) { return; }
        door.ToggleState();
    }

    bool IsGrounded()
    {
        Vector3 down = velocity.normalized * groundCheckDistance;
        Vector3 centerOfSphere1 = transform.position + Vector3.up * (collider.height / 2 - collider.radius);
        Vector3 centerOfSphere2 = transform.position + Vector3.down * (collider.height / 2 - collider.radius);
        RaycastHit hit;
        bool isGrounded = Physics.CapsuleCast(centerOfSphere1, centerOfSphere2, collider.radius, velocity.normalized, out hit, down.magnitude + collisionMargin, collisionMask);
        if (isGrounded)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void MaxSpeedHandler()
    {
        if (stats.getStamina() > 0)
        {
            maxSpeed = sprintMaxSpeed;
        }

        else if (stats.getStamina() <= 0)
        {
            maxSpeed = initialMaxSpeed;
        }
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

}
