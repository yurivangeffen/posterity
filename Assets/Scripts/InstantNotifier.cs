using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantNotifier : Notifier
{
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
    }

    public override void Check(float value)
    {
        // Check if we are over the threshold
        if (value >= threshold)
        {
            timer -= Time.deltaTime;
            // ...longer than allowed
            if (timer <= 0 && !isNotifying)
            {
                Notify();
            }
        }
        else
        {            
            // should we un-show the notification?
            if (timer < threshold && isNotifying)
            {
                UnNotify();
            }
            timer = thresholdTime;
        }
    }

	protected void Notify()
    {
        if (!isNotifying)
        {
            Debug.Log("Notifying...");
            isNotifying = true;
            Handheld.Vibrate();
            
            StartCoroutine(FadeIn());
        }
	}

    protected void UnNotify()
    {
        if(isNotifying && !isFading)
        {
            Debug.Log("Unnotifying...");
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
