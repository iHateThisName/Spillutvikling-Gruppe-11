using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFadeIn : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private bool fadeIn;
    [SerializeField] private float maxVolume = 1f;
    [SerializeField] private float minVolume = 0f;
    public float timeToFade;

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

    void OnEnable()
    {
        audioSource.volume = minVolume;
        FadeIn();
    }

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