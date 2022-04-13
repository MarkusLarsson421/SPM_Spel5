using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float acceleration = 2;
    [SerializeField] private float deceleration = 2;
    [SerializeField] private float maxSpeed = 2;
    [SerializeField] private float staticFrictionCoefficient = 0.4f;
    [SerializeField] private float kineticFrictionCoefficient = 0.22f;
    [SerializeField] LayerMask collisionMask;
    new CapsuleCollider collider;
    [SerializeField] float skinWidth = 0.02f;
    [SerializeField] float gravity = 9.82f;
    [SerializeField] float jump = 10f;
    [SerializeField] float groundCheckDistance = 0.04f;
    [SerializeField] Vector3 velocity;
    public Vector2 rotation;
    public float mouseSensitivity = 1f;
    public Transform camTarget;
    public float pLerp = .01f;
    public float rLerp = .02f;



    //[SerializeField] Vector3 input;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        collider = GetComponent<CapsuleCollider>();
    }

    RaycastHit hit;
    void Update()
    {
        

        Controllers();
        Vector3 gravityForce = Vector3.down * gravity * Time.deltaTime;
        Vector3 jumpForce = Vector3.up * jump;

        velocity += gravityForce;

        if (Input.GetKeyDown(KeyCode.Space) && Grounded())
        {
            velocity += jumpForce;
        }

        UpdateVelocity();
        Rotation();
        ThirdPersonCamera();
    }
    void ThirdPersonCamera()
    {
        transform.position = Vector3.Lerp(transform.position, camTarget.position, pLerp);
        transform.rotation = Quaternion.Lerp(transform.rotation, camTarget.rotation, rLerp);
    }
    void Rotation()
    {
        rotation.x += Input.GetAxis("Mouse X") * mouseSensitivity;
        rotation.y += Input.GetAxis("Mouse Y") * mouseSensitivity;
        
        rotation.y = Mathf.Clamp(rotation.y, -90f, 90f);
        transform.localRotation = Quaternion.Euler(-rotation.y, rotation.x, 0f);
    }

    void Controllers()
    {
        Vector3 input = Vector3.right * Input.GetAxisRaw("Horizontal") + Vector3.forward * Input.GetAxisRaw("Vertical");
        input = transform.rotation * input;

        if (input.magnitude > float.Epsilon)
            Accelerate(input);
        else
            Decelerate();
    }
    private void Decelerate()
    {
        if (deceleration / 100 > Mathf.Abs(velocity.x) && deceleration / 1000 > Mathf.Abs(velocity.z))
        {
            velocity.x = Vector3.zero.x;
            velocity.z = Vector3.zero.z;
        }
        Vector3 projection = new Vector3(velocity.x, 0.0f, velocity.z).normalized;
        velocity -= projection * deceleration * Time.deltaTime;
    }

    private void Accelerate(Vector3 input)
    {
        velocity += input.normalized * acceleration * Time.deltaTime;
        if (velocity.x > velocity.normalized.x * maxSpeed || velocity.x < velocity.normalized.x * maxSpeed)
        {
            velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        }
        if (velocity.z > velocity.normalized.z * maxSpeed || velocity.z < velocity.normalized.z * maxSpeed)
        {
            velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        }

    }

    void UpdateVelocity()
    {

        int temp = 0;
        do
        {
            //Vector3 look = velocity.normalized * skinWidth;

            Vector3 point1 = transform.position + collider.center + Vector3.up * (collider.height / 2 - collider.radius);
            Vector3 point2 = transform.position + collider.center + Vector3.down * (collider.height / 2 - collider.radius);
            bool check = Physics.CapsuleCast(point1, point2, collider.radius, velocity.normalized, out hit, velocity.magnitude / 30 + skinWidth, collisionMask);
            if (check)
            {
                Vector3 normalForce = Projection(velocity, hit.normal);
                velocity += normalForce;
                Friction(normalForce);
                temp++;
            }
        } while (hit.collider && temp < 3);

        transform.position += velocity * Time.deltaTime;

    }
    Vector3 Projection(Vector3 velocity, Vector3 normal)
    {
        Vector3 projection;
        if (Vector3.Dot(velocity, normal) > 0) { projection = Vector3.zero; }
        else { projection = Vector3.Dot(velocity, normal) * normal; }
        return -projection;
    }
    void Friction(Vector3 normalForce)
    {
        if (velocity.magnitude < normalForce.magnitude * staticFrictionCoefficient)
        {
            velocity = Vector3.zero;
        }
        else
        {
            velocity -= velocity.normalized * normalForce.magnitude *
                kineticFrictionCoefficient;
        }

    }

    bool Grounded()
    {
        Vector3 look = velocity.normalized * groundCheckDistance;

        Vector3 point1 = transform.position + collider.center + Vector3.up * (collider.height / 2 - collider.radius);
        Vector3 point2 = transform.position + collider.center + Vector3.down * (collider.height / 2 - collider.radius);
        bool check = Physics.CapsuleCast(point1, point2, collider.radius, velocity.normalized, out hit, look.magnitude + skinWidth, collisionMask);
        if (check) { return true; }
        else return false;
    }
}
