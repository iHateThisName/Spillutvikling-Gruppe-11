using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] public Slider audioSlider;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void Volum() 
    {
        AudioListener.volume = audioSlider.value;
        SaveVolum();
    }

    public void Load() {
        float storedVolume = PlayerPrefs.GetFloat("musicVolume");
        AudioListener.volume = storedVolume;
        audioSlider.value = storedVolume;
    }

    public void SaveVolum() {
        AudioListener.volume = audioSlider.value;
        PlayerPrefs.SetFloat("musicVolume", audioSlider.value);
    }
}

