using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DynamicMovementController : MonoBehaviour
{
    // Start is called before the first frame update
    private InputSystem controls;
    private float speed = 8f;

    private Vector3 velocity;

    private float gravity = 10f;

    private Vector2 move;
    private float collisionMargin = 0.4f;
    private CapsuleCollider collider;


    [SerializeField] private LayerMask collisionMask;
    [SerializeField] float staticFrictionCoefficient = 0.6f;
    [SerializeField] float kineticFloatCoefficent = 0.2f;


    void Awake()
    {
        controls = new InputSystem();
        collider = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        ForceDown();
        Movement();
        UpdateVelocity();
    }

    private void ForceDown()
    {
        Debug.Log("Force down!");
        Vector3 forceDown = Vector3.down * gravity * Time.deltaTime;
        velocity += forceDown;
    }

    private void Movement()
    {
        move = controls.Gameplay.Move.ReadValue<Vector2>();

        Vector3 movement = (move.y * transform.forward) + (move.x * transform.right);
        velocity += movement * speed * Time.deltaTime;
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    //Khaled Alraas
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
                Debug.Log(temp);
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

}
