using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabGate : MonoBehaviour
{
    public RawImage keyImage;
    public GameObject keyError;
    private static Vector3 ogPosition;
    private static Vector3 endPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Hide Key Error UI Panel
        keyError.SetActive(false);

        // Define Start & End Gate Position for Translation
        ogPosition = transform.position;
        endPosition = new Vector3(ogPosition.x, ogPosition.y - 50f, ogPosition.z);
    }

    void OnTriggerEnter(Collider collider)
    {
        // If Player has Key in UI
        if (keyImage.enabled == true)
        {
            // Open Door
            transform.position = Vector3.Lerp(
                transform.position, endPosition, Time.deltaTime * 2);
            
            // If Fully Open
            if (transform.position == endPosition){
                // Hide Key in UI
                keyImage.enabled = false;
            }
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
