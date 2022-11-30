using UnityEngine;

public class UIFadeOut : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float maxFade = 1f;
    [SerializeField] private float minFade = 0f;
    [SerializeField] private bool fadeOut;

    public float timeToFade;
    public float timeToChangeScene;

    private void Update()
    {
        if (fadeOut)
        {
            FadeOut();
        }
    }

    void OnEnable()
    {
        if (fadeOut)
        {
            canvasGroup.alpha = maxFade;
            FadeOut();
        }
    }

    public void FadeOut()
    {
        if (fadeOut)
        {
            canvasGroup.alpha = maxFade;
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