using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helipad : MonoBehaviour
{
    public LevelLoader levlo;
    public int index;

    void OnTriggerEnter(Collider collider)
    {
        levlo.LevelLoad(index);
    }
}
