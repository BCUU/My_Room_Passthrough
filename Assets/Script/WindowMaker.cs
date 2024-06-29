using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class WindowMaker : MonoBehaviour
{
    public GameObject prefabToPlace;
    private int wallLayerMask;
    private GameObject[] existingWindows;
    public Material windowMaterial;
    public GameObject righhand;
    public void Initialized()
    {
        wallLayerMask = LayerMask.GetMask("Wall");
        Renderer[] renderers = FindObjectsOfType<Renderer>();
        existingWindows = System.Array.FindAll(renderers, r => r.gameObject.name == "WINDOW_FRAME_EffectMesh").Select(r => r.gameObject).ToArray();
    }
    public void FindWindow()
    {
        if (existingWindows != null && existingWindows.Length > 0)
        {
            foreach (GameObject window in existingWindows)
            {
                Renderer targetRenderer = window.GetComponent<Renderer>();
                if (targetRenderer != null)
                {
                    targetRenderer.material = windowMaterial; 
                }
                else
                {
                    Debug.LogError("Renderer component not found on window object!");
                }
            }
        }
        else
        {
            Debug.LogError("No windows found in the scene!");
        }
    }
   
    bool iscreate=false;
    void Update()
    {
        
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger)&&!iscreate)
        {
            
            Instantiate(prefabToPlace, righhand.transform.position, righhand.transform.rotation);
            iscreate=true;
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            FindWindow();
        }
    }
}
