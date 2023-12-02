using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

/// <summary>
/// Class for managing the gamestate.  
///
/// </summary>
public class GameManager : MonoBehaviour
{
    public GameObject UI;
    public bool allowPauseGame = true;
    private bool isPaused = false;

    // Update is called once per frame
    void Update()
    {
        CheckPauseGame();
    }

    /// <summary>
    ///  Checks if player intends to pause the game and does if allowed.
    ///
    /// </summary>
    private void CheckPauseGame()
    {
        if (allowPauseGame && Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseGame();
        }

        if (isPaused)
        {
            Time.timeScale = 0f;
            UI.SetActive(true);

            // Turns off post-processing
            Camera.main.gameObject.GetComponent<PostProcessVolume>().enabled = true;


        }
        else if (!allowPauseGame)
        {
            Time.timeScale = 1f;
            UI.SetActive(true);

            // Turns on post-processing
            Camera.main.gameObject.GetComponent<PostProcessVolume>().enabled = true;
        }
        else
        {
            Time.timeScale = 1f;
            UI.SetActive(false);

            // Turns on post-processing
            Camera.main.gameObject.GetComponent<PostProcessVolume>().enabled = false;
        }
    }

    /// <summary>
    /// Toggles the pause of the game
    /// 
    /// </summary>
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



}
