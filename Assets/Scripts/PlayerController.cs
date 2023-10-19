using System.Collections;
using System.Collections.Generic;
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

    [Tooltip("The health script for the player.")]
    public Health playerHealth;


    private Vector3 respawnPoint;
    private static float OUT_OF_BOUNDS = -133.0f;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        playerCollider = GetComponentInChildren<BoxCollider>();
        SetSpawnPoint();
    }

    // Response to the player object colliding with other objects
    void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.CompareTag("Ground");
        isGrounded = true;
    }


    // Using FixedUpdate for physics related logic
    void Update()
    {
        OnPlayerJumpEvent();
        OnPlayerCrouchEvent();
        CheckOutSideOfBounds();
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

    // Checks if the player are outside of the defined bounds
    private void CheckOutSideOfBounds()
    {
        if(transform.position.x < OUT_OF_BOUNDS)
        {
            playerHealth.takeDamage(20);
            transform.position = respawnPoint;
        }
    }

    
    //Respawn the object to the respawnpoint
    private void Respawn()
    {
        transform.position.Set(respawnPoint.x,respawnPoint.y,respawnPoint.z);
        /** TODO:
         * - Add take some damage with the health script
         */
    }


    //Just sets the respawnpoint to the middle of the gameview
    private void SetSpawnPoint()
    {
        respawnPoint = new Vector3(-120, 0.1f, 3);
    }
}
