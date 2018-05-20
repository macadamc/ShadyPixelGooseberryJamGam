using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckBestScore : MonoBehaviour {

    public IntVariable score;

    public IntVariable highscore;

    public UnityEvent onNewHighScore;

    private void OnEnable()
    {
        if(score.value > highscore.value)
        {
            highscore.value = score.value;
            onNewHighScore.Invoke();
        }
    }

}
