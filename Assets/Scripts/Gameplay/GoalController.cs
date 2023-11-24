using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalCounter : MonoBehaviour
{
    public GameObject ground;
    public List<Scene> levelsCleared = new List<Scene>();
    public TextMeshProUGUI winText;
    private Scene currentScene;
    public GameObject player;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    private void OnTriggerEnter(Collider player)
    {
        if(player == this.player.GetComponent<Collider>())
        {
            levelsCleared.Add(currentScene);
            this.GetComponentInParent<GroundController>().horizontalSpeed = 0;
            ground.GetComponent<GroundController>().horizontalSpeed = 0;
            winText.enabled = true;
        }
    }
}
