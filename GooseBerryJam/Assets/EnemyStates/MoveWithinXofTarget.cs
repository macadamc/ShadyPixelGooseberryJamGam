using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithinXofTarget : EnemyState
{
    bool useVert = false;

    public EnemyState NextState;
    public float distance;
    SimpleEnemyAttackController ac;

    private void Awake()
    {
        ac = GetComponent<SimpleEnemyAttackController>();
    }
    public override void OnEnable()
    {
        base.OnEnable();
       
    }

    public override void Update()
    {
        if (ac.target == null)
        {
            Transition(NextState);
            return;
        }


        base.Update();
        if (Vector3.Distance(transform.position, ac.target.transform.position) > distance)
        {
            ic.move = (ac.target.transform.position - transform.position).normalized;

            if (useVert == false)
                ic.move.y = 0;
        }
        else
        {
            Transition(NextState);
        }
    }
}
