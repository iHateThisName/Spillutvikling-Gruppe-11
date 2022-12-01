using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAdjust : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    private void Awake()
    {
        ReadMusicVolume();
    }

    private void ReadMusicVolume()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            SetDefaultMusicVolume();
        }
        Debug.Log("AudioSource Volume: " + PlayerPrefs.GetFloat("musicVolume"));
        audioSource.volume = PlayerPrefs.GetFloat("musicVolume");
    }
    
    private void SetDefaultMusicVolume()
    {
        PlayerPrefs.SetFloat("musicVolume", 1);
    }
}
