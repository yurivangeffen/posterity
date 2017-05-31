using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TestScript : MonoBehaviour {

	public OrientationLogger logger;
	public Text text;

	public float interval = 0.5f;
	public float lastCheck = 0;

	public float lowerVisibleBound = 30;

    public Notifier notifier;

	// Use this for initialization
	public void Start () {
		if (logger != null)
		{
            switch(OrientationLogger.dataType)
            {
                case "discrete":
                    notifier = gameObject.AddComponent<DiscreteNotifier>();
                    break;
                case "non_discrete":
                default:
                    notifier = gameObject.AddComponent<NonDiscreteNotifier>();
                    break;
            }
            logger.StartLogging();
		}
	}

    // Update is called once per frame
    public void Update()
    {
        if (Time.time - lastCheck >= interval && text != null && logger != null)
        {
            float c = 1f - (Mathf.Clamp(OrientationLogger.CurrentOrientation() - lowerVisibleBound, 0f, 90f - lowerVisibleBound) / (90f - lowerVisibleBound));
            text.color = new Color(c, c, c, 1f);
            lastCheck = Time.time;
        }
        if (notifier != null)
        {
            notifier.Check(OrientationLogger.CurrentOrientation());
        }
    }

	public void DoneReading()
	{
		logger.StopLogging();
        if (Application.loadedLevelName == "TestScene")
            Application.LoadLevel("IntermissionScene");
        else
            Application.LoadLevel("FinishedScene");
	}
}
