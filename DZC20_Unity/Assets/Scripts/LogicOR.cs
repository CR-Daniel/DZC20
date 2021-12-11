using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicOR : MonoBehaviour
{
    public LEDNode input_1 = null;
    public LEDNode input_2 = null;
    public LEDNode output = null;

    // Update is called once per frame
    void Update()
    {
        if(input_1.GetComponent<LEDNode>().isFirstNode == true || input_2.GetComponent<LEDNode>().isFirstNode == true){
            output.GetComponent<LEDNode>().isFirstNode = true;
        } else {
            output.GetComponent<LEDNode>().isFirstNode = false;
        }
    }
}
