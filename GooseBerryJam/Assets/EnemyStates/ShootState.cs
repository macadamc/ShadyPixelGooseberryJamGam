using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootState : EnemyState
{
    public EnemyState state;

    public override void OnEnable()
    {
        base.OnEnable();
    }

    public override void Update()
    {
        ic.action = true;
        Transition(state);
    }

    public void LateUpdate()
    {
        ic.action = false;
    }


}
