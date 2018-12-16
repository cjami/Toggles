using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
using System;

public class NodeController : MonoBehaviour
{    
    void Start()
    {
        NodeManager.Instance.OnNodeListUpdate += OnNodeListUpdate;
    }

    private void OnNodeListUpdate()
    {
        
    }

    private void PlaceNode(DetectedPlane detectedPlane, Node node)
    {

    }

    private void CreateAnchor(DetectedPlane detectedPlane)
    {
        
    }
}
