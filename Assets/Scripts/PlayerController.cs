using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //* Constants
    private const float BASE_PLAYER_HEIGHT = 0.085f;
    private const float BASE_PLAYER_WIDTH = 0.035f;
    private const float BASE_PLAYER_DEPTH = 0.015f;

    //* Fields

    // Suggests that the player starts on the ground
    public bool isGrounded = true;
    // Suggests that the player starts on its feet
    public bool isCrouched = false;

    // The players Rigidbody for interacting with physics
    public Rigidbody playerRigidBody;

    // The players Collider for detecting contanct between game objects.
    public BoxCollider playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        playerCollider = GetComponentInChildren<BoxCollider>();
    }

    // Response to the player object colliding with other objects
    void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.CompareTag("Ground");
        isGrounded = true;
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
        }
        else
        {
            isCrouched = false;
        }

        if (isCrouched)
        {
            playerCollider.size = new UnityEngine.Vector3(BASE_PLAYER_WIDTH, BASE_PLAYER_HEIGHT * 0.5f, BASE_PLAYER_DEPTH);
        }
        else
        {
            playerCollider.size = new UnityEngine.Vector3(BASE_PLAYER_WIDTH, BASE_PLAYER_HEIGHT, BASE_PLAYER_DEPTH);
        }
    }

    // Response to the player jumping
    private void OnPlayerJumpEvent()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded == true)
        {
            playerRigidBody.velocity = new UnityEngine.Vector3(0f, 5f);
            isGrounded = false;
        }
    }
}
