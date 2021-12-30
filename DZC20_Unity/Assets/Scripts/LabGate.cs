using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabGate : MonoBehaviour
{
    public RawImage keyImage;
    public GameObject keyError;
    private bool doorMotion;
    private static Vector3 ogPosition;
    private static Vector3 endPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Hide Key Error UI Panel
        keyError.SetActive(false);

        // Define Start & End Gate Position for Translation
        ogPosition = transform.position;
        endPosition = new Vector3(ogPosition.x, ogPosition.y - 9f, ogPosition.z);
    }

    void Update()
    {
        if (doorMotion){
            transform.position = Vector3.MoveTowards(transform.position, endPosition, Time.deltaTime * 5f);
            if (transform.position == endPosition){
                keyImage.enabled = false;
                doorMotion = false;
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (keyImage.enabled == true){
            doorMotion = true;
        } else if (transform.position == endPosition){
            // do nothing   
        } else {
            // Show NoKey Error Panel
            keyError.SetActive(true);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        keyError.SetActive(false);
    }
}
