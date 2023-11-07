using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float BASE_PLAYER_HEIGHT;
    private float BASE_PLAYER_WIDTH;
    private float BASE_PLAYER_DEPTH;

    public bool isGrounded = true;
    public bool isCrouched = false;
    public bool isJumping = false;
    public bool donePlayerCrouchOffset = false;
    public bool donePlayerStandOffset = true;

    private Rigidbody playerRigidBody;
    private BoxCollider playerCollider;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        playerCollider = GetComponent<BoxCollider>();
        animator = GetComponentInChildren<Animator>();

        // Register size from Collider object
        BASE_PLAYER_WIDTH = playerCollider.size.x;
        BASE_PLAYER_HEIGHT = playerCollider.size.y;
        BASE_PLAYER_DEPTH = playerCollider.size.z;

        // WIP
        playerCollider.material.dynamicFriction = 0;
        playerCollider.material.staticFriction = 0;
    }

    // Response to the player object colliding with other objects
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

    // Response to the player crouching
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

    private void togglePlayerCrouchedSize(bool isCrouched)
    {
        if (isCrouched)
        {
            playerCollider.size = new UnityEngine.Vector3(BASE_PLAYER_WIDTH, BASE_PLAYER_HEIGHT * 0.5f, BASE_PLAYER_DEPTH);

            if (!donePlayerCrouchOffset)
            {
                playerRigidBody.position = new UnityEngine.Vector3(playerRigidBody.position.x, playerRigidBody.position.y - 0.5f, playerRigidBody.position.z);
                donePlayerCrouchOffset = true;
            }

            donePlayerStandOffset = false;
        }
        else
        {
            playerCollider.size = new UnityEngine.Vector3(BASE_PLAYER_WIDTH, BASE_PLAYER_HEIGHT, BASE_PLAYER_DEPTH);

            if (!donePlayerStandOffset)
            {
                playerRigidBody.position = new UnityEngine.Vector3(playerRigidBody.position.x, playerRigidBody.position.y + 0.5f, playerRigidBody.position.z);
                donePlayerStandOffset = true;

            }

            donePlayerCrouchOffset = false;
        }
    }

    // Response to the player jumping
    private void OnPlayerJumpEvent()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded == true)
        {
            playerRigidBody.velocity = new UnityEngine.Vector3(0f, 5f);
            isGrounded = false;
            animator.SetBool("isGrounded", isGrounded);
        }
    }
}
