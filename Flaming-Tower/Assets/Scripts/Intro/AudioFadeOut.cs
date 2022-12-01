using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFadeOut : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private bool fadeOut;
    [SerializeField] private float maxVolume = 1f;
    [SerializeField] private float minVolume = 0f;
    public float timeToFade;

    public void setMaxVolume(float volume)
    {
        maxVolume = volume;
    }

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

    void OnEnable()
    {
        audioSource.volume = maxVolume;
        setMaxVolume();
        FadeOut();
    }

    public void FadeOut()
    {
        if (fadeOut)
        {
            if (audioSource.volume >= minVolume)
            {
                audioSource.volume -= timeToFade * Time.deltaTime;
                if (audioSource.volume == minVolume)
                {
                    fadeOut = false;
                }
            }
        }
    }
}