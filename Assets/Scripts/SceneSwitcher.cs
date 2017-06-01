using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{
    public void DoneIntro()
    {
        Application.LoadLevel("InitScene");
    }

    public void DoneIntermission()
    {
        Application.LoadLevel("WritingScene");
    }
}
