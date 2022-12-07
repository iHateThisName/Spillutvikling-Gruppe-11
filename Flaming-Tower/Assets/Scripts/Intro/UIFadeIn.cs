using UnityEngine;

public class UIFadeIn : MonoBehaviour
{
    [Header("Fade Settings")]
    [Tooltip("The canvas to be faded. Must have 'Canvas Group' as a component to the canvas to be faded.")]
    [SerializeField]
    private CanvasGroup canvasGroup;

    [Tooltip("Maximum fading at the highest. 1f equals 100% visibility.")] [SerializeField]
    private float maxFade = 1f;

    [Tooltip("Minimum fading at the highest. 0f equals 0% visibility.")] [SerializeField]
    private float minFade = 0f;

    [Tooltip("Canvas will only be faded in if this is toggled.")] [SerializeField]
    private bool fadeIn;

    [Tooltip("The force to be applied to the fading")]
    public float fadeForce = 0.2f;

    /// <summary>
    /// This method is called for every frame, as long as MonoBehaviour is being used.
    /// </summary>
    private void Update()
    {
        if (fadeIn)
        {
            FadeIn();
        }

    }

    /// <summary>
    /// Sets the alhpa to minFade value. This defines whats the highest visibility amount.
    /// Also starts fading out.
    /// </summary>
    void OnEnable()
    {
        canvasGroup.alpha = minFade;
    }

    /// <summary>
    /// Fades in the canvas until it reaches the maximum fade value specified by maxFade.
    /// </summary>
    public void FadeIn()
    {
        if (canvasGroup.alpha < maxFade)
        {
            canvasGroup.alpha += fadeForce * Time.deltaTime;
            if (canvasGroup.alpha >= maxFade)
            {
                fadeIn = false;
            }
        }
    }
}