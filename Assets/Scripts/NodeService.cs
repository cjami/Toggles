using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface NodeService
{
    List<Node> GetNearbyNodes(float latitude, float longitude);
    void AddNode(float latitude, float longitude, string type, bool fill);
}
