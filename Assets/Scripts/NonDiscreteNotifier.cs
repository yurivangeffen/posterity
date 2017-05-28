using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NonDiscreteNotifier : Notifier
{
    AndroidJavaObject currentActivity;
    string toastMessage;

	// Use this for initialization
	public override void Start()
    {
        base.Start();
        coolDownTime = 6.0f;
    }

	// Update is called once per frame
	protected override void Notify()
    {
        Handheld.Vibrate();
        //TODO: Make a custom popup and decide on how it appears/disappears
	}
}
