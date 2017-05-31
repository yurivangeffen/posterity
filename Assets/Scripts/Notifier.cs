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

	// Use this for initialization
	public virtual void Start()
    {
        coolDownTime = 5.0f;
        thresholdTime = 2.0f;
        timer = thresholdTime;
        threshold = 50f;
	}
	
	// Update is called once per frame
	public virtual void Check(float value)
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

    protected virtual void Notify()
    {
    }

    protected virtual void UnNotify()
    {
    }
}
