﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroTextChanger : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        string text =  gameObject.GetComponent<Text>().text;
        string dataText = "";
        if (OrientationLogger.dataType == "gradual")
        {
            dataText = "For this experiment, you are assigned the one specific notification type: the <b> gradual notification.</b> <i> The content on the screen will "
                + "gradually fade and become less readable</i> when the smartphone has detected that your posture could be improved.";
        }
        else
        {
            dataText = "For this experiment, you are assigned the one specific notification type: the <b> instant notification.</b> <i> A notification will appear at "
                + "the top of the screen when</i> the smartphone has detected that your posture could be improved.";
        }
        gameObject.GetComponent<Text>().text = text.Replace("[DataText]", dataText);

    }
}
