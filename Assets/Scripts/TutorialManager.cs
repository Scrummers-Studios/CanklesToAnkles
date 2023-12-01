using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;
    GroundController groundController;
    PlayerController playerController;
    public float waitTime = 2f;

    private void Start()
    {
        if (groundController == null)
        {
            groundController = FindObjectOfType<GroundController>();
        }
        if (playerController == null)
        {
            playerController = FindObjectOfType<PlayerController>();
        }
        groundController.z_axis_speed = 0;
        playerController.jumpingPower = 0;
    }

    void Update()
    {
        for (int i = 0; i < popUps.Length; i++)
        {
            if (i == popUpIndex)
            {
                popUps[i].SetActive(true);
            }
            else
            {
                popUps[i].SetActive(false);
            }
        }
        if (popUpIndex == 0)
        {
            if (Input.anyKeyDown)
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 1)
        {

            if (Input.anyKeyDown)
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 2)
        {
            if (Input.anyKeyDown)
            {
                groundController.z_axis_speed = 4;
                popUpIndex++;
            }
        }
        else if (popUpIndex == 3)
        {
            groundController.z_axis_speed = 0;
            playerController.jumpingPower = 100;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                groundController.z_axis_speed = 4;
                popUpIndex++;
                waitTime = 2f;
            }
        }
        else if (popUpIndex == 4 && waitTime <= 0)
        {
            popUpIndex++;
        }
        else if (popUpIndex == 5)
        {
            playerController.jumpingPower = 0;
            groundController.z_axis_speed = 0;
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                groundController.z_axis_speed = 4;
                popUpIndex++;
                waitTime = 2f;
            }
        }
        else if (popUpIndex == 6 && waitTime <= 0)
        {
            popUpIndex++;
        }
        else if (popUpIndex == 7)
        {
            groundController.z_axis_speed = 0;
            if (Input.anyKeyDown)
            {
                popUpIndex++;
                waitTime = 2f;
            }
        }
        else if (popUpIndex == 8)
        {
            if (Input.anyKeyDown)
            {
                groundController.z_axis_speed = 4;
                popUpIndex++;
            }
        }
        else if (popUpIndex == 9 && waitTime <= 0)
        {
            popUpIndex++;
        }
        else if (popUpIndex == 10)
        {
            groundController.z_axis_speed = 0;
            if (Input.anyKeyDown)
            {
                groundController.z_axis_speed = 4;
                popUpIndex++;
                waitTime = 2f;
            }
        }
        else if (popUpIndex == 11 && waitTime <= 0)
        {
            popUpIndex++;
        }
        else if (popUpIndex == 12)
        {
            groundController.z_axis_speed = 0;
            if (Input.anyKeyDown)
            {
                playerController.jumpingPower = 100;
                groundController.z_axis_speed = 4;
                popUpIndex++;
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}
