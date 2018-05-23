using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BuffClimbersState : EnemyState
{
    UnityAction OnDeath;
    List<EnemyState> buffed;
    Health hp;
    public float climbSpeedBuff;

    public override void OnEnable()
    {
        OnDeath += onDeathCallback;
        GetComponent<Health>().OnDeath.AddListener(OnDeath);
        buffed = new List<EnemyState>();
        base.OnEnable();
        ic.move = Vector2.zero;
    }

    void onDeathCallback()
    {
        foreach (EnemyState state in buffed)
        {
            if (state != null && state.enabled)
            {
                state.GetComponent<MovementController>().moveSpeed -= climbSpeedBuff;
            }
        }
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
