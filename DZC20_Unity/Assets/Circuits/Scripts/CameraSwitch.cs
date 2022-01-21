using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSwitch : MonoBehaviour
{
    // UI Elements
    public GameObject button;
    public GameObject[] screens;
    public GameObject[] resistors; 
    public Camera[] cameras;
    private int levelIndex = 0;

    // Collection Of Spheres
    public Transform[] level1;
    public Transform[] level2;
    public Transform[] level3;
    public Transform[] level4;


    void Start()
    {
        // Disable All Cameras
        foreach (Camera cam in cameras){
            cam.enabled = false;
        }

        // Enable First Camera
        cameras[0].enabled = true;

        // Disable All UI Screens
        foreach (GameObject screen in screens){
            screen.SetActive(false);
        }

        //Disable all UI Resistors
        foreach (GameObject resistor in resistors){
            resistor.SetActive(false);
        }

        //Enable first Resistor
        resistors[0].SetActive(true);

        // Disable Button
        button.SetActive(false);
    }

    void Update()
    {
        switch(levelIndex) {
            case 0:
                bool a1 = level1[0].eulerAngles.z >= 180f && level1[0].eulerAngles.z <= 180f;

                if(a1){
                    screens[levelIndex].SetActive(true);
                    button.SetActive(true);
                    resistors[0].SetActive(false);
                    resistors[1].SetActive(true);
                    resistors[2].SetActive(true);

                }
                break;

            case 1:
                bool b1 = level2[0].eulerAngles.z >= 180f && level2[0].eulerAngles.z <= 180f;
                bool b2 = level2[1].eulerAngles.z >= 180f && level2[1].eulerAngles.z <= 180f;
                bool b3 = level2[1].eulerAngles.z >= 90f && level2[1].eulerAngles.z <= 90f;

                if (b1 && (b2 || b3)){
                    screens[levelIndex].SetActive(true);
                    button.SetActive(true);
                    resistors[1].SetActive(false);
                    resistors[2].SetActive(false);
                    resistors[3].SetActive(true);
                    resistors[4].SetActive(true);
                    resistors[5].SetActive(true);
                }
                break;

            case 2:
                bool c1 = level3[0].eulerAngles.z >= 0f && level3[0].eulerAngles.z <= 0f;
                bool c2 = level3[0].eulerAngles.z >= 270f && level3[0].eulerAngles.z <= 270f;

                if(c1 || c2){
                    screens[levelIndex].SetActive(true);
                    button.SetActive(true);
                    resistors[3].SetActive(false);
                    resistors[4].SetActive(false);
                    resistors[5].SetActive(false);
                    resistors[6].SetActive(true);
                    resistors[7].SetActive(true);
                    resistors[8].SetActive(true);
                    resistors[9].SetActive(true);
                    resistors[10].SetActive(true);
                    resistors[11].SetActive(true);
                    resistors[12].SetActive(true);
                    resistors[13].SetActive(true);
                    resistors[14].SetActive(true);
                    resistors[15].SetActive(true);
                }
                break;

            case 3:
                bool d1 = (level4[0].eulerAngles.z >= 0f && level4[0].eulerAngles.z <= 0f) || (level4[0].eulerAngles.z >= 180f && level4[0].eulerAngles.z <= 180f);
                bool d2 = level4[2].eulerAngles.z >= 90f && level4[2].eulerAngles.z <= 90f;
                bool d3 = level4[3].eulerAngles.z >= 270f && level4[3].eulerAngles.z <= 270f;
                bool d4 = level4[4].eulerAngles.z >= 180f && level4[4].eulerAngles.z <= 180f;

                if (d1 && d2 && d3 && d4){
                    screens[levelIndex].SetActive(true);
                    button.SetActive(true);
                }
                break;
        }
    }

    public void Switch()
    {
        // Hide UI Screen
        screens[levelIndex].SetActive(false);
        button.SetActive(false);
        
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
