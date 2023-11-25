using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Test change
public class GroundController : MonoBehaviour
{
    public int horizontalSpeed = 0;
    public int verticalSpeed = 0;

    // Update is called once per frame
    void Update()
    {
        // Assumes that forward direction is along x-axis
        transform.Translate(new Vector3(-horizontalSpeed, 0, verticalSpeed) * Time.deltaTime);
    }
}
