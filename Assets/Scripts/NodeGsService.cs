﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSparks.Core;
using System;

public class NodeGsService : NodeService
{
    public void Authenticate(Action<bool> callback)
    {
        new GameSparks.Api.Requests.DeviceAuthenticationRequest().Send((response) =>
        {
            if (!response.HasErrors)
            {
                Debug.Log("GameSparks: Device Authenticated...");
            }
            else
            {
                Debug.Log("GameSparks: Error Authenticating Device...");
            }

            callback(!response.HasErrors);
        });
    }

    public void AddNode(float latitude, float longitude, string type, bool fill, Action<bool> callback)
    {
        new GameSparks.Api.Requests.LogChallengeEventRequest_ADD_NODE()
            .Set_LAT(latitude.ToString())
            .Set_LON(longitude.ToString())
            .Set_TYPE(type)
            .Set_FILL(fill.ToString()).Send((response) =>
            {
                callback(!response.HasErrors);
            });
    }

    public void GetNearbyNodes(float latitude, float longitude, Action<bool, List<Node>> callback)
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
                    foreach (GSData baseData in data)
                    {
                        string id = baseData.GetString("id");

                        GSData nodeData = baseData.GetGSData("data");
                        float lat = float.Parse(nodeData.GetString("latitude"));
                        float lon = float.Parse(nodeData.GetString("longitude"));
                        string type = nodeData.GetString("type");
                        bool fill = bool.Parse(nodeData.GetString("fill"));

                        Node node = new Node(id, lat, lon, type);
                        nodeList.Add(node);
                    }

                    callback(true, nodeList);
                }
                else
                {
                    Debug.Log("GameSparks: Error retrieving nearby nodes...");
                    callback(false, null);
                }
            });
    }
}
