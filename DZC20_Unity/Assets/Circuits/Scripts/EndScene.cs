using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScene : MonoBehaviour
{
    public GameObject button;
    public GameObject Level2Cam;
    public GameObject Level1Cam;
    public GameObject EndCam;


    // Update is called once per frame
    public void OnClickNext()
    {
        EndCam.SetActive(false);
        Level1Cam.SetActive(true);
    }
}
