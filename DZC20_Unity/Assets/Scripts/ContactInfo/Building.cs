using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    public GameObject box;
    public GameObject interact;
    public Text text;
    public string[] messages;
    private int messageIndex;
    private bool inside;
    private bool request;

    void Start()
    {
        box.SetActive(false);
        interact.SetActive(false);
    }

    void Update()
    {
        if (inside && Input.GetKeyDown(KeyCode.E)){
            messageIndex = 0;
            request = true;
        }

        if (inside && request){
            // freeze time
            Time.timeScale = 0;

            if (messageIndex < messages.Length){
                text.text = messages[messageIndex];
                box.SetActive(true);
            } else {
                Time.timeScale = 1;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                box.SetActive(false);
                ++messageIndex;
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        inside = true;
        interact.SetActive(true);
    }

    void OnTriggerExit(Collider collider)
    {
        inside = false;
        interact.SetActive(false);
    }
}
