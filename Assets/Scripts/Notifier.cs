using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notifier : MonoBehaviour
{
    public float coolDownTime;
    public float thresholdTime;
    public float timer;
    protected float threshold;

	public virtual void Start()
    {
        coolDownTime = 5.0f;
        thresholdTime = 2.0f;
        timer = thresholdTime;
        threshold = 50f;
	}
	
	public virtual void Check(float value)
    {
    }
}
