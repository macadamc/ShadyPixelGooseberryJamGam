using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyInputController : InputController {

    public Vector2 startVector;

    public void SetRandomRunDirection()
    {
        if(Random.Range(0.0f,1.0f) > 0.5f)
        {
            move.x = -1f;
            move.y = 0;
        }
        else
        {
            move.x = 1f;
            move.y = 0;
        }
    }

    public void ResetValues()
    {
        move = Vector2.zero;

    }

}
