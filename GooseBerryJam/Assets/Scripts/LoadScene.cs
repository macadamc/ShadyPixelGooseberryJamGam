using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public float waitTime = 1f;

    public void Load(string sceneName)
    {
        StartCoroutine( LoadCoroutine(sceneName, waitTime) );
    }

    public IEnumerator LoadCoroutine(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

}
