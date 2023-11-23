using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [Header("Health Settings")]
    [Tooltip("The default health value")]
    public float defaultHealth = 100f;
    [Tooltip("The maximum health value")]
    public float maximumHealth = 200f;
    [Tooltip("The current in game health value")]
    public float currentHealth = 100f;
    [Tooltip("Invulnerability duration, in seconds, after taking damage")]
    public float invincibilityTime = 3f;
    [Tooltip("The amount of damage taken each hit")]
    public float damageTaking = 20f;

    [Header("Lives settings")]
    [Tooltip("Whether or not to use lives")]
    public bool useLives = true;
    [Tooltip("Current number of lives this health has")]
    public int currentLives = 1;
    [Tooltip("The maximum number of lives this health has")]
    public int maximumLives = 5;
    [Tooltip("The amount of time to wait before respawning")]
    public float respawnWaitTime = 3f;

    public GameObject target;
    public GameObject ground;

    private Vector3 groundPosition;
    private Vector3 basePosition;

    private void Start()
    {
        basePosition = target.transform.position;
        groundPosition = ground.transform.position;
    }

    public void LooseHealth(float damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0f)
        {
            this.LooseLife(1);
        }
    }
    public void LooseHealth()
    {
        currentHealth -= damageTaking;
        if (currentHealth <= 0f)
        {
            this.LooseLife(1);
        }
    }

    public void LooseLife(int lives)
    {
        if(!useLives)
        {
            return;
        }
        currentLives -= lives;
        if(currentLives <= 0)
        {
            Die();
        } else
        {
            Respawn();
            currentHealth = defaultHealth;
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
        target.SetActive(false);
        if (target.CompareTag("Player"))
        {
            //GameManager display gameover and furthur handling
        }

    }

    public int GetLives()
    {
        return currentLives;
    }

    public float GetHitPoints()
    {
        return currentHealth;
    }

}
