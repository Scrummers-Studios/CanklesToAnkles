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
    // TODO Make private.
    public float jumpingPower = 35;
    public bool isGrounded = true;
    public bool isRolling = false;
    public bool isJumping = false;
    public bool isLanding = false;
    private bool correctedPlayerColliderIncrease = false;
    private bool correctedPlayerColliderDecrease = true;
    private float timeOfLastRoll;

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
    }

    /// <summary>
    /// Called each frame.
    /// Deals with the player feedback.  
    /// 
    /// </summary>
    void Update()
    {
        CheckJumpAudio();
        CheckJumpInput();
        CheckRollAudio();
        CheckRollInput();
    }

    /// <summary>
    /// Checks if the player intends to roll
    /// </summary>
    private void CheckRollInput()
    {
        // Rolling
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl) && Time.time - timeOfLastRoll >= 0.5f)
        {

            isRolling = true;
            animator.SetBool("isRolling", true);
        }
        else
        {
            isRolling = false;
            animator.SetBool("isRolling", false);
        }
    }

    /// <summary>
    /// Checks if the player themselves is rolling and outputs sound if its the case.
    /// 
    /// </summary>
    private void CheckRollAudio()
    {
        //Audio for rolling
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            playerAudio.clip = roll;
            playerAudio.Play();
        }
    }

    /// <summary>
    /// Checks if the player intends to jump
    /// 
    /// </summary>
    private void CheckJumpInput()
    {
        // Jumping
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
    }

    /// <summary>
    /// Checks if the player is jumping and outputs sound if that is the case. 
    /// </summary>
    private void CheckJumpAudio()
    {
        //Audio for Jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAudio.clip = jump;
            playerAudio.Play();
        }
    }

    /// <summary>
    /// Logic concerning physics calculations  
    /// 
    /// </summary>
    void FixedUpdate()
    {
        UpdateGroundedStatus();
        UpdateLandingStatus();
        OnPlayerRollEvent();
        OnPlayerJumpEvent();
    }


    /// <summary>
    /// Updates the current status concering wheter the player is falling
    /// 
    /// </summary>
    void UpdateLandingStatus()
    {
        float rayLength = 1f;

        isLanding = Physics.Raycast(playerCollider.bounds.center, UnityEngine.Vector3.down, playerCollider.bounds.extents.y + rayLength);
        animator.SetBool("isLanding", isLanding);

    }

    /// <summary>
    ///  Handles the player rolling
    ///  
    /// Adapts the player collider size depending on whether the player is rolling or not while 
    /// ensureing that the collider remains in same vertical posistion.
    /// </summary>
    private void OnPlayerRollEvent()
    {
        if (isRolling && isGrounded)
        {
            playerCollider.size = new UnityEngine.Vector3(BASE_PLAYER_WIDTH, BASE_PLAYER_HEIGHT * 0.5f, BASE_PLAYER_DEPTH);

            if (!correctedPlayerColliderIncrease)
            {
                playerRigidBody.position = new UnityEngine.Vector3(playerRigidBody.position.x, playerRigidBody.position.y - 0.5f, playerRigidBody.position.z);
                correctedPlayerColliderIncrease = true;
                animator.SetBool("isRolling", true);
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
                animator.SetBool("isRolling", false);

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

        animator.SetBool("isGrounded", isGrounded);


    }

    /// <summary>
    /// Handles the player jumping and its related physics calulations.
    /// 
    /// </summary>
    private void OnPlayerJumpEvent()
    {

        if (isGrounded && isJumping && !isRolling)
        {
            float momentum = playerRigidBody.velocity.y * playerRigidBody.mass;

            // Resets the player momentum 
            playerRigidBody.AddForce(new UnityEngine.Vector3(0f, -momentum), ForceMode.Impulse);

            // Changes the players velocity based on the pre-defined jumping force
            playerRigidBody.AddForce(new UnityEngine.Vector3(0f, jumpingPower), ForceMode.Impulse);

        }
    }
}
