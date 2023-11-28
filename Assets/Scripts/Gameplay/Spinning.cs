using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinning : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(25f * Time.deltaTime, 100f * Time.deltaTime, 40f * Time.deltaTime, Space.Self);
    }
}
