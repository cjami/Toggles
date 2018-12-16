using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 	Used to test effect of _GlobalLightEstimation (set by ARCore) on custom shaders
 */
public class LightEstimationTest : MonoBehaviour
{
    [Range(0f, 1f)]
    public float TestValue = 0.5f;

    void OnValidate()
    {
        setGlobalLightEstimation(TestValue);
    }

    void setGlobalLightEstimation(float value)
    {
        Shader.SetGlobalFloat("_GlobalLightEstimation", value);
    }

}
