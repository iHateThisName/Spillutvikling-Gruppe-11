using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFadeOut : MonoBehaviour
{
    
    [Header("Audio Settings")] [Tooltip("The audio source to be adjusted")]
    [SerializeField] private AudioSource audioSource;

    [Tooltip("Audio will only be faded out if this is toggled")] 
    [SerializeField]private bool fadeOut;
    [Tooltip("The maximum volume to be used.")]
    [SerializeField] private float maxVolume = 1f;
    [Tooltip("The minimum volume to be used.")]
    [SerializeField] private float minVolume = 0f;
    public float fadeForce;

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
        if (fadeOut)
        {
            FadeOut();
        }
    }

    /// <summary>
    /// Sets the current audio source volume to minimum
    /// value and reads the volume from the audio volume slider.
    /// </summary>
    void OnEnable()
    {
        audioSource.volume = maxVolume;
        setMaxVolume();
        FadeOut();
    }

    /// <summary>
    /// Fades out the audio volume
    /// </summary>
    public void FadeOut()
    {
        if (fadeOut)
        {
            if (audioSource.volume >= minVolume)
            {
                audioSource.volume -= fadeForce * Time.deltaTime;
                if (audioSource.volume == minVolume)
                {
                    fadeOut = false;
                }
            }
        }
    }
}