using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class SceneController : MonoBehaviour
{
    public NodeViewer nodeViewer;

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

        FindActivePlane();
    }

    void FindActivePlane()
    {
        TrackableHit hit;
        TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinBounds | TrackableHitFlags.PlaneWithinPolygon;

        if (Frame.Raycast(Screen.width / 2, Screen.height / 2, raycastFilter, out hit))
        {
            SelectPlane(hit.Trackable as DetectedPlane);
        }
    }

    void SelectPlane(DetectedPlane selectedPlane)
    {
        nodeViewer.SetSelectedPlane(selectedPlane);
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
