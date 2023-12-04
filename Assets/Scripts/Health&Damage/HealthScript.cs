using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    [Header("Health Settings")]
    [Tooltip("The default health value")]
    public float defaultHealth = 100f;
    [Tooltip("The maximum health value")]
    public float maximumHealth = 200f;
    [Tooltip("The current in game health value")]
    public float currentHealth = 100f;
    [Tooltip("The amount of damage taken each hit")]
    public float damageTaking = 20f;

    [Header("Objects in the scene")]
    [Tooltip("The player")]
    public GameObject target;
    [Tooltip("The enviroment object with the groundspeed")]
    public GameObject ground;
    [Tooltip("The bar in the health bar")]
    public Image image;


    private Vector3 groundPosition;
  
    private Vector3 basePosition;

    private void Start()
    {
        basePosition = target.transform.position;
        UpdateHealthBar();
        groundPosition = ground.transform.position;
    }

    public void LooseHealth(float damage)
    {
        currentHealth -= damage;
        if(currentHealth > maximumHealth)
        {
            currentHealth = maximumHealth;
        }
        UpdateHealthBar();
        if (currentHealth <= 0f)
        {
            Die();
        }
    }
    public void LooseHealth()
    {
        currentHealth -= damageTaking;
        if(currentHealth > maximumHealth)
        {
            currentHealth = maximumHealth;
        }
        UpdateHealthBar();
        if (currentHealth <= 0f)
        {
            Die();
        } 
    }


    public void Respawn()
    {
        target.transform.position = basePosition;
        target.GetComponent<Rigidbody>().velocity.Set(0, 0, 0);
        ground.transform.position = groundPosition;
    }

    private void Die()
    {
        //target.SetActive(false);
        if (target.CompareTag("Player"))
        {
            currentHealth = defaultHealth;
            Respawn();
            UpdateHealthBar();
        }

    }


    public float GetHitPoints()
    {
        return currentHealth;
    }

    private void UpdateHealthBar()
    {
        image.fillAmount = 1 - (currentHealth / maximumHealth);
    }

}
