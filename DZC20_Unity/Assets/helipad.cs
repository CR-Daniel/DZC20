using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helipad : MonoBehaviour
{
    LevelLoader levlo;
    int index = 1;

    // Start is called before the first frame update
    void Start()
    {
        levlo = new LevelLoader();
    }

    void OnTriggerEnter(Collider collider)
    {
        // transition to index level
        //StartCoroutine(levlo.LoadLevel(1));
    }
}
