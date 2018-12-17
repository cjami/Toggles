using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface NodeService
{
    void Authenticate(Action<bool> callback);
    void GetNearbyNodes(float latitude, float longitude, Action<bool, List<Node>> callback);
    void AddNode(float latitude, float longitude, string type, bool fill, Action<bool> callback);
}
