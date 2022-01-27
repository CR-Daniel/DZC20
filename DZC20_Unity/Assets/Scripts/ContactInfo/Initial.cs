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
    private bool first = true;

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
            "Hey!",
            "Hey there! Yeah you. Over here, next to the billboard.",
            "Yes you are listening to a drone, a talking drone actually.",
            "Whay am I talking to you? I wanted to be the first one to introduce you to the campus and flew all the way over here.",
            "So let me indroduce myself. My name is AutonomousFlyingDrone.beta(MightBeSketchy)",
            "But you can call me Jay.",
            "You seem hesitant. Come on. It will be fine.",
            "I am a drone, I can't do you anything.",
            "Come on, let me introduce you to the campus, this will be fun!",
            "One small problem...",
            "You need to control me. You can find the controls on the billboard. Let's give it a go"

        };
    }

    void Update()
    {
        if (inside && !visited){
            // freeze time
            if(first){
                StartCoroutine(freeze());
                first = false;
            }

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

    IEnumerator freeze()
    {
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0;
    }
}
