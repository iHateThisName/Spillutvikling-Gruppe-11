using UnityEngine;

public class UIFadeIn : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float maxFade = 1f;
    [SerializeField] private float minFade = 0f;
    [SerializeField] private bool fadeIn;

    public float timeToFade;

    private void Update()
    {
        if (fadeIn)
        {
            FadeIn();
        }
    }

    void OnEnable()
    {
        canvasGroup.alpha = minFade;
        if (fadeIn)
        {
            FadeIn();
        }
    }

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