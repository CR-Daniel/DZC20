using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotormovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float PropSpeed = 300f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, PropSpeed * Time.fixedDeltaTime, 0f, Space.Self);
    }
}
