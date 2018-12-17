using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssetBundles;
using System;

public class ContentManager : Singleton<ContentManager>
{
    private const string CONTENT_BASE_URI = "https://s3.eu-west-2.amazonaws.com/toggles";
    private AssetBundleManager assetBundleManager;
    private bool init;

    void Start()
    {
        assetBundleManager = new AssetBundleManager();
        assetBundleManager.SetBaseUri(CONTENT_BASE_URI);
        assetBundleManager.Initialize(OnInitializeComplete);
    }

    public bool GetContent(string name, Action<AssetBundle> callback)
    {
        if (!init)
        {
            return false;
        }
        else
        {
            assetBundleManager.GetBundle(name, callback);
            return true;
        }
    }

    private void OnInitializeComplete(bool success)
    {
        if (success)
        {
            init = true;
        }
        else
        {
            Debug.Log("Failed to intialize AssetBundleManager");
        }
    }
}
