using UnityEngine;

/// <summary>
/// A class used to manage the Player and its properties
/// 
/// </summary>
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
    private bool correctedPlayerColliderIncrease = false;
    private bool correctedPlayerColliderDecrease = true;
    public float lastJumpTime;

    // Player components
    private Rigidbody playerRigidBody;
    private BoxCollider playerCollider;
    private Animator animator;

    //Audio
    public AudioSource playerAudio;
    public AudioClip jump, roll;

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


        lastJumpTime = Time.time;
    }

    /// <summary>
    /// Called each frame.
    /// Input related logic.
    /// 
    /// </summary>
    void Update()
    {
        //Audio for Jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAudio.clip = jump;
            playerAudio.Play();
        }
        // Jumping
        if (Input.GetKey(KeyCode.Space))
        {
            isJumping = true;
            animator.SetBool("isJumping", true);
            animator.SetBool("isGrounded", false);
        }
        else
        {
            isJumping = false;
            animator.SetBool("isGrounded", true);
            animator.SetBool("isJumping", false);
        }
        
        //Audio for rolling
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            playerAudio.clip = roll;
            playerAudio.Play();
        }

        // Rolling
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            isCrouched = true;
            animator.SetBool("isCrouched", true);
        }
        else
        {
            isCrouched = false;
            animator.SetBool("isCrouched", false);
            animator.SetBool("isGrounded", true);
        }
    }

    /// <summary>
    /// Logic concerning physics calculations  
    /// 
    /// </summary>
    void FixedUpdate()
    {
        UpdateGroundedStatus();
        OnPlayerRollEvent();
        OnPlayerJumpEvent();
    }

    /// <summary>
    ///  Handles the player rolling
    ///  
    /// Adapts the player collider size depending on whether the player is rolling or not while 
    /// ensureing that the collider remains in same vertical posistion.
    /// </summary>
    private void OnPlayerRollEvent()
    {
        if (isCrouched)
        {
            playerCollider.size = new UnityEngine.Vector3(BASE_PLAYER_WIDTH, BASE_PLAYER_HEIGHT * 0.5f, BASE_PLAYER_DEPTH);

            if (!correctedPlayerColliderIncrease)
            {
                playerRigidBody.position = new UnityEngine.Vector3(playerRigidBody.position.x, playerRigidBody.position.y - 0.5f, playerRigidBody.position.z);
                correctedPlayerColliderIncrease = true;
                animator.SetBool("isCrouched", true);
            }

            correctedPlayerColliderDecrease = false;
        }
        else
        {
            playerCollider.size = new UnityEngine.Vector3(BASE_PLAYER_WIDTH, BASE_PLAYER_HEIGHT, BASE_PLAYER_DEPTH);

            if (!correctedPlayerColliderDecrease)
            {
                playerRigidBody.position = new UnityEngine.Vector3(playerRigidBody.position.x, playerRigidBody.position.y + 0.5f, playerRigidBody.position.z);
                correctedPlayerColliderDecrease = true;
                animator.SetBool("isCrouched", false);

            }

            correctedPlayerColliderIncrease = false;
        }
    }

    /// <summary>
    /// Updates the current status regarding wheter the player is grounded or not.
    /// 
    /// </summary>
    private void UpdateGroundedStatus()
    {
        float rayLength = .1f;

        // Checks if the player is grounded
        isGrounded = Physics.Raycast(playerCollider.bounds.center, UnityEngine.Vector3.down, playerCollider.bounds.extents.y + rayLength);
    }

    /// <summary>
    /// Handles the player jumping and its related physics calulations.
    /// 
    /// </summary>
    private void OnPlayerJumpEvent()
    {

        // Temporary solution for bouncing
        // Physics: Jump equation, sqrt(2*g*h)
        if (isGrounded && isJumping)
        {
            float momentum = playerRigidBody.velocity.y * playerRigidBody.mass;

            Debug.Log("Required force to reset velocity" + momentum);

            // Resets the player momentum 
            playerRigidBody.AddForce(new UnityEngine.Vector3(0f, -momentum), ForceMode.Impulse);

            // Changes the players velocity based on the pre-defined jumping force
            playerRigidBody.AddForce(new UnityEngine.Vector3(0f, jumpingPower), ForceMode.Impulse);

            animator.SetBool("isJumping", true);
        }
    }
}
