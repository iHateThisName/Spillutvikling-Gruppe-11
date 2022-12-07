using UnityEngine;

/**
 * This class is responsible for adjusting the audio.
 */
public class AudioAdjust : MonoBehaviour
{
    [Header("Audio Settings")]
    [Tooltip("The audio source to be adjusted")]
    [SerializeField] private AudioSource audioSource;

    /// <summary>
    /// Reads the music volume on awake
    /// </summary>
    private void Awake()
    {
        ReadMusicVolume();
    }

    /// <summary>
    /// Checks if there is a saved music volume.
    /// If not, one will be created.
    /// If exist sets the adui slider position and volume based on the volume read.l
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
    
    /**
     * Sets the default music volume.
     */
    private void SetDefaultMusicVolume()
    {
        PlayerPrefs.SetFloat("musicVolume", 1);
    }
}
