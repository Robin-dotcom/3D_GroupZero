using System;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraHandler : MonoBehaviour
{
    [SerializeField]
    private Boolean enableFog = true;
    // Start is called before the first frame update

    private void OnPreRender()
    {
        RenderSettings.fog = enableFog;
    }

    private void OnPostRender()
    {
        RenderSettings.fog = enableFog;
    }
}
