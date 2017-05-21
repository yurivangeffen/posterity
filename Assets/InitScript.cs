using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitScript : MonoBehaviour {

	public Text resultText;

	private float logInterval = 0.5f;
	private float lastLogTime = 0;
	private float lastLoggedValue = 0f;
		
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
}
