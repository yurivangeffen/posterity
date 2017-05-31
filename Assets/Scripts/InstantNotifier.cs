using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantNotifier : Notifier
{
    public float coolDownTime = 6f;
    public float thresholdTime = 2.0f;
    public float timer;
    protected float threshold;

    public CanvasGroup toastCanvasGroup;
    public float fadeSeconds = 1f;

    private bool isNotifying = false;
    private bool isFading = false;

	public void Start()
    {
        toastCanvasGroup.alpha = 0f;

        timer = thresholdTime;
        threshold = 50f;
    }

    public override void Check(float value)
    {
        if (value > threshold)
        {
            timer -= Time.deltaTime;
        }
        else
        {            
            if (timer <= 0)
            {
                Notify();
                timer = thresholdTime;
            }
        }
    }

	protected void Notify()
    {
        if (!isNotifying)
        {
            isNotifying = true;
            Handheld.Vibrate();
            
            StartCoroutine(FadeIn());
        }
	}

    protected void UnNotify()
    {
        if(isNotifying && !isFading)
        {
            isNotifying = false;
            StartCoroutine(FadeOut());
        }
    }

    private IEnumerator FadeIn()
    {
        if(!isFading)
        {
            isFading = true;
            toastCanvasGroup.alpha = 0f;
            while(toastCanvasGroup.alpha < 1f)
            {
                toastCanvasGroup.alpha += fadeSeconds * Time.deltaTime;
                yield return null;
            }
            toastCanvasGroup.alpha = 1f;
            isFading = false;
        }
    }
    private IEnumerator FadeOut()
    {
        if(!isFading)
        {
            isFading = true;
            toastCanvasGroup.alpha = 1f;
            while(toastCanvasGroup.alpha > 0f)
            {
                toastCanvasGroup.alpha -= fadeSeconds * Time.deltaTime;
                yield return null;
            }
            toastCanvasGroup.alpha = 0f;
            isFading = false;
        }
    }
}
