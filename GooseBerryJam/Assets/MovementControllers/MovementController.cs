 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public Vector2 knockback;
    public float knockbackDecel = 10000;
    public InputController inputController;

    public float stunlockNextInputTime;

    public void SetSpeed(float newSpeed)
    {
        moveSpeed = newSpeed;
    }

    public void AddKnockback(Vector2 velocity)
    {
        knockback += velocity;
    }

    public void SetKnockback(Vector2 velocity)
    {
        knockback = velocity;
    }

    public virtual void Move()
    {
        Vector2 newinput = Vector2.zero;

        if (Time.time > stunlockNextInputTime)
            newinput = inputController.move;


        rb.velocity = (newinput * moveSpeed)+knockback;
    }

    public virtual void UpdateKnockback()
    {
        knockback = Vector2.Lerp(knockback, Vector2.zero, knockbackDecel * Time.deltaTime);
    }

    public virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputController = GetComponent<InputController>();
    }

    public virtual void Update()
    {
        Move();
        UpdateKnockback();
    }

    public void StunLock(float timeToStun)
    {
        stunlockNextInputTime = Time.time + timeToStun;
    }
}
