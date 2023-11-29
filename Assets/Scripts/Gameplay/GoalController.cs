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
        if(player == this.player.GetComponent<Collider>())
        {
            levelsCleared.Add(currentScene);
            this.GetComponentInParent<GroundController>().horizontalSpeed = 0;
            this.GetComponentInParent<GroundController>().verticalSpeed = 0;
            ground.GetComponent<GroundController>().horizontalSpeed = 0;
            ground.GetComponent<GroundController>().verticalSpeed = 0;
            winScreen.SetActive(true);
            this.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
