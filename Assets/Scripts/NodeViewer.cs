using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
using System;
using GeoCoordinatePortable;

public class NodeViewer : MonoBehaviour
{
    public Camera FirstPersonCamera;
    private const float NODE_PLACEMENT_DISTANCE = 1f;
    private const float NODE_PLACEMENT_HEIGHT = 0.5f;
    private List<Node> nodes = new List<Node>();
    private Anchor targetAnchor;
    private Node targetNode;
    private GameObject targetNodeObj;
    private DetectedPlane detectedPlane;

    void Start()
    {
        NodeManager.Instance.OnNodeListUpdate += OnNodeListUpdate;
    }

    void Update()
    {
        if (targetNode != null)
        {
            CheckTargetStillExists();
            DetectNodeTouch();
        }
        else
        {
            targetNode = GetNearestNode();
        }

        // Detected plane management
        if (detectedPlane == null)
        {
            return;
        }

        // Handle possible subsuming planes
        while (detectedPlane.SubsumedBy != null)
        {
            detectedPlane = detectedPlane.SubsumedBy;
        }

        if (targetNodeObj != null)
        {
            // Keep y-position consistent with plane
            float yPos = detectedPlane.CenterPose.position.y + NODE_PLACEMENT_HEIGHT;
            targetNodeObj.transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
        }
    }

    public void SetSelectedPlane(DetectedPlane detectedPlane)
    {
        if (this.detectedPlane != detectedPlane)
        {
            this.detectedPlane = detectedPlane;
        }

        if (targetNodeObj == null)
        {
            PlaceNodeObject();
        }
    }

    private void CheckTargetStillExists()
    {
        if (!nodes.Contains(targetNode))
        {
            // Does not exist anymore, nuke it
            targetNode = null;

            if (targetAnchor != null)
            {
                Destroy(targetAnchor);
            }

            if (targetNodeObj != null)
            {
                Destroy(targetNodeObj);
            }
        }
    }

    private void DetectNodeTouch()
    {
        // Detect node touches
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = FirstPersonCamera.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10f, LayerMask.NameToLayer("Node")))
            {
                // Hit a node - get node controller and press it
                NodeController nodeController = hit.collider.gameObject.GetComponent<NodeController>();
                nodeController.Touch();
            }
        }
    }

    private Node GetNearestNode()
    {
        float[] currentLocation = NodeManager.Instance.CurrentLocation();
        GeoCoordinate currentCoords = new GeoCoordinate(currentLocation[0], currentLocation[1]);

        Node nearestNode = null;
        double nearestDistance = Double.MaxValue;
        foreach (Node node in nodes)
        {
            // Check distance and set nearest accordingly
            double distance = currentCoords.GetDistanceTo(node.Coordinates);
            if (distance < nearestDistance)
            {
                nearestNode = node;
                nearestDistance = distance;
            }
        }
        return nearestNode;
    }

    private void OnNodeListUpdate()
    {
        nodes = NodeManager.Instance.GetNodes();
    }

    private void PlaceNodeObject()
    {
        // Place a node in front of user on top of the detected plane
        // Anchor above center of detected plane
        Vector3 centerPos = detectedPlane.CenterPose.position;
        Vector3 anchorPosition = new Vector3(centerPos.x, centerPos.y + NODE_PLACEMENT_HEIGHT, centerPos.z);

        if (targetAnchor != null)
        {
            DestroyObject(targetAnchor);
        }

        targetAnchor = detectedPlane.CreateAnchor(new Pose(anchorPosition, Quaternion.identity));

        // Create and position empty object that will be populated with downloaded node cover
        targetNodeObj = new GameObject("NodeHolder");
        targetNodeObj.transform.SetParent(targetAnchor.transform);
        targetNodeObj.transform.localPosition = Vector3.zero;

        // Add a node controller to it - this will take care of the rest
        NodeController nodeController = targetNodeObj.AddComponent<NodeController>();
        nodeController.SetAndLoadNode(new Node("1", 1, 1, "sheep"));
    }
}
