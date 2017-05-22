using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitScript : MonoBehaviour {

	public Text resultText;
	public Text vertText;
	public Text horText;

	private float logInterval = 0.5f;
	private float lastLogTime = 0;
	private float lastLoggedValue = 0f;

	private float verticalCalibration;
	private float horizontalCalibration;
		
	// Update is called once per frame
	void Update () {
		if (Time.time - lastLogTime >= logInterval)
		{
			lastLoggedValue = OrientationLogger.CurrentOrientation();
			resultText.text = "Roll-angle: " + lastLoggedValue.ToString();
			lastLogTime = Time.time;
		}
	}

	public void OnStartTestClicked()
	{
    	Application.LoadLevel("TestScene");
	}

	public void OnCalibrateVertical()
	{
		verticalCalibration = Calibrate(20, 0.1f);
		vertText.text = "Vertical: " + verticalCalibration.ToString();
	}

	public void OnCalibrateHorizontal()
	{
		horizontalCalibration = Calibrate(20, 0.1f);
		horText.text = "Horizontal: " + horizontalCalibration.ToString();
	}

	// Ugly calibration
	private float Calibrate(int measurements, float intervalSeconds)
	{
		System.Threading.Thread.Sleep(1000);
		float calibration = 0f;
		for (int i = 0; i < measurements; i++)
		{
			calibration += OrientationLogger.CurrentOrientation()/measurements;
			System.Threading.Thread.Sleep((int)intervalSeconds * 1000);
		}
		return calibration;
	}
}
