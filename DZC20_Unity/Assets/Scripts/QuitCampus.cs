using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitCampus : MonoBehaviour
{
    public LevelLoader levlo;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)){
            levlo.LevelLoad(3);
        }
    }
}
