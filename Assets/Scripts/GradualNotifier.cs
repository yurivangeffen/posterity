using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GradualNotifier : Notifier
{
    public Text text;
	public float upperVisibleRange = 30;

    public override void Check(float value)
    {
        float alpha = 1f - (Mathf.Clamp(value - upperVisibleRange, 0f, 90f - upperVisibleRange) / (90f - upperVisibleRange));
        text.color = new Color(0f, 0f, 0f, alpha);
    }
}
