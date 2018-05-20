using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargePlayerState : EnemyState
{
    public EnemyState NextState;
    MovementController mc;
    SimpleEnemyAttackController ac;

    float lastSpeed;
    Vector2 staleTargetPos;
    Vector2 startPos;

    public float ChargeSpeed;

    public override void OnDisable()
    {
    }

    public override void OnEnable()
    {
        base.OnEnable();

        mc = GetComponent<MovementController>();
        ac = GetComponent<SimpleEnemyAttackController>();

        startPos = transform.position;
        lastSpeed = mc.moveSpeed;
        mc.moveSpeed = ChargeSpeed;

        if (ac.target == null)
        {
            Transition(NextState);
            return;
        }
        ic.move = (ac.target.transform.position - transform.position).normalized;
        ic.move.y = 0f;

        staleTargetPos = ac.target.transform.position;
        staleTargetPos.y = transform.position.y;
    }

    public override void Update()
    {
        if(ac.target == null)
        {
            Transition(NextState);
            return;
        }

        if (Vector2.Distance(staleTargetPos, transform.position) <= .1f)
        {
            Transition(NextState);
        }
    }
}
