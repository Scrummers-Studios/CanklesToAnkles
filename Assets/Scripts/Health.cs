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
    [Tooltip("The gameObject that has health")]
    public GameObject healthEntity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int damageAmount)
    {
        if(isAllwaysInvinsible || currentHealth <= 0)
        {
            return;
        } else
        {
            //TODO: Add damage effect initiation here

            currentHealth = Mathf.Clamp(currentHealth - damageAmount, 0, maximumHealth);
            CheckDeath();
        }
    }

    private void CheckDeath()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        this.healthEntity.SetActive(false);
    }
}
