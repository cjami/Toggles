using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    private float latitude;
    private float longitude;
    private string type;
    private bool fill;

    public float Latitude
    {
        get
        {
            return latitude;
        }
    }

    public float Longitude
    {
        get
        {
            return longitude;
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

    public Node(float latitude, float longitude, string type)
    {
        this.latitude = latitude;
        this.longitude = longitude;
        this.type = type;
    }
}
