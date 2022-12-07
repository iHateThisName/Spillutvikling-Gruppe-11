using UnityEngine;

/// <summary>
/// This class is responsible for adjusting the audio
/// </summary>
public class AudioAdjust : MonoBehaviour
{
    [Header("Audio Settings")] [Tooltip("The audio source to be adjusted")] [SerializeField]
    private AudioSource audioSource;

    /// <summary>
    /// Reads the music volume on awake
    /// </summary>
    private void Awake()
    {
        ReadMusicVolume();
    }

    /// <summary>
    /// checks if there is a saved music volume.
    /// if not one will be created.
    /// if exist sets the audio slider position based on the volume read.
    /// </summary>
    private void ReadMusicVolume()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            SetDefaultMusicVolume();
        }

        Debug.Log("AudioSource Volume: " + PlayerPrefs.GetFloat("musicVolume"));
        audioSource.volume = PlayerPrefs.GetFloat("musicVolume");
    }

    /// <summary>
    /// Sets the default music volume
    /// </summary>
    private void SetDefaultMusicVolume()
    {
        PlayerPrefs.SetFloat("musicVolume", 1);
    }
}