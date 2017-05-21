using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TestScript : MonoBehaviour {

	public OrientationLogger logger;
	public Text text;

	public float interval = 0.5f;
	public float lastCheck = 0;

	public float lowerBound = 20f;

	// Use this for initialization
	public void Start () {
		if (logger != null)
		{
			logger.StartLogging();
		}
        if(!SystemInfo.supportsGyroscope)
        {
            lowerBound = 0.6f;
        }
	}
	
	// Update is called once per frame
	public void Update () {
		if (Time.time - lastCheck >= interval && text != null && logger != null)
		{
            float c = 1f - (Mathf.Clamp(logger.CurrentOrientation() - lowerBound, 0f, 80f - lowerBound) / (80f - lowerBound));
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
