using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] public Slider audioSlider;

    /// <summary>
    /// This method controls the volume for the game by using a slider.
    /// </summary>
    public void Volum() 
    {
        AudioListener.volume = audioSlider.value;
        SaveVolum();
    }

    /// <summary>
    /// Loads the volume.
    /// </summary>
    public void Load() {
        float storedVolume = PlayerPrefs.GetFloat("musicVolume");
        AudioListener.volume = storedVolume;
        audioSlider.value = storedVolume;
    }

    /// <summary>
    /// Saves the volume value from the slider.
    /// the volume slider can hold values between 1-0.
    /// </summary>
    public void SaveVolum() {
        AudioListener.volume = audioSlider.value;
        PlayerPrefs.SetFloat("musicVolume", audioSlider.value);
    }
}

