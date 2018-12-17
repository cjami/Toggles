using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface GeoService
{
    void RequestLocationTracking(MonoBehaviour behaviour);
    bool IsTracking();
    float[] CurrentLocation();
    float CurrentHeading();
}
