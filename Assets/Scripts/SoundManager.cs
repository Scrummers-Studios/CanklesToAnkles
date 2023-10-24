using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Manages the sound of the game.
public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private Slider volumeSlider;

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }
}
