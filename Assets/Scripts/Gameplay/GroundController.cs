using UnityEngine;

/// <summary>
/// Continiously translates its respective body linearly along the specified axis. 
/// 
/// </summary>
public class GroundController : MonoBehaviour
{
    // Speed parameters
    public int x_axis_speed = 0;
    public int z_axis_speed = 0;
    public int y_axis_speed = 0;

    // Updates the posistion once per frame
    void Update()
    {
        // Assumes that forward direction is along x-axis
        transform.Translate(new Vector3(-x_axis_speed, y_axis_speed, -z_axis_speed) * Time.deltaTime);
    }
}
