using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Test change
public class GroundController : MonoBehaviour
{
    public int horizontalSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Assumes a direction of left-to-right and takes the negative value of the horizontal speed to move the ground to the left
        transform.Translate(new Vector3(-horizontalSpeed, 0, 0) * Time.deltaTime);
    }
}
