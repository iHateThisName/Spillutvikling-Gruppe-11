using UnityEngine;

/// <summary>
/// This class is responsible for fading UI elements.
/// </summary>
public class UIFadeOut : MonoBehaviour
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
    [SerializeField] private bool fadeOut;

    [Tooltip("The fade amount to use. Higher value increases the fade amount")]
    public float timeToFade;
    
    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    private void Update()
    {
        if (fadeOut)
        {
            FadeOut();
        }
    }
    
    /// <summary>
    /// Runs when the script is enabled.
    /// </summary>
    void OnEnable()
    {
        if (fadeOut)
        {
            canvasGroup.alpha = maxFade;
            FadeOut();
        }
    }
    
    /// <summary>
    /// Fades out the UI element. 
    /// </summary>
    public void FadeOut()
    {
        if (fadeOut)
        {
            if (canvasGroup.alpha >= minFade)
            {
                canvasGroup.alpha -= timeToFade * Time.deltaTime;
                if (canvasGroup.alpha == minFade)
                {
                    fadeOut = false;
                }
            }
        }
    }
}