using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunToFinish : EnemyState
{
    public override void OnEnable()
    {
        base.OnEnable();

        if (Random.Range(0.0f, 1.0f) > 0.5f)
        {
            ic.move.x = -1f;
            ic.move.y = 0;
        }
        else
        {
            ic.move.x = 1f;
            ic.move.y = 0;
        }
    }

    public override void Update()
    {
        base.Update();
    }

    public override void OnDisable()
    {
        base.OnDisable();
    }

}
