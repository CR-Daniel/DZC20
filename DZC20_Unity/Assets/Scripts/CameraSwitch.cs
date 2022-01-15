using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera[] cameras;
    private int levelIndex = 0;

    void Start()
    {
        // Disable All Cameras
        foreach (Camera cam in cameras){
            cam.enabled = false;
        }

        // Enable First Camera
        cameras[0].enabled = true;
    }

    public void Switch()
    {
        // Disable Current Camera
        cameras[levelIndex].enabled = false;

        // Get Next Camera
        if (levelIndex + 1 != cameras.Length){
            levelIndex += 1;
        }

        // Enable Next Camera
        cameras[levelIndex].enabled = true;
    }
}
