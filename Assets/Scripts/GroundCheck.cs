using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component on gameobjects with colliders which determines if there is
/// a collider overlapping them which is on a specific layer.
/// Used to check for ground in a 3D environment.
/// </summary>
[RequireComponent(typeof(Collider))]
public class GroundCheck : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("The layers which are considered \"Ground\".")]
    public LayerMask groundLayers;
    [Tooltip("The collider to check with. (Defaults to the collider on this game object.)")]
    public Collider groundCheckCollider;

    [Header("Effect Settings")]
    [Tooltip("The effect to create when landing")]
    public GameObject landingEffect;

    // Whether or not the player was grounded last check
    [HideInInspector]
    public bool groundedLastCheck = false;

    // Size of the overlap box
    public Vector3 checkSize = new Vector3(1f, 0.1f, 1f);

    private void Start()
    {
        // When this component starts up, ensure that the collider is not null, if possible
        GetCollider();
    }

    public void GetCollider()
    {
        if (groundCheckCollider == null)
        {
            groundCheckCollider = GetComponent<Collider>();
        }
    }

    public bool CheckGrounded()
    {
        if (groundCheckCollider == null)
        {
            GetCollider();
        }

        Vector3 worldPosition = groundCheckCollider.bounds.center;
        Vector3 worldExtents = groundCheckCollider.bounds.extents;
        Vector3 overlapBoxSize = new Vector3(worldExtents.x, checkSize.y, worldExtents.z);

        // Check for ground
        Collider[] overlaps = Physics.OverlapBox(worldPosition, overlapBoxSize, Quaternion.identity, groundLayers);

        foreach (Collider overlapCollider in overlaps)
        {
            if (overlapCollider != null && overlapCollider != groundCheckCollider)
            {
                if (landingEffect && !groundedLastCheck)
                {
                    Instantiate(landingEffect, transform.position, Quaternion.identity);
                }
                groundedLastCheck = true;
                return true;
            }
        }
        groundedLastCheck = false;
        return false;
    }

    // Visualize the ground check box in the editor
    private void OnDrawGizmosSelected()
    {
        if (groundCheckCollider != null)
        {
            Gizmos.color = Color.green;
            Vector3 worldPosition = groundCheckCollider.bounds.center;
            Vector3 worldExtents = groundCheckCollider.bounds.extents;
            Vector3 overlapBoxSize = new Vector3(worldExtents.x, checkSize.y, worldExtents.z);
            Gizmos.DrawWireCube(worldPosition, overlapBoxSize * 2);
        }
    }
}