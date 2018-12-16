using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssetBundles;

public delegate void OnNodeListUpdateHandler();
public class NodeManager : Singleton<NodeManager>
{
    private const float NODE_LIST_UPDATE_RATE = 5f;
    private List<Node> nodes = new List<Node>();
    private NodeService nodeService = new NodeGsService();
    private GeoService geoService = new GeoUnityService();

    public OnNodeListUpdateHandler OnNodeListUpdate;

    void Start()
    {
        InvokeRepeating("UpdateNodes", 0, NODE_LIST_UPDATE_RATE);
    }

    void AddNode(float latitude, float longitude, string type, bool fill)
    {
        nodeService.AddNode(latitude, longitude, type, fill);
    }    

    // Updates our list of nodes. Note that this is asynchronous - use OnNodeListUpdate to check new lists.
    void UpdateNodes()
    {
        geoService.RequestLocation(this, () =>
        {
            float[] currentLocation = geoService.CurrentLocation();
            if (currentLocation != null)
            {
                nodes = nodeService.GetNearbyNodes(currentLocation[0], currentLocation[1]);

                if (OnNodeListUpdate != null)
                {
                    OnNodeListUpdate();
                }
            }
        });
    }

    void GetContentBundle(Node node){
        
    }

    void GetCoverBundle(Node node){

    }

    List<Node> GetNodes()
    {
        return new List<Node>(nodes);
    }


}
