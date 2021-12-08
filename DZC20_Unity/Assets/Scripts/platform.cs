using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    public LEDNode plat = null;
    public LEDNode next = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        plat.GetComponent<LEDNode>().isFirstNode = !plat.GetComponent<LEDNode>().isFirstNode;
        next.GetComponent<LEDNode>().isFirstNode = plat.GetComponent<LEDNode>().isFirstNode;
    }

    void OnTriggerExit(Collider collider)
    {
        // do nothing
    }
}
