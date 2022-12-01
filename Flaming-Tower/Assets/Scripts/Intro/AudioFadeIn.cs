using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFadeIn : MonoBehaviour
{
    [Header("Audio Settings")]
    [Tooltip("The audio source that shall be faded")]
    [SerializeField] private AudioSource audioSource;
    [Tooltip("Defines if the audio still have to be faded")]
    [SerializeField] private bool fadeIn;
    [Tooltip("Defines the maximum volume to be used")]
    [SerializeField] private float maxVolume = 1f;
    [Tooltip("Defines the minimum volume to be used")]
    [SerializeField] private float minVolume = 0f;
    [Tooltip("The fade amount to use. Higher value increases the fade amount")]
    public float timeToFade;
    
    /// <summary>
    /// Sets the max volume
    /// </summary>
    /// <param name="volume"></param>
    public void setMaxVolume(float volume)
    {
        maxVolume = volume;
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
    /// Runs when the script is enabled.
    /// </summary>
    void OnEnable()
    {
        audioSource.volume = minVolume;
        FadeIn();
    }

    /// <summary>
    /// Fades in the sound. 
    /// </summary>
    public void FadeIn()
    {
        if (fadeIn)
        {
            if (audioSource.volume < maxVolume)
            {
                audioSource.volume += timeToFade * Time.deltaTime;
                if (audioSource.volume >= maxVolume)
                {
                    fadeIn = false;
                }
            }
        }
    }
}