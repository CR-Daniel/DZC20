using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateUnlock : MonoBehaviour
{
    public LEDNode node = null;
    private Quaternion open;
    public float lerpTime = 1;

    // Start is called before the first frame update
    void Start()
    {
        open = new Quaternion(1f, 0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (node.GetComponent<LEDNode>().isFirstNode == true){
            transform.rotation = Quaternion.Lerp(
                transform.rotation, open, Time.deltaTime * lerpTime);
        }

        Debug.Log(transform.rotation);
    }
}
