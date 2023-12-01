using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Test change
public class GroundController : MonoBehaviour
{
    public int x_axis_speed = 0;
    public int z_axis_speed = 0;

    // Update is called once per frame
    void Update()
    {
        // Assumes that forward direction is along x-axis
        transform.Translate(new Vector3(-x_axis_speed, 0, -z_axis_speed) * Time.deltaTime);
    }
}
