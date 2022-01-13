using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRayCast : MonoBehaviour
{
    //Level 1 SphereX
    public Transform Level1X;
    //Level 2 SphereX
    public Transform Level2X;
    //Level 2 SphereY
    public Transform Level2Y;
    //Level 3 SphereX
    public Transform Level3X;
    //Level 4 SphereX
    public Transform Level4X;
    //Level 4 SphereY
    public Transform Level4Y;
    //Level 4 SphereZ
    public Transform Level4Z;
    //Level 4 SphereW
    public Transform Level4W;
    //Level 4 SphereV
    public Transform Level4V;
    public GameObject camera;
    public GameObject EndCam;
    private void Update(){

            if(Input.GetMouseButtonDown(0)){
                
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if(Physics.Raycast(ray, out hit, 100.0f)){

                    if(hit.transform != null){
                        PrintName(hit.transform.gameObject);

                        // Simple Instantaneous Rotation
                        // hit.transform.Rotate(0, 0, 90);

                        StartCoroutine(Rotate(hit.transform.gameObject, 0, 0, 90, 0.5f));
                    }
                }
            }
        //Level 1
        if(Level1X.eulerAngles.z >= 180f && Level1X.eulerAngles.z <= 180f){
            camera.SetActive(false);
            EndCam.SetActive(true);
        }
        //Level 2
        if((Level2X.eulerAngles.z >= 180f && Level2X.eulerAngles.z <= 180f) && (
            (Level2Y.eulerAngles.z >= 180f && Level2Y.eulerAngles.z <= 180f) ||
            (Level2Y.eulerAngles.z >= 90f && Level2Y.eulerAngles.z <= 90f)))
        {
            camera.SetActive(false);
            EndCam.SetActive(true);
        }
        //Level 3
        if((Level3X.eulerAngles.z >= 0f && Level3X.eulerAngles.z <= 0f) || 
            (Level3X.eulerAngles.z >= 270f && Level3X.eulerAngles.z <= 270f)){
            camera.SetActive(false);
            EndCam.SetActive(true);
        }
        //Level 4
        if((Level4X.eulerAngles.z >= 0f && Level4X.eulerAngles.z <= 0f) && 
            (Level4Z.eulerAngles.z >= 90f && Level4Z.eulerAngles.z <= 90f) &&
            (Level4W.eulerAngles.z >= 270f && Level4W.eulerAngles.z <= 270f) &&
            (Level4V.eulerAngles.z >= 180f && Level4V.eulerAngles.z <= 180f)){
            camera.SetActive(false);
            EndCam.SetActive(true);
        }
    }

    private void PrintName(GameObject go){
        print(go.name);
    }

    IEnumerator Rotate(GameObject obj, float x, float y, float z, float duration)
    {
        bool rotating = true;
        float timeElapsed = 0;
        float lerpDuration = duration;

        Quaternion startRotation = obj.transform.rotation;
        Quaternion targetRotation = obj.transform.rotation * Quaternion.Euler(x, y, z);

        while (timeElapsed < lerpDuration)
        {
            obj.transform.rotation = Quaternion.Slerp(startRotation, targetRotation, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        obj.transform.rotation = targetRotation;
        rotating = false;
    }
}
