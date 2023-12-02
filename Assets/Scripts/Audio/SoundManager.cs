using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the sound of the game.
/// 
/// </summary>
public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private Slider volumeSlider;

    /// <summary>
    ///  Changes the volume of the audio connected to the player.
    /// </summary>
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }
}
