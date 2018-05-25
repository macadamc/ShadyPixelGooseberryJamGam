using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindClimbPoint : EnemyState
{
    Vector2 climbPoint;

    public EnemyState climbState;
    public float padding;

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

        climbPoint.x = Random.Range(-width / 2f + padding, width / 2f - padding) + cam.transform.position.x;
    }

    public override void Update()
    {
        base.Update();

        if (IsAtClimbPoint())
        {
            Transition(climbState);
        }
        else
        {
            ic.move = new Vector2((transform.position.x - climbPoint.x) > 0 ? -1 : 1, 0);
        }
    }

    private bool IsAtClimbPoint()
    {
        Vector2 pos = new Vector2(transform.position.x, 0f);
        return Vector2.Distance(pos, climbPoint) <= .1f;
    }
}
