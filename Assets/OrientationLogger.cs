using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class OrientationLogger : MonoBehaviour {

	// Used to save the logged data.
	public static Dictionary<float,float> data;
	public static string dataType;

	public float logInterval = 0.5f;
	[Range(1.0f, 360.0f)]
	public float testOrientation = 180f;

	private bool isLogging = false;
	private float lastLogTimeNormalized = 0;

	public void StartLogging()
	{
		dataType = "non_discrete";
		data = new Dictionary<float,float>();
		isLogging = true;
		Input.gyro.enabled = true;
		lastLogTimeNormalized = 0f;
		LogData();
	}

	public void StopLogging()
	{
		isLogging = false;
	}

	public float CurrentOrientation()
	{	
		float xOrientation = 0;
		if(!SystemInfo.supportsAccelerometer)
		{
			xOrientation = testOrientation;
		}
		else
		{
			xOrientation = Input.gyro.attitude.eulerAngles.x;
		}

		return xOrientation;
	}
	
	private void LogData()
	{
		float xOrientation = CurrentOrientation();
		Debug.Log(lastLogTimeNormalized + ": " + xOrientation);
		data.Add(lastLogTimeNormalized, xOrientation);
	}

	// Update is called once per frame
	public void Update () {
		if (isLogging && Time.time - lastLogTimeNormalized >= logInterval)
		{
			lastLogTimeNormalized += logInterval;
			LogData();
		}
	}
}
