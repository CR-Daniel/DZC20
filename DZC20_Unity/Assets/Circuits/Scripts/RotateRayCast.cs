using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRayCast : MonoBehaviour
{
    //Level 1 SphereX
    public Transform GameObject1;
    //Level 2 SphereX
    public Transform GameObject2;
    //Level 2 SphereY
    public Transform GameObject3;
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
        //Level 1 SphereX
        if(GameObject1.eulerAngles.z >= 180f && GameObject1.eulerAngles.z <= 180f){
            camera.SetActive(false);
            EndCam.SetActive(true);
        }
        if((GameObject2.eulerAngles.z >= 180f && GameObject2.eulerAngles.z <= 180f) && (
            (GameObject3.eulerAngles.z >= 180f && GameObject3.eulerAngles.z <= 180f) ||
            (GameObject3.eulerAngles.z >= 90f && GameObject3.eulerAngles.z <= 90f)))
        {
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
