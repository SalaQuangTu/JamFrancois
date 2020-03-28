using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public static Transition Instance;
    private void Awake()
    {
        Instance = this;
    }

    public Animator fade;

    public void LoadNextLevel()
    {
        fade.SetTrigger("Close");
        if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCount - 1)
        {
            StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
        }
        else
        {
            StartCoroutine(LoadScene(0));
        }
    }

    public void LoadNextLevel(int index)
    {
        fade.SetTrigger("Close");
        StartCoroutine(LoadScene(index));
    }

    IEnumerator LoadScene(int index)
    {
        AsyncOperation load = SceneManager.LoadSceneAsync(index);
        while (!load.isDone)
        {
            yield return new WaitForEndOfFrame();
        }
        yield return 0;
    }
}