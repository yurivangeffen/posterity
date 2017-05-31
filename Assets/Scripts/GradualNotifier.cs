using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GradualNotifier : Notifier
{
    public Text text;
	public float lowerVisibleBound = 30;

    public override void Check(float value)
    {
        float alpha = 1f - (Mathf.Clamp(value - lowerVisibleBound, 0f, 90f - lowerVisibleBound) / (90f - lowerVisibleBound));
        text.color = new Color(0f, 0f, 0f, alpha);
    }
}
