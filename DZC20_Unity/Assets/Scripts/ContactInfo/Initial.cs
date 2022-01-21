using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Initial : MonoBehaviour
{
    public GameObject box;
    public Text text;
    private string[] messages;
    private int messageIndex = 0;
    private bool inside;
    private bool visited;
    static bool created = false;

    void Awake()
    {
        if(!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
        else
        {
        Destroy(this.gameObject);
        }
    }

    void Start()
    {
        box.SetActive(false);
        messages = new string[] {
            "1",
            "2",
            "3",
            "...",
            "5"
        };
    }

    void Update()
    {
        if (inside && !visited){
            // freeze time
            Time.timeScale = 0;

            if (messageIndex < messages.Length){
                text.text = messages[messageIndex];
                box.SetActive(true);
            } else {
                visited = true;
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
    }

    void OnTriggerExit(Collider collider)
    {
        inside = false;
    }
}
