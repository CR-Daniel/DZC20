using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateUnlock : MonoBehaviour
{
    public LEDNode node = null;
    public float lerpTime = 1;
    public GameObject walls = null;

    private Quaternion open;
    private Transform nodeZero;

    // Start is called before the first frame update
    void Start()
    {
        open = new Quaternion(1f, 0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (node.GetComponent<LEDNode>().isFirstNode == true){
            // Open Door
            transform.rotation = Quaternion.Lerp(
                transform.rotation, open, Time.deltaTime * lerpTime);
            
            // Activate Walls
            foreach (Transform child in walls.transform) {
                nodeZero = child.GetChild(0);
                nodeZero.gameObject.GetComponent<LEDNode>().isFirstNode = true;
            }
        }
    }
}
