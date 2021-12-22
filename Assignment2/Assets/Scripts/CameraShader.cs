using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraShader : MonoBehaviour
{
    public Material ShaderTexture;

    void OnRenderImage(RenderTexture cameraView, RenderTexture shaderView)
    {
        Graphics.Blit(cameraView, shaderView, ShaderTexture);
        Debug.Log("Hi");
    }
}
