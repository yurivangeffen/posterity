using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GradualNotifier : Notifier
{
    public CanvasGroup text;
	public float upperVisibleRange = 30;

    public override void Check(float value)
    {
        float alpha = 1f - (Mathf.Clamp(value, 0f, upperVisibleRange) / (upperVisibleRange));
        text.alpha = alpha;
    }
}
