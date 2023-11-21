using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class for managing levels. 
/// 
/// Based on template from 2D Platformer Project
/// https://www.coursera.org/learn/game-design-and-development-2/home/week/1
/// </summary>
public static class LevelManager
{
    /// <summary>
    /// Description:
    /// Loads a scene by name
    /// Input:
    /// string sceneName
    /// Return:
    /// void (no return)
    /// </summary>
    /// <param name="sceneName">The name of the scene to be loaded</param>
    public static void LoadScene(string sceneName)
    {
        // Ensures the game is unpaused
        Time.timeScale = 1;

        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// Description:
    /// Loads the Menu scene
    /// Input:
    /// none
    /// Return:
    /// void (no return)
    /// </summary>
    public static void LoadMenuScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
