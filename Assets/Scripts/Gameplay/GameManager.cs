using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public SceneManager sceneManager;

    public GameObject ui;

    public List<String> scenes;

    public bool allowPauseGame = true;
    private bool isPaused = false;

    // Update is called once per frame
    void Update()
    {

        if (allowPauseGame && Input.GetKeyDown(KeyCode.Escape))
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
        else if (!allowPauseGame)
        {
            Time.timeScale = 1f;
            ui.SetActive(true);

            // Turns on post-processing
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

    /// <summary>
    /// Quits the game
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("Level1");

    }


}
