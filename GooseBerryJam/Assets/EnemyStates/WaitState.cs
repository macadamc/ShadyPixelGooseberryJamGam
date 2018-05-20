using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitState : EnemyState
{
    public EnemyState NextState; 
    public float waitTime = 1f;
    float nextTime;
    Vector2 lastDir;

    public override void OnDisable()
    {
        //ic.move = lastDir;
    }

    public override void OnEnable()
    {
        base.OnEnable();

        lastDir = ic.move;
        ic.move = Vector2.zero;
        nextTime = Time.time + waitTime;
    }

    public override void Update()
    {
        if (Time.time >= nextTime)
            Transition(NextState);
    }
}
