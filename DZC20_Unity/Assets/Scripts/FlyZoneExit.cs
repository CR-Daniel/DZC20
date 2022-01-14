using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlyZoneExit : MonoBehaviour
{
    public GameObject error;
    public Text text;
    private int messageIndex = 0;
    private string[] messages;

    // Start is called before the first frame update
    void Start()
    {
        messages = new string[] {
            "What are you doing? Return to campus!",
            "Trying to escape the campus again ey?",
            "You think this is funny huh?!",
            "...",
            "FINE, JUST LEAVE THEN!"
        };
        error.SetActive(false);
    }

    void OnTriggerEnter(Collider collider)
    {
        // Show Error Message
        StartCoroutine(ShowError());
    }

    IEnumerator ShowError()
    {
        text.text = messages[messageIndex];
        messageIndex += 1;

        if(messageIndex == messages.Length){
            Destroy(GetComponent<Collider>());
        }

        error.SetActive(true);
        yield return new WaitForSeconds(2f);
        error.SetActive(false);
    }
}
