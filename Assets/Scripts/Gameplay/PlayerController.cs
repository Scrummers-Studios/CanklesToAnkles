using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Properties used for player size
    private float BASE_PLAYER_HEIGHT;
    private float BASE_PLAYER_WIDTH;
    private float BASE_PLAYER_DEPTH;

    // Movement properties
    public float jumpingPower = 100f;
    public bool isGrounded = true;
    public bool isCrouched = false;
    public bool isJumping = false;

    // Conditions for player crouching, Assumes player starts in a standing posistion
    private bool correctedPlayerCrouchOffset = false;
    private bool correctedPlayerStandOffset = true;

    private Rigidbody playerRigidBody;
    private BoxCollider playerCollider;
    private Animator animator;


    /// <summary>
    /// Initializes the player controller and its relevant components.
    /// 
    /// </summary>
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        playerCollider = GetComponent<BoxCollider>();
        animator = GetComponentInChildren<Animator>();

        // Register size from Collider object
        BASE_PLAYER_WIDTH = playerCollider.size.x;
        BASE_PLAYER_HEIGHT = playerCollider.size.y;
        BASE_PLAYER_DEPTH = playerCollider.size.z;
    }

    // Used for input related logic
    void Update()
    {
        // Jumping
        // Using GetKey instead of GetKeyDown as it allows for holding down the key
        if (Input.GetKey(KeyCode.Space))
        {
            isJumping = true;
            animator.SetBool("isJumping", true);
          
        }
        else
        {
            isJumping = false;
            animator.SetBool("isJumping", false);
        }

        // Crouching
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            isCrouched = true;
            animator.SetBool("isCrouched", true);
        }
        else
        {
            isCrouched = false;
            animator.SetBool("isCrouched", false);
        }
    }

    // Using FixedUpdate for physics related logic
    void FixedUpdate()
    {
        UpdateGroundedStatus();
        OnPlayerCrouchEvent();
        OnPlayerJumpEvent();
    }

    /// <summary>
    /// Handles the player crouching
    /// 
    /// </summary>
    private void OnPlayerCrouchEvent()
    {
        togglePlayerCrouchedSize(isCrouched);
    }

    /// <summary>
    /// Adapts the player collider size depending on whether the player is crouched or not.
    /// 
    /// </summary>
    /// <param name="isCrouched"></param>
    private void togglePlayerCrouchedSize(bool isCrouched)
    {
        if (isCrouched)
        {
            playerCollider.size = new UnityEngine.Vector3(BASE_PLAYER_WIDTH, BASE_PLAYER_HEIGHT * 0.5f, BASE_PLAYER_DEPTH);

            if (!correctedPlayerCrouchOffset)
            {
                playerRigidBody.position = new UnityEngine.Vector3(playerRigidBody.position.x, playerRigidBody.position.y - 0.5f, playerRigidBody.position.z);
                correctedPlayerCrouchOffset = true;
                // TODO: create update animations
                animator.SetBool("isCrouched", true);
            }

            correctedPlayerStandOffset = false;
        }
        else
        {
            playerCollider.size = new UnityEngine.Vector3(BASE_PLAYER_WIDTH, BASE_PLAYER_HEIGHT, BASE_PLAYER_DEPTH);

            if (!correctedPlayerStandOffset)
            {
                playerRigidBody.position = new UnityEngine.Vector3(playerRigidBody.position.x, playerRigidBody.position.y + 0.5f, playerRigidBody.position.z);
                correctedPlayerStandOffset = true;
                // TODO: create update animations
                animator.SetBool("isCrouched", false);

            }

            correctedPlayerCrouchOffset = false;
        }
    }

    // Updates the status of the player being grounded
    private void UpdateGroundedStatus()
    {
        float rayLength = .1f;

        // Checks if the player is grounded
        isGrounded = Physics.Raycast(playerCollider.bounds.center, UnityEngine.Vector3.down, playerCollider.bounds.extents.y + rayLength);
    }

    /// <summary>
    /// Handles the player jumping 
    /// </summary>
    private void OnPlayerJumpEvent()
    {
        if (isGrounded && isJumping)
        {
            float velocityReset = -(playerRigidBody.velocity.y * playerRigidBody.mass);

            Debug.Log("Required force to reset velocity" + velocityReset);

            // Resets the player momentum 
            playerRigidBody.AddForce(new UnityEngine.Vector3(0f, velocityReset), ForceMode.Impulse);

            // Applies the jumping force
            playerRigidBody.AddForce(new UnityEngine.Vector3(0f, jumpingPower), ForceMode.Impulse);

            animator.SetBool("isJumping", true);
        }
    }
}
