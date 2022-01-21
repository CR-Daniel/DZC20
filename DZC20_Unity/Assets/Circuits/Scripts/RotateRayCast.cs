using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRayCast : MonoBehaviour
{
    
    public GameObject camera;
    public GameObject EndCam;
    public bool moving = false;
    private void Update(){

            if(Input.GetMouseButtonDown(0)){
                
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if(Physics.Raycast(ray, out hit, 100.0f)){

                    while(moving == false){
                        if(hit.transform != null){
                            PrintName(hit.transform.gameObject);

                            StartCoroutine(Rotate(hit.transform.gameObject, 0, 0, 90, 0.5f));
                        }
                    }
                }
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
        moving = true;

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
        moving = false;
    }
}
