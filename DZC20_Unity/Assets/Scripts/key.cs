using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class key : MonoBehaviour
{
    public RawImage keyImage;

    // Start is called before the first frame update
    void Start()
    {
        // Hide Key in UI
        keyImage.enabled = false; 
    }

    // Update is called once per frame
    void Update()
    {
        // Keep Key Rotating
        transform.Rotate(0, 50 * Time.deltaTime, 0);
    }

    void OnTriggerEnter(Collider collider)
    {
        // TODO: Make Collect Sound
        // ...

        // Destroy Key
        Destroy(gameObject);

        // Show Key in UI
        keyImage.enabled = true;
    }
}
