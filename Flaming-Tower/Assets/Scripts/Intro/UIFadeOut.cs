using UnityEngine;

public class UIFadeOut : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float maxFade = 1f;
    [SerializeField] private float minFade = 0f;
    [SerializeField] private bool fadeOut;

    public float timeToFade;

    private void Update()
    {
        if (fadeOut)
        {
            FadeOut();
        }
    }

    void OnEnable()
    {
        canvasGroup.alpha = maxFade;
        if (fadeOut)
        {
            FadeOut();
        }
    }

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