using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;


public class OrientationLogger : MonoBehaviour {

	// Used to save the logged data.
	public static float verticalCalibrationBound, horizontalCalibrationBound;
	public static Dictionary<float,float> readData;
    public static Dictionary<float, float> writeData;
	public static string dataType;

	public float logInterval = 0.5f;

	private bool isLogging = false;
	private float lastLogTimeNormalized = 0f;
	private float lastLogTime = 0f;

	public float LastLogTimeNormalized
	{
		get
		{
			return lastLogTimeNormalized;
		}
	}

	public void StartLogging()
	{
        if(readData == null)
		    readData = new Dictionary<float,float>();
        if(writeData == null)
            writeData = new Dictionary<float, float>();
		isLogging = true;
		Input.gyro.enabled = true;
		lastLogTimeNormalized = 0f;
		lastLogTime = Time.time;
		LogData();
	}

	public void StopLogging()
	{
		isLogging = false;
		UploadScript.NextTest();
    }

	static public float CurrentOrientation(bool calibrated = true)
	{	
		float roll = Mathf.Atan2(Input.acceleration.y, Input.acceleration.z) * 180 / Mathf.PI;		
		float xOrientation = Mathf.Abs(roll) - 90f;

		if (calibrated)
		{
			//Bound
			xOrientation = Mathf.Clamp(xOrientation, verticalCalibrationBound, horizontalCalibrationBound);

			//Range 0-90
			xOrientation = ((xOrientation-verticalCalibrationBound) / (horizontalCalibrationBound-verticalCalibrationBound)) * 90f;
		}


		return xOrientation;
	}
	
	private void LogData()
	{
		float xOrientation = CurrentOrientation();

		Debug.Log(lastLogTimeNormalized + ": " + xOrientation);
        if (Application.loadedLevelName == "WritingScene")
        {
            Debug.Log("WriteData added");
            writeData.Add(lastLogTimeNormalized, xOrientation);
        }
        else
        {
            Debug.Log("ReadData added");
            readData.Add(lastLogTimeNormalized, xOrientation);
        }
	}

	// Update is called once per frame
	public void Update () {
		if (isLogging && Time.time - lastLogTime >= logInterval)
		{
			lastLogTimeNormalized += logInterval;
			lastLogTime = Time.time;
			LogData();
		}
	}
}
