using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTag : MonoBehaviour
{
    public string Tag;
    private GameObject taggedObject;

    void Start()
    {
        taggedObject = GameObject.FindGameObjectWithTag(Tag);
    }

    void LateUpdate()
    {
        if (taggedObject != null)
        {
            transform.position = taggedObject.transform.position;
        }
    }
}
