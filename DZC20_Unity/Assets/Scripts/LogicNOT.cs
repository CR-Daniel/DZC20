using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicNOT : MonoBehaviour
{
    public LEDNode input = null;
    public LEDNode output = null;

    // Update is called once per frame
    void Update()
    {
        output.GetComponent<LEDNode>().isFirstNode = !input.GetComponent<LEDNode>().isFirstNode;
    }
}
