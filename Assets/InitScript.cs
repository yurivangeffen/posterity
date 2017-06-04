using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitScript : MonoBehaviour {

	public Text resultText;
	public Text vertText;
	public Text horText;
	public Dropdown testType;
	public GameObject gradualRange;
	public GameObject instantThreshold;
	public GameObject instantDelay;

	private float logInterval = 0.5f;
	private float lastLogTime = 0;
	private float lastLoggedValue = 0f;

	private float verticalCalibration;
	private float horizontalCalibration;
		

	public void Start()
	{
		gradualRange.transform.GetComponentInChildren<InputField>().text = ((int)GradualNotifier.upperVisibleRange).ToString();
		instantThreshold.transform.GetComponentInChildren<InputField>().text = ((int)InstantNotifier.threshold).ToString();
		instantDelay.transform.GetComponentInChildren<InputField>().text = ((int)InstantNotifier.thresholdTime).ToString();
	}

	// Update is called once per frame
	void Update () {
		// Set the right UI.

		gradualRange.SetActive(testType.value == 0);
		instantThreshold.SetActive(testType.value == 1);
		instantDelay.SetActive(testType.value == 1);


		if (Time.time - lastLogTime >= logInterval)
		{
			lastLoggedValue = OrientationLogger.CurrentOrientation(false);
			resultText.text = "Roll-angle: " + lastLoggedValue.ToString();
			lastLogTime = Time.time;
		}
	}

	public void OnStartTestClicked()
	{
		OrientationLogger.dataType = testType.value == 0 ? "gradual" : "instant";
		GradualNotifier.upperVisibleRange = int.Parse(gradualRange.transform.GetComponentInChildren<InputField>().text);
		InstantNotifier.threshold = int.Parse(instantThreshold.transform.GetComponentInChildren<InputField>().text);
		InstantNotifier.thresholdTime = float.Parse(instantDelay.transform.GetComponentInChildren<InputField>().text);

    	Application.LoadLevel("IntroductionScene");
	}

	public void OnCalibrateVertical()
	{
		verticalCalibration = Calibrate(20, 0.1f);
		OrientationLogger.verticalCalibrationBound = verticalCalibration;
		vertText.text = "Vertical: " + verticalCalibration.ToString();
	}

	public void OnCalibrateHorizontal()
	{
		horizontalCalibration = Calibrate(20, 0.1f);
		OrientationLogger.horizontalCalibrationBound = horizontalCalibration;
		horText.text = "Horizontal: " + horizontalCalibration.ToString();
	}

	// Ugly calibration
	private float Calibrate(int measurements, float intervalSeconds)
	{
		System.Threading.Thread.Sleep(1000);
		float calibration = 0f;
		for (int i = 0; i < measurements; i++)
		{
			calibration += OrientationLogger.CurrentOrientation(false)/measurements;
			System.Threading.Thread.Sleep((int)intervalSeconds * 1000);
		}
		return calibration;
	}
}
