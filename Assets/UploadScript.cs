using System;
using System.Text;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UploadScript : MonoBehaviour {

	public void OnUploadClicked()
	{
		UploadData();
	}

	private void UploadData()
	{
		//email Id to send the mail to
		string email = "posterityuu@gmail.com";
		//subject of the mail
		string subject = EscapeString("data_" + OrientationLogger.dataType + "_" + DateTime.Now.Ticks.ToString());
		//body of the mail which consists of Device Model and its Operating System
		string body = EscapeString(GetDataString());
		//Open the Default Mail App
		Application.OpenURL ("mailto:" + email + "?subject=" + subject + "&body=" + body);
	}

	private string GetDataString()
	{
		string csv = "Time;Angle";
		Dictionary<float, float> dict = new Dictionary<float, float>(OrientationLogger.data);
	
		foreach (KeyValuePair<float,float> item in dict)
		{
			csv += "\n" + item.Key + ";" + item.Value;
		}

		return csv;
	}

	string EscapeString(string str)
	{
		return WWW.EscapeURL(str).Replace("+","%20");
	}
}
