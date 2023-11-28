using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public GameObject target;
    public GameObject player;

    [Header("Settings for the pickup")]
    [Tooltip("Enable if pickup is an enemy")]
    public bool dealDamageOnTriggerEvent = true;
    [Tooltip("The amount of damage the enemy shall deal")]
    public float damageAmount = 20f;
    [Tooltip("Enable if pickup is healthy food")]
    public bool healOnTriggerEvent = false;
    [Tooltip("Amount of health regained from object")]
    public float healAmount = 20f;
    // Update is called once per frame

    private void OnTriggerEnter(Collider player)
    {
        if(dealDamageOnTriggerEvent && player == this.player.GetComponent<Collider>() && !healOnTriggerEvent)
        {
            if(damageAmount <= 0)
            {
                player.GetComponent<HealthScript>().LooseHealth();
            } else
            {
                player.GetComponent<HealthScript>().LooseHealth(damageAmount);
            }
        } else if(healOnTriggerEvent && player == this.player.GetComponent<Collider>() && !dealDamageOnTriggerEvent)
        {
            if(healAmount <= 0)
            {
                player.GetComponent<HealthScript>().LooseHealth(-20f);
            }else
            {
                player.GetComponent<HealthScript>().LooseHealth(-healAmount);
            }
        }
        target.SetActive(false);
    }
}
