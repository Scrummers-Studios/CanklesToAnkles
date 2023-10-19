using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    public int movingSpeedLeftRight = 0;
    public int movingSpeedDownUp = 0;
    public int movingSpeedBackForward = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(new Vector3(movingSpeedLeftRight, 0, movingSpeedBackForward) * Time.deltaTime);

    }
}
