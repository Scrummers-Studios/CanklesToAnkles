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


    public GameObject target;
    public GameObject ground;
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
        UpdateHealthBar();
        if (currentHealth <= 0f)
        {
            Die();
        }
    }
    public void LooseHealth()
    {
        currentHealth -= damageTaking;
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
            currentHealth = 100f;
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
