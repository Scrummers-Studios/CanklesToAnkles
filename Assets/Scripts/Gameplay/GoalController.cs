using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalCounter : MonoBehaviour
{
    public GameObject ground;
    public List<Scene> levelsCleared = new List<Scene>();
    public GameObject winScreen;
    private Scene currentScene;
    public GameObject player;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        this.GetComponent<MeshRenderer>().enabled = false;
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player == this.player.GetComponent<Collider>())
        {
            levelsCleared.Add(currentScene);
            this.GetComponentInParent<GroundController>().x_axis_speed = 0;
            this.GetComponentInParent<GroundController>().z_axis_speed = 0;
            ground.GetComponent<GroundController>().x_axis_speed = 0;
            ground.GetComponent<GroundController>().z_axis_speed = 0;
            this.GetComponent<AudioSource>().Play();
            winScreen.SetActive(true);
            this.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
