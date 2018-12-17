using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GeoUnityService : GeoService
{
    private float[] currentLocation;
    private bool tracking;

    public float CurrentHeading()
    {
        return Input.compass.trueHeading;
    }

    public void RequestLocationTracking(MonoBehaviour behaviour)
    {
        if (!tracking)
        {
            behaviour.StartCoroutine(StartLocationTracking());
        }
    }

    public float[] CurrentLocation()
    {
        return new float[] { Input.location.lastData.latitude, Input.location.lastData.longitude };
    }

    public bool IsTracking()
    {
        return tracking;
    }

    IEnumerator StartLocationTracking()
    {
        Input.compass.enabled = true;
        Input.location.Start();

        // Give service time to fire up
        int waitTime = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && waitTime > 0)
        {
            waitTime--;
            yield return new WaitForSeconds(1);
        }

        if (waitTime < 1)
        {
            // Timed out
            Debug.Log("Location service timed out");
        }
        else if (Input.location.status == LocationServiceStatus.Failed)
        {
            // Straight up failed
            Debug.Log("Location service unable to determine location");
        }
        else
        {
            // All good - we're tracking now
            tracking = true;
        }
    }
}
