using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementMode { Walking, Running, Sprinting, Crouching, Proning }

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public Transform t_mesh;
    public float maxSpeed = 5.0f;
    private float smoothSpeed;
    private float rotationSpeed = 10.0f;

    public Rigidbody rigidBody;
    public float jump_force = 100;

    MovementMode movementMode;

    private Vector3 velocity;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();          //initialize rigibody reference
    }

    void Update()
    {
        // if player is moving, rotate player mesh to match camera facing.
        if (velocity.magnitude > 0)
        {
            rigidBody.velocity = new Vector3(velocity.normalized.x * smoothSpeed, rigidBody.velocity.y, velocity.normalized.z * smoothSpeed);
            smoothSpeed = Mathf.Lerp(smoothSpeed, maxSpeed, Time.deltaTime);
            //t_mesh.rotation = Quaternion.LookRotation(velocity);
            t_mesh.rotation = Quaternion.Lerp(t_mesh.rotation, Quaternion.LookRotation(velocity), Time.deltaTime * rotationSpeed);

        }
        else
        {
            smoothSpeed = Mathf.Lerp(maxSpeed, smoothSpeed, Time.deltaTime);
        }
    }

    internal void Jump()
    {
        rigidBody.AddForce(Vector3.up * jump_force);
    }

    public Vector3 Velocity { get => rigidBody.velocity; set => velocity = value; }

    public void SetMovementMode(MovementMode mode)
    {
        movementMode = mode;
        switch (mode)
        {
            case MovementMode.Walking:
                {
                    maxSpeed = 5.0f;
                    break;
                }   
            case MovementMode.Running:
                {
                    maxSpeed = 10.0f;
                    break;
                }
            case MovementMode.Sprinting:
                {
                    maxSpeed = 20.0f;
                    break;
                }
            case MovementMode.Crouching:                
                {
                    maxSpeed = 4.0f;
                    break;
                }
            case MovementMode.Proning:
                {
                    maxSpeed = 2.0f;
                    break;
                }
        }
    }

    public MovementMode GetMovementMode()
    {
        return movementMode;
    }
}
