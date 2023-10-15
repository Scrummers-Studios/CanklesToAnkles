using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [Header("Settings for the health")]
    [Tooltip("The default health of the object")]
    public float defaultHealth = 10;
    [Tooltip("The maximum health ")]
    public float maximumHealth = 20;
    [Tooltip("The current health of the object")]
    public float currentHealth = 10;
    [Tooltip("If this object is allways invinsible or not")]
    public bool isAllwaysInvinsible = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
