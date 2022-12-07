using UnityEngine;

/// <summary>
/// This class is responsible for fading in canvases.
/// </summary>
public class UIFadeIn : MonoBehaviour
{
    [Header("Fade Settings")] 
    [Tooltip("The canvas to be faded. Must have 'Canvas Group' as a component to the canvas to be faded.")] 
    [SerializeField]
    private CanvasGroup canvasGroup;
    [Tooltip("Maximum fading at the highest. 1f equals 100% visibility.")] 
    private float maxFade = 1f;
    [Tooltip("Minimum fading at the lowest. 0f equals 0% visibility.")] 
    private float minFade = 0f;
    [Tooltip("Canvases will only be faded in if this is toggled.")] 
    [SerializeField] 
    private bool fadeIn;
    [Tooltip("The force to be applied to he fading.")] 
    public float fadeForce;


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
    /// Sets the alpha to the minFade value. This defines whats the lowest visibility amount.
    /// Also starts fading in.
    /// </summary>
    void OnEnable()
    {
        canvasGroup.alpha = minFade;
        if (fadeIn)
        {
            FadeIn();
        }
    }


    /// <summary>
    /// Fades in the canvas until it reaches the maximum fade value specified by maxFade.
    /// </summary>
    public void FadeIn()
    {
        if (fadeIn)
        {
            if (canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += fadeForce * Time.deltaTime;
                if (canvasGroup.alpha >= maxFade)
                {
                    fadeIn = false;
                }
            }
        }
    }
}