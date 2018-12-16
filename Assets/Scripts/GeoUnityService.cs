using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GeoUnityService : GeoService
{
    private float[] currentLocation;
    private bool requesting;

    public GeoUnityService()
    {
        Input.compass.enabled = true;
    }

    public float CurrentHeading()
    {
        return Input.compass.trueHeading;
    }

    public void RequestLocation(MonoBehaviour behaviour, Action callback)
    {
        behaviour.StartCoroutine(LocationAttempt(callback));
    }

    public float[] CurrentLocation()
    {
        return currentLocation;
    }

    IEnumerator LocationAttempt(Action callback)
    {
        requesting = true;

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
            // Got location
            if (currentLocation == null)
            {
                currentLocation = new float[2];
            }
            currentLocation[0] = Input.location.lastData.latitude;
            currentLocation[1] = Input.location.lastData.longitude;
        }

        // Stop continous location tracking
        Input.location.Stop();

        // Done here, do callback - data can be retrieved with CurrentLocation()
        callback();
    }
}
