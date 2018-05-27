using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Quit()
    {
        StartCoroutine(QuitCoroutine());
    }

    public IEnumerator QuitCoroutine()
    {
        yield return new WaitForSeconds(1.0f);

        if (Application.isEditor)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
        else
            Application.Quit();
    }
}
