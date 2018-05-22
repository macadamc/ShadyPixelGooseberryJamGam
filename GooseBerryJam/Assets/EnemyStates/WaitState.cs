using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitState : EnemyState {
    public float minWait;
    public float maxWait;
    float exitTime;

    public EnemyState NextState;

    public override void OnDisable()
    {
        base.OnDisable();
    }

    public override void OnEnable()
    {
        base.OnEnable();
        exitTime = Random.Range(minWait, maxWait) + Time.time;
        ic.move = Vector3.zero;
    }

    public override void Update()
    {
        if (Time.time >= exitTime)
            Transition(NextState);
    }
}
