using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeoDummyService : GeoService
{
    public float CurrentHeading()
    {
        return 0f;
    }

    public float[] CurrentLocation()
    {
        return new float[]{1, 1};
    }

    public bool IsTracking()
    {
        return true;
    }

    public void RequestLocationTracking(MonoBehaviour behaviour)
    {
        
    }
}
