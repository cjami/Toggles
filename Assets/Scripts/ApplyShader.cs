using UnityEngine;
using System.Collections;

/*
 *  Workaround component: For some reason shaders are not being applied properly from AssetBundles
 */
public class ApplyShader : MonoBehaviour
{
    private Material[] material;
    private string[] shaders;

    void Start()
    {
        material = GetComponent<Renderer>().sharedMaterials;
        shaders = new string[material.Length];

        for (int i = 0; i < material.Length; i++)
        {
            shaders[i] = material[i].shader.name;
        }

        for (int i = 0; i < material.Length; i++)
        {
            material[i].shader = Shader.Find(shaders[i]);
        }
    }
}