using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReachClimbWallPoint : MonoBehaviour
{
    public Vector2 climbPoint;
    InputController input;
    public UnityEvent OnStartClimb;
    public UnityEvent OnStart;

    private void Awake()
    {
        input = GetComponent<InputController>();

        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;

        climbPoint.x = Random.Range(-width/2f + 1f, width/2f -1f) + cam.transform.position.x;
    }

    private void Start()
    {
        OnStart.Invoke();
    }

    private void Update()
    {
        if(IsAtClimbPoint())
        {
            input.move = Vector2.up;
            enabled = false;
            OnStartClimb.Invoke();
        }
        else
        {
            input.move = new Vector2((transform.position.x - climbPoint.x) > 0 ? -1 : 1, 0);
        }
    }

    private bool IsAtClimbPoint()
    {
        Vector2 pos = new Vector2(transform.position.x, 0f);
        return Vector2.Distance(pos, climbPoint) <= .1f;
    }
}
