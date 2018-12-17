using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GeoCoordinatePortable;

public class Node
{
    private string id;
    private GeoCoordinate coordinates;
    private string type;
    private bool fill;

    public string Id
    {
        get
        {
            return id;
        }
    }

    public GeoCoordinate Coordinates
    {
        get
        {
            return coordinates;
        }
    }

    public string Type
    {
        get
        {
            return type;
        }
    }

    public bool Fill
    {
        get
        {
            return fill;
        }
    }

    public Node(string id, float latitude, float longitude, string type)
    {
        this.id = id;
        this.coordinates = new GeoCoordinate(latitude, longitude);
        this.type = type;
    }

    // override object.Equals
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Node otherNode = (Node)obj;
        return id.Equals(otherNode.id);
    }

    // override object.GetHashCode
    public override int GetHashCode()
    {
        return id.GetHashCode();
    }
}
