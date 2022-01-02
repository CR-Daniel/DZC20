using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRayCast : MonoBehaviour
{
    private void Update(){
        if(Input.GetMouseButtonDown(0)){

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, 100.0f)){

                if(hit.transform != null){
                    PrintName(hit.transform.gameObject);
                    Rigidbody rb;
                    if(rb = hit.transform.GetComponent<Rigidbody>()){
                        
                      Rotate(rb);
                    }
                }
            }
        }  
    }

    private void PrintName(GameObject go){
        print(go.name);
    }

    private void Rotate(Rigidbody rig){
        rig.transform.Rotate(0, 0, 90f);
    }
}
