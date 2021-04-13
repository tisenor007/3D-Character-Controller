using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerAnimationController : MonoBehaviour
{
    // Code like Me https://www.youtube.com/watch?v=p1_Om8viUJQ

    public Animator animator;
    private Player player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator == null)
        {
            Debug.LogWarning("No Animator Found");
            return;
        }

        animator.SetFloat( "Velocity", player.getVelocity() );
        Debug.Log(player.getVelocity());


    }

    public void SetMovementMode(MovementMode mode)
    {
    
        switch (mode)
        {
            case MovementMode.Walking:
                {
                    animator.SetInteger("movement state", 0);
                    break;
                }
            case MovementMode.Running:
                {
                    animator.SetInteger("movement state", 0);
                    break;
                }
            case MovementMode.Sprinting:
                {
                    animator.SetInteger("movement state", 4);
                    break;
                }
            case MovementMode.Crouching:
                {
                    animator.SetInteger("movement state", 1);
                    break;
                }
            case MovementMode.Proning:
                {
                    animator.SetInteger("movement state", 2);
                    break;
                }
        }
    }

    internal void Jump()
    {
        animator.SetTrigger("Jump");
    }
}
