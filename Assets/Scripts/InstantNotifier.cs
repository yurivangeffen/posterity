using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantNotifier : Notifier
{
    AndroidJavaObject currentActivity;
    string toastMessage;

	public override void Start()
    {
        base.Start();
        coolDownTime = 6.0f;
    }

    public override void Check(float value)
    {
        timer -= Time.deltaTime;
        if (value > threshold)
        {
            timer = Mathf.Max(thresholdTime, timer);
        }
        else
        {            
            if (timer <= 0)
            {
                timer += coolDownTime;
                Notify();
            }
        }
    }

	protected void Notify()
    {
        Handheld.Vibrate();
        //TODO: Make a custom popup and decide on how it appears/disappears
	}
}
