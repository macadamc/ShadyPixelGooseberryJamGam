 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;

    public InputController inputController;

    public float stunlockNextInputTime;

    public void SetSpeed(float newSpeed)
    {
        moveSpeed = newSpeed;
    }

    public virtual void Move()
    {
        Vector2 newinput = Vector2.zero;

        if (Time.time > stunlockNextInputTime)
            newinput = inputController.move;


        rb.velocity = (newinput * moveSpeed);
    }

    public virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputController = GetComponent<InputController>();
    }

    public virtual void Update()
    {
        Move();
    }

    public void StunLock(float timeToStun)
    {
        stunlockNextInputTime = Time.time + timeToStun;
    }
}
