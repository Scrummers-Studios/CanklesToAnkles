using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject target;
    public GameObject player;

    public bool dealDamageOnTriggerEvent = true;
    // Update is called once per frame

    private void OnTriggerEnter(Collider player)
    {
        if(dealDamageOnTriggerEvent && player == this.player.GetComponent<Collider>())
        {
            player.GetComponent<HealthScript>().LooseHealth();
            target.SetActive(false);
        }
    }
}
