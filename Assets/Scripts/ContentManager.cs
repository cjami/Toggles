using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssetBundles;
using System;

public class ContentManager : Singleton<ContentManager>
{
    private const string CONTENT_BASE_URI = "";
    private AssetBundleManager assetBundleManager;
    private bool init;

    void Start()
    {
        assetBundleManager = new AssetBundleManager();
        assetBundleManager.Initialize(OnInitializeComplete);
        assetBundleManager.SetBaseUri(CONTENT_BASE_URI);
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
