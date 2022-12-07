using UnityEngine;

/// <summary>
/// This class is responsible for fading out canvases.
/// </summary>
public class UIFadeOut : MonoBehaviour
{
    [Header("Fade Settings")]
    [Tooltip("The canvas to be faded. Must have 'Canvas Group' as a component to the canvas to be faded.")]
    [SerializeField]
    private CanvasGroup canvasGroup;

    [Tooltip("Maximum fading at the highest. 1f equals 100% visibility.")]
    private float maxFade = 1f;

    [Tooltip("Minimum fading at the lowest. 0f equals 0% visibility.")]
    private float minFade = 0f;

    [Tooltip("Canvases will only be faded out if this is toggled.")] [SerializeField]
    private bool fadeOut;

    [Tooltip("The force to be applied to he fading.")]
    public float fadeForce;


    /// <summary>
    /// This method is called for every frame, as long as MonoBehaviour is being used.
    /// </summary>
    private void Update()
    {
        if (fadeOut)
        {
            FadeOut();
        }
    }

    /// <summary>
    /// Sets the alpha to the maxFade value. This defines whats the highest visibility amount.
    /// Also starts fading out.
    /// </summary>
    void OnEnable()
    {
        canvasGroup.alpha = maxFade;
        if (fadeOut)
        {
            FadeOut();
        }
    }


    /// <summary>
    /// Fades out the canvas until it reaches the maximum fade value specified by minFade.
    /// </summary>
    public void FadeOut()
    {
        if (fadeOut)
        {
            if (canvasGroup.alpha >= minFade)
            {
                canvasGroup.alpha -= fadeForce * Time.deltaTime;
                if (canvasGroup.alpha == minFade)
                {
                    fadeOut = false;
                }
            }
        }
    }
}