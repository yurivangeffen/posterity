using System;
using System.Text;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UploadScript : MonoBehaviour {

	public Text hashText = null;
	private string hashHex;

	public void Start()
	{
		hashHex = string.Format("{0:X2}", DateTime.Now.Ticks.ToString().GetHashCode());
		hashText.text = "Code: " + hashHex;
	}

	public void OnUploadClicked()
	{
		UploadData();
	}

	private void UploadData()
	{
		//email Id to send the mail to
		string email = "posterityuu@gmail.com";
		//subject of the mail
		string subject = EscapeString(string.Format("data_" + OrientationLogger.dataType + "_{0}", hashHex));
		//body of the mail which consists of Device Model and its Operating System
		string body = EscapeString(GetDataString());
		//Open the Default Mail App
		Application.OpenURL ("mailto:" + email + "?subject=" + subject + "&body=" + body);
	}

	private string GetDataString()
	{
		string csv = "Time;Angle";
		Dictionary<float, float> dict = new Dictionary<float, float>(OrientationLogger.readData);
        Dictionary<float, float> dict2 = new Dictionary<float, float>(OrientationLogger.writeData);
	
		foreach (KeyValuePair<float,float> item in dict)
		{
			csv += "\n" + item.Key + ";" + item.Value;
        }
        csv += "\n";

        foreach (KeyValuePair<float, float> item in dict2)
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
