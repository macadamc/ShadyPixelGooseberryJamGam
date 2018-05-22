using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffClimbersState : EnemyState
{
    List<EnemyState> buffed;

    public float climbSpeedBuff;

    public override void OnDisable()
    {
        foreach(EnemyState state in buffed)
        {
            if (state != null && state.enabled)
            {
                state.GetComponent<MovementController>().moveSpeed -= climbSpeedBuff;
            }
        }
    }

    public override void OnEnable()
    {
        buffed = new List<EnemyState>();
        base.OnEnable();
        ic.move = Vector2.zero;
    }

    public override void Update()
    {
        BuffEnemys();
    }

    void BuffEnemys()
    {
        foreach(EnemyState state in GameObject.FindObjectsOfType<EnemyState>())
        {
            if(state.GetType() == typeof(Climb) && buffed.Contains(state) == false && state.enabled)
            {
                buffed.Add(state);
                state.GetComponent<MovementController>().moveSpeed += climbSpeedBuff;
            }
        }
    }
}
