using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GradualNotifier : Notifier
{
    public float alphaSpeed;
    public Text text;
    public bool isExceeded;

	// Use this for initialization
	public override void Start()
    {
        base.Start();
        isExceeded = false;
	}
	
    void Update()
    {
        Color color = text.color;
        float alpha = color.a + (isExceeded ? -alphaSpeed : alphaSpeed) * Time.deltaTime;
        text.color = new Color(color.r, color.g, color.b, alpha); 
    }
    
	protected override void Notify()
    {
        isExceeded = true;
	}

    protected override void UnNotify()
    {
        isExceeded = false;
    }
}
