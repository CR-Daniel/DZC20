using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicAND : MonoBehaviour
{
    public LEDNode input_1 = null;
    public LEDNode input_2 = null;
    public LEDNode output = null;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(input_1.GetComponent<LEDNode>().isFirstNode == true && input_2.GetComponent<LEDNode>().isFirstNode == true){
            output.GetComponent<LEDNode>().isFirstNode = true;
        } else {
            output.GetComponent<LEDNode>().isFirstNode = false;
        }
    }
}
