using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TestScript : MonoBehaviour {

	public OrientationLogger logger;
	public Text text;

	public float interval = 0.5f;
	public float lastCheck = 0;

	public float lowerVisibleBound = 30;

	// Use this for initialization
	public void Start () {
		if (logger != null)
		{
			logger.StartLogging();
		}
	}
	
	// Update is called once per frame
	public void Update () {
		if (Time.time - lastCheck >= interval && text != null && logger != null)
		{
            float c = 1f - (Mathf.Clamp(OrientationLogger.CurrentOrientation() - lowerVisibleBound, 0f, 90f - lowerVisibleBound) / (90f - lowerVisibleBound));
            text.color = new Color(c,c,c,1f);
			lastCheck = Time.time;
		}
	}

	public void DoneReading()
	{
		logger.StopLogging();
    	Application.LoadLevel("FinishedScene");
	}
}
