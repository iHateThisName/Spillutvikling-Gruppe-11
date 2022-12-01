using UnityEngine;

public class UIFadeIn : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float maxFade = 1f;
    [SerializeField] private float minFade = 0f;
    [SerializeField] private bool fadeIn;

    public float timeToFade;
    public float timeToChangeScene;

    private void Update()
    {
        if (fadeIn)
        {
            FadeIn();
        }
    }

    void OnEnable()
    {
        if (fadeIn)
        {
            canvasGroup.alpha = minFade;
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