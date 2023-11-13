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
    public float jumpingPower = 35;
    public bool isGrounded = true;
    public bool isCrouched = false;
    public bool isJumping = false;

    // Conditions for player crouching
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

    /// <summary>
    /// Handles the players collision
    /// 
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.CompareTag("Ground");
        isGrounded = true;
        animator.SetBool("isGrounded", isGrounded);
    }

    // Using FixedUpdate for physics related logic
    void FixedUpdate()
    {
        OnPlayerJumpEvent();
        OnPlayerCrouchEvent();
    }

    /// <summary>
    /// Handles the player crouching
    /// 
    /// </summary>
    private void OnPlayerCrouchEvent()
    {
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            isCrouched = true;
            animator.SetBool("isCrouched", isCrouched);

        }
        else
        {
            isCrouched = false;
            animator.SetBool("isCrouched", isCrouched);
        }

        togglePlayerCrouchedSize(isCrouched);

    }

    /// <summary>
    /// Translates the player collider size to simulate crouching resulting in a more smooth transition
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

            }

            correctedPlayerCrouchOffset = false;
        }
    }

    /// <summary>
    /// Handles the player jumping 
    /// </summary>
    private void OnPlayerJumpEvent()
    {

        if (Input.GetKey(KeyCode.Space) && isGrounded == true)
        {
            playerRigidBody.AddForce(new UnityEngine.Vector3(0f, jumpingPower), ForceMode.Impulse);
            isGrounded = false;
            animator.SetBool("isGrounded", isGrounded);
        }
    }
}
