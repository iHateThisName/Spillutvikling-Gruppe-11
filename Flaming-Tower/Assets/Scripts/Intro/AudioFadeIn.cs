using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for fading in the audio.
/// </summary>
public class AudioFadeIn : MonoBehaviour
{
    [Header("Audio Settings")] [Tooltip("The audio source to be adjusted")] [SerializeField]
    private AudioSource audioSource;

    [Tooltip("Audio will only be faded in if this is toggled")] [SerializeField]
    private bool fadeIn;

    [Tooltip("The maximum volume to be used.")] [SerializeField]
    private float maxVolume = 1f;

    [Tooltip("The minimum volume to be used.")] [SerializeField]
    private float minVolume = 0f;

    [Tooltip("The force to be applied to the fading.")]
    public float fadeForce = 0.2f;

    /// <summary>
    /// Sets the maximum volume.
    /// </summary>
    /// <param name="volume"></param>
    public void setMaxVolume(float volume)
    {
        maxVolume = volume;
    }

    /// <summary>
    /// Sets the maximum value based on the audio slider
    /// in the options screen set by the player 
    /// </summary>
    public void setMaxVolume()
    {
        maxVolume = PlayerPrefs.GetFloat("musicVolume");
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeIn)
        {
            FadeIn();
        }
    }
    

    /// <summary>
    /// Sets the current audio source volume to minimum
    /// value and reads the volume from the audio volume slider.
    /// </summary>
    void OnEnable()
    {
        audioSource.volume = minVolume;
        setMaxVolume();
    }

    /// <summary>
    /// Fades in the audio volume
    /// </summary>
    public void FadeIn()
    {
        if (fadeIn)
        {
            if (audioSource.volume < maxVolume)
            {
                audioSource.volume += fadeForce * Time.deltaTime;
                if (audioSource.volume >= maxVolume)
                {
                    fadeIn = false;
                }
            }
        }
    }
}