using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : EnemyState
{

    Camera cam;
    float camHeight;
    float camWidth;

    public EnemyState reachTopState;
    public Vector2[] directions = new Vector2[1] { Vector2.up };

    public float waitMin = 1f;
    public float waitMax = 1f;
    public float waitTime = 0f;

    Transform finishLine;

    public override void OnEnable()
    {
        cam = Camera.main;
        camHeight = 2f * cam.orthographicSize;
        camWidth = camHeight * cam.aspect;

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

        if (IsInBounds())
        {
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
        else
        {
            ic.move.x = transform.position.x > 0 ? -1 : 1;
            waitTime = Random.Range(waitMin, waitMax);
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
            //Vector2[] dirs = new Vector2[5] { Vector2.left, Vector2.right, Vector2.up, new Vector2(1, 1), new Vector2(-1, 1) };

            ic.move = directions[Random.Range(0, directions.Length)];
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

    bool IsInBounds()
    {
        return transform.position.x >= -camWidth / 2f + 1f && transform.position.x <= camWidth / 2f - 1f;
    }
}
