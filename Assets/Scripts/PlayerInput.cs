using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(PlayerMovement))]

public class PlayerInput : MonoBehaviour
{

    private Player player;
    private PlayerMovement playerMovement;
    public LayerMask ground;
    private bool isGrounded;
   
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        player.AddMovementInput(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
        isGrounded = Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), 0.04f, ground);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            player.ToggleRun();

        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            player.ToggleCrouch();
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            player.Jump();
        }
    }
}
