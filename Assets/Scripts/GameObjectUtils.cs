using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectUtils
{
    public static void DisableRenderers(GameObject obj)
    {
        Renderer[] renderers = obj.GetComponentsInChildren<Renderer>();

        for (int i = 0, n = renderers.Length; i < n; i++)
        {
            renderers[i].enabled = false;
        }
    }

    public static void EnableRenderers(GameObject obj)
    {
        Renderer[] renderers = obj.GetComponentsInChildren<Renderer>();

        for (int i = 0, n = renderers.Length; i < n; i++)
        {
            renderers[i].enabled = true;
        }
    }
}
