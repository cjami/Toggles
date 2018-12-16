using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class SceneController : MonoBehaviour
{
    void Start()
    {
        QuitOnConnectionErrors();
    }

    void Update()
    {
        // The session status must be tracking in order to access the frame
        if (Session.Status != SessionStatus.Tracking)
        {
            int lostTime = 15;
            Screen.sleepTimeout = lostTime;
            return;
        }

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    private void QuitOnConnectionErrors()
    {
        if (Session.Status == SessionStatus.ErrorPermissionNotGranted)
        {
            Debug.Log("Camera permission needed");
        }
        else if (Session.Status.IsError())
        {
            Debug.Log("ARCore error");
        }
    }
}
