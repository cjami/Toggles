using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface GeoService
{
    void RequestLocation(MonoBehaviour behaviour, Action callback);
    float[] CurrentLocation();
    float CurrentHeading();
}
