using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is used to tweak a given rigidbody's gravity 
/// 
/// Implementation and architecture inspired by https://gamedevbeginner.com/how-to-jump-in-unity-with-or-without-physics/#jump_unity 
/// <remarks>
/// Date: 07/11/2023
/// </remarks>
/// </summary>
public class CustomGravity : MonoBehaviour
{
    private const float GRAVITY = 9.81f;

    // The rigidbody to be affected by the custom gravity
    public Rigidbody rigidbody;
    public float defaultGravityScale = 1;
    public float fallingGravityScale = 2;


    /// <summary>
    /// Applies the global gravity to the rigidbody as a start.
    /// </summary>
    void Start()
    {
        rigidbody.AddForce(Physics.gravity, ForceMode.Acceleration);
    }

    /// <summary>
    /// Applies the global gravity to the rigidbody as a start.
    /// </summary>
    void FixedUpdate()
    {
        if (IsFalling())
        {

            SetGravity(fallingGravityScale * Physics.gravity);
        }
        else
        {

            SetGravity(defaultGravityScale * Physics.gravity);

        }
    }

    /// <summary>
    /// Method for determining wheter the rigidbody is falling
    /// </summary>
    private bool IsFalling()
    {
        if (rigidbody.velocity.y >= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    ///  Applies the given gravity to the rigidbody replacing the previous gravity
    /// </summary>
    /// <param name="gravity"></param>
    public void SetGravity(Vector3 gravity)
    {
        rigidbody.AddForce(gravity, ForceMode.Acceleration);
    }

    /// <summary>
    /// Resets the gravity to the global gravity defined in unity's project settings
    /// </summary>
    public void ResetGravity()
    {
        rigidbody.AddForce(new Vector3(0, GRAVITY, 0), ForceMode.Acceleration);
    }


}
