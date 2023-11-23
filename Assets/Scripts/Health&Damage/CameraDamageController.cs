using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDamgeController : MonoBehaviour
{
    public Camera cam;
    public GameObject player;
    private Plane[] cameraFrustum;
    private BoxCollider playerCollider;

    private void Start()
    {
        playerCollider = player.GetComponent<BoxCollider>();
    }

    private void FixedUpdate()
    {

        if (!ViewCheck())
        {
            player.GetComponent<HealthScript>().LooseLife(1);
            player.GetComponent<HealthScript>().Respawn();
        }
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
