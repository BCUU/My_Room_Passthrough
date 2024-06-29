using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxManager : MonoBehaviour
{
    public Material[] skyboxes;
    private int currentSkyboxIndex = 0;

    [Range(0.0f, 1.0f)]
    public float brightness = 0.5f;
    public UnityEngine.Color color = new UnityEngine.Color(0.0f, 0.5f, 0.0f);

    private OVRPassthroughLayer passthroughLayer;

    void Start()
    {
        passthroughLayer = FindObjectOfType<OVRPassthroughLayer>();
        if (passthroughLayer == null)
        {
            Debug.LogError("PassthroughLayer bulunamadý. Lütfen sahnede OVRPassthroughLayer olduðundan emin olun.");
        }
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryThumbstickDown))
        {
            ChangeSkybox();
        }

        if (passthroughLayer != null)
        {
            passthroughLayer.colorScale = new Vector4(brightness, brightness, brightness, 1.0f);
            passthroughLayer.colorOffset = new Vector4(1 - brightness, 1 - brightness, 1 - brightness, 0.0f);
            passthroughLayer.colorScale = new Vector4(color.r, color.g, color.b, 1.0f);
            passthroughLayer.colorOffset = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
        }
    }

    void ChangeSkybox()
    {
        currentSkyboxIndex++;
        if (currentSkyboxIndex >= skyboxes.Length)
        {
            currentSkyboxIndex = 0;
        }

        switch (currentSkyboxIndex)
        {
            case 0: 
                brightness = 0.5f;
                color = new UnityEngine.Color(0.0f, 0.5f, 0.0f);
                break;
            case 1:
                brightness = 0.3f;
                color = new UnityEngine.Color(0.5f, 0.5f, 0.5f);
                break;
            default: 
                brightness = 0.5f;
                color = new UnityEngine.Color(0.0f, 0.5f, 0.0f);
                break;
        }

        RenderSettings.skybox = skyboxes[currentSkyboxIndex];
    }
}
