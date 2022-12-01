using UnityEngine;

/// <summary>
/// This class is responsible for fading UI elements.
/// </summary>
public class UIFadeIn : MonoBehaviour
{
    [Header("UI Settings")]
    [Tooltip("The UI element that shall be faded")]
    [SerializeField] private CanvasGroup canvasGroup;
    [Tooltip("The maximum fade" +
             "1 is fully visible" +
             "0 is fully faded and is invisible")]
    [SerializeField] private float maxFade = 1f;
    [Tooltip("The minimum fade" +
             "1 is fully visible" +
             "0 is fully faded and is invisible")]
    [SerializeField] private float minFade = 0f;
    [Tooltip("Defines if the UI element still have to be faded")]
    [SerializeField] private bool fadeIn;
    [Tooltip("The fade amount to use. Higher value increases the fade amount")]
    public float timeToFade;
    
    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    private void Update()
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
        if (fadeIn)
        {
            canvasGroup.alpha = minFade;
            FadeIn();
        }
    }
    
    /// <summary>
    /// Fades out the UI element. 
    /// </summary>
    public void FadeIn()
    {
        if (fadeIn)
        {
            if (canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += timeToFade * Time.deltaTime;
                if (canvasGroup.alpha >= maxFade)
                {
                    fadeIn = false;
                }
            }
        }
    }
}