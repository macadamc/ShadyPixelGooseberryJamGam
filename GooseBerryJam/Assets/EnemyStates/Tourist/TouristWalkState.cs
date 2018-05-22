using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouristWalkState : EnemyState
{
    public float minExitTime;
    public float maxExitTime;
    float exitTime;

    Vector2 targetPos;

    public EnemyState NextState;

    public override void OnDisable()
    {
        base.OnDisable();
    }

    public override void OnEnable()
    {
        base.OnEnable();

        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;

        targetPos.x = Random.Range(-width / 2f + 1f, width / 2f - 1f) + cam.transform.position.x;
        exitTime = Time.time + Random.Range(minExitTime, maxExitTime);
    }

    public override void Update()
    {
        if(Time.time >= exitTime)
        {
            Transition(NextState);
            return;
        }

        if (IsAtTargetPos())
        {
            Camera cam = Camera.main;
            float height = 2f * cam.orthographicSize;
            float width = height * cam.aspect;

            targetPos.x = Random.Range(-width / 2f + 1f, width / 2f - 1f) + cam.transform.position.x;
        }
        else
        {
            ic.move = new Vector2((transform.position.x - targetPos.x) > 0 ? -1 : 1, 0);
        }
    }

    private bool IsAtTargetPos()
    {
        Vector2 pos = new Vector2(transform.position.x, 0f);
        return Vector2.Distance(pos, targetPos) <= .1f;
    }
}
