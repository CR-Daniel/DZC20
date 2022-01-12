using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime;

    public void LevelLoad(int levelindex)
    {
        StartCoroutine(LoadLevel(levelindex));
    }

    IEnumerator LoadLevel(int levelindex)
    {
        // Play Animation
        transition.SetTrigger("Start");

        // Wait
        yield return new WaitForSeconds(transitionTime);

        // Load Scene
        SceneManager.LoadScene(levelindex);
    }
}
