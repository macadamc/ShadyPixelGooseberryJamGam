using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : EnemyState
{
    public EnemyState reachTopState;

    public float waitMin = 1f;
    public float waitMax = 1f;
    public float waitTime = 0f;

    Transform finishLine;

    public override void OnEnable()
    {
        base.OnEnable();
        finishLine = GameObject.FindGameObjectWithTag("Finish").transform;
    }

    public override void Update()
    {
        base.Update();

        if(AtTop())
        {
            Transition(reachTopState);
            return;
        }

        if (waitTime <= 0)
        {
            waitTime = Random.Range(waitMin, waitMax);
            ChangeDirection();
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }

    public override void OnDisable()
    {
        base.OnDisable();
    }

    public void ChangeDirection()
    {
        if (ic.move.y != 0)
        {
            Vector2[] dirs = new Vector2[5] { Vector2.left, Vector2.right, Vector2.up, new Vector2(1, 1), new Vector2(-1, 1) };

            ic.move = dirs[Random.Range(0, dirs.Length)];
        }
        else
        {
            ic.move = Vector2.up;
        }
    }

    public bool AtTop()
    {
        return transform.position.y >= finishLine.transform.position.y;
    }
}
