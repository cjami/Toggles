using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class NodeController : MonoBehaviour
{
    private Node node;
    private AssetBundle sceneBundle;
    private bool touched;

    public void SetAndLoadNode(Node node)
    {
        this.node = node;

        ContentManager.Instance.GetContent(node.Type + "_cover", OnCoverLoaded);
    }

    public void Touch()
    {
        if (sceneBundle == null)
        {
            // No scene bundle or not loaded yet
            return;
        }

        string[] scenes = sceneBundle.GetAllScenePaths();
        string scene = Path.GetFileNameWithoutExtension(scenes[0]);

        if (!touched)
        {
            // Grab scene and load it additively (async)
            SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
        }
        else
        {
            // Remove all elements of the scene
            SceneManager.UnloadSceneAsync(scene);
        }

        touched = !touched; // Toggle
    }

    private void OnCoverLoaded(AssetBundle bundle)
    {
        if (bundle != null)
        {
            // Attach our cover to current position
            GameObject cover = Instantiate(bundle.LoadAsset<GameObject>("Cover"));
            cover.transform.SetParent(gameObject.transform);
            cover.transform.localPosition = Vector3.zero;

            // Proceed to retrieve content
            ContentManager.Instance.GetContent(node.Type + "_content", OnContentLoaded);
        }
    }

    private void OnContentLoaded(AssetBundle bundle)
    {
        if (bundle != null)
        {
            bundle.LoadAllAssets(); // Should be done async

            // Proceed to retrieve scene
            ContentManager.Instance.GetContent(node.Type + "_scene", OnSceneLoaded);
        }
    }

    private void OnSceneLoaded(AssetBundle bundle)
    {
        if (bundle != null)
        {
            sceneBundle = bundle;
        }
    }
}
