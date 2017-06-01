using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TestScript : MonoBehaviour {

	public OrientationLogger logger;
	public float interval = 0.5f;
	public float lastCheck = 0;

    public GradualNotifier gradualNotifier;
    public InstantNotifier instantNotifier;

    private Notifier notifier;

	// Use this for initialization
	public void Start () {
		if (logger != null)
		{
            switch(OrientationLogger.dataType)
            {
                case "gradual":
                    notifier = gradualNotifier;
                    Destroy(instantNotifier);
                    break;
                case "instant":
                default:
                    notifier = instantNotifier;
                    Destroy(gradualNotifier);
                    break;
            }
            notifier.enabled = true;
            logger.StartLogging();
		}
	}

    // Update is called once per frame
    public void Update()
    {
        if (notifier != null)
        {
            notifier.Check(OrientationLogger.CurrentOrientation(false));
        }
    }

	public void DoneReading()
	{
		logger.StopLogging();
        Application.LoadLevel("IntermissionScene");
	}
	public void DoneWriting()
	{
		logger.StopLogging();
        Application.LoadLevel("FinishedScene");
	}
}
