using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //ref: Code like Me https://www.youtube.com/channel/UCU9YE0hMnTt6TozuyVKicHA

    private float forwardInput;
    private float rightInput;

    public CameraController cameraController;
    public PlayerMovement playerMovement;
    public PlayerAnimationController playerAnimation;

    private Vector3 velocity;

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(direction);
    }

    public void AddMovementInput(float forward, float right)    // update movement inputs
    {
        forwardInput = forward;
        rightInput = right;

        Vector3 camFwd = cameraController.transform.forward;
        Vector3 camRight = cameraController.transform.right;

        Vector3 translation = forward * cameraController.transform.forward;
        translation += right * cameraController.transform.right;
        translation.y = 0;

        if (translation.magnitude > 0)
        {
            velocity = translation;
        }
        else
        {
            velocity = Vector3.zero;
        }
        playerMovement.Velocity = translation;

    }

    internal void Jump()
    {
        playerMovement.Jump();
        playerAnimation.Jump();
    }

    public float getVelocity()
    {
        return playerMovement.Velocity.magnitude;
    }

    public void ToggleRun()
    {
        if (playerMovement.GetMovementMode() != MovementMode.Running)
        {
            playerMovement.SetMovementMode(MovementMode.Running);
            playerAnimation.SetMovementMode(MovementMode.Running);
        }
        else
        {
            playerMovement.SetMovementMode(MovementMode.Walking);
            playerAnimation.SetMovementMode(MovementMode.Walking);
        }
    }

    public void ToggleCrouch()
    {
        if (playerMovement.GetMovementMode() != MovementMode.Crouching)
        {
            playerMovement.SetMovementMode(MovementMode.Crouching);
            playerAnimation.SetMovementMode(MovementMode.Crouching);
        }
        else
        {
            playerMovement.SetMovementMode(MovementMode.Walking);
            playerAnimation.SetMovementMode(MovementMode.Walking);
        }
    }
    
}
