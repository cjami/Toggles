using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSparks.Core;

public class NodeGsService : NodeService
{
    public void AddNode(float latitude, float longitude, string type, bool fill)
    {
        new GameSparks.Api.Requests.LogChallengeEventRequest_ADD_NODE()
            .Set_LAT(latitude.ToString())
            .Set_LON(longitude.ToString())
            .Set_TYPE(type)
            .Set_FILL(fill.ToString());
    }

    public List<Node> GetNearbyNodes(float latitude, float longitude)
    {
        List<Node> nodeList = new List<Node>();

        new GameSparks.Api.Requests.LogEventRequest_GET_NEARBY_NODES()
            .Set_LAT(latitude.ToString())
            .Set_LON(longitude.ToString())
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    List<GSData> data = response.ScriptData.GetGSDataList("node");
                    foreach (GSData nodeData in data)
                    {
                        float lat = nodeData.GetFloat("latitude").Value;
                        float lon = nodeData.GetFloat("longitude").Value;
                        string type = nodeData.GetString("type");
                        bool fill = nodeData.GetBoolean("fill").Value;

                        Node node = new Node(lat, lon, type);
                        nodeList.Add(node);
                    }
                }
                else
                {
                    Debug.Log("Error retrieving nearby nodes...");
                }
            });

        return nodeList;
    }
}
