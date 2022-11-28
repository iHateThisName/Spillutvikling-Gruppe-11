using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] Slider audioSlider;

    // Start is called before the first frame update
    void Start()
    {
       if(!PlayerPrefs.HasKey("musicVolume")) {
        PlayerPrefs.SetFloat("musicVolume", 1);
        Load();
       } 
       else
       {
        Load();
       }
    }

    public void Volum() 
    {
        AudioListener.volume = audioSlider.value;
        SaveVolum();
    }

    public void Load() {
        audioSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    public void SaveVolum() {
        PlayerPrefs.SetFloat("musicVolume", audioSlider.value);
    }
}

