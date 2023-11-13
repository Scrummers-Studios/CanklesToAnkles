using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    public Camera cam;
    public GameObject player;
    private Vector3 basePosition;
    private Plane[] cameraFrustum;
    private BoxCollider playerCollider;

    private void Start()
    {
        basePosition = player.transform.position;
        playerCollider = player.GetComponent<BoxCollider>();
    }

    private void FixedUpdate()
    {

        if (!ViewCheck())
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        player.transform.position = basePosition;
    }


    private bool ViewCheck()
    {
        var bounds = playerCollider.bounds;
        cameraFrustum = GeometryUtility.CalculateFrustumPlanes(cam);
        bool inView = false;
        if(GeometryUtility.TestPlanesAABB(cameraFrustum,bounds))
        {
            inView = true;
        }

        return inView;
    }

    
}
