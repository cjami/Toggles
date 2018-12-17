using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssetBundles;
using System;
using GeoCoordinatePortable;

public delegate void OnNodeListUpdateHandler();
public class NodeManager : Singleton<NodeManager>
{
    private const float NODE_LIST_POLL_RATE = 5f;
    private List<Node> nodes = new List<Node>();
    private NodeService nodeService = new NodeGsService();
    private GeoService geoService = new GeoUnityService();

    public OnNodeListUpdateHandler OnNodeListUpdate;

    void Start()
    {
        geoService.RequestLocationTracking(this);
        Invoke("AuthenticateNodeService", 3f); // Should use callback
    }

    private void AuthenticateNodeService()
    {
        nodeService.Authenticate((bool success) =>
        {
            // Successfully authenticated - start polling nodes
            if (success)
            {
                InvokeRepeating("UpdateNodes", 0, NODE_LIST_POLL_RATE);
            }
        });
    }

    public void AddNode(float latitude, float longitude, string type, bool fill, Action<bool> callback)
    {
        nodeService.AddNode(latitude, longitude, type, fill, callback);
    }

    public List<Node> GetNodes()
    {
        return new List<Node>(nodes);
    }

    // This should be in a better place
    public float[] CurrentLocation()
    {
        return geoService.CurrentLocation();
    }

    /* 
     *  Updates our list of nodes. Note that this is asynchronous - use OnNodeListUpdate to check new lists.
     */
    void UpdateNodes()
    {
        if (geoService.IsTracking())
        {
            // Firstly get current location
            float[] currentLocation = geoService.CurrentLocation();
            if (currentLocation != null)
            {
                // Then send this location to our node service to get a list of nearby nodes
                nodeService.GetNearbyNodes(currentLocation[0], currentLocation[1], (bool success, List<Node> nodes) =>
                {
                    if (!success)
                    {
                        return;
                    }

                    this.nodes = nodes;

                    if (OnNodeListUpdate != null)
                    {
                        OnNodeListUpdate();
                    }
                });
            }
        }
    }
}
