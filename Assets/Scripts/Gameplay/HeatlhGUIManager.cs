using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeatlhGUIManager : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public GameObject player;
    public TextMeshProUGUI livesText;
    // Start is called before the first frame update
 

    // Update is called once per frame
    void Update()
    {
        string hitpoints = player.GetComponent<HealthScript>().GetHitPoints().ToString();
        string lives = player.GetComponent<HealthScript>().GetLives().ToString();

        livesText.SetText(lives);
        healthText.SetText(hitpoints);
    }
}
