using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public SceneManager sceneManager;
    public GameObject ui;

    private bool isPaused = false;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseGame();
        }

        if (isPaused)
        {
            Time.timeScale = 0f;
            ui.SetActive(true);

            // Turns off post-processing
            Camera.main.gameObject.GetComponent<PostProcessVolume>().enabled = true;


        }
        else
        {
            Time.timeScale = 1f;
            ui.SetActive(false);

            // Turns on post-processing
            Camera.main.gameObject.GetComponent<PostProcessVolume>().enabled = false;
        }
    }

    public void TogglePauseGame()
    {
        isPaused = !isPaused;
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("Level1");

    }


}
