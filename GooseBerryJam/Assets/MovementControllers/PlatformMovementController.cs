using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlatformMovementController : MovementController
{
    public float jumpStrength;

    public LayerMask whatIsGround;

    public UnityEvent onJumpEvent;

    public UnityEvent onLandEvent;




    bool onGround;
    bool jumpCancel;
    public bool jumped;

    public override void Awake()
    {
        base.Awake();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Move()
    {
        if (inputController.move.y > 0 && onGround && !jumped)
            Jump();

        Vector2 newVel = new Vector2(inputController.move.x * moveSpeed, rb.velocity.y);


        if(!onGround && inputController.move.y <= 0 && rb.velocity.y > 0 && jumpCancel == false)
        {
            newVel.y /= 2.0f;
            jumpCancel = true;
        }

        rb.velocity = newVel;

        if(IsOnGround() && !onGround && rb.velocity.y <= 0)
        {
            jumpCancel = false;
            onGround = true;
            jumped = false;

            onLandEvent.Invoke();
        }
    }

    public void Jump()
    {
        Vector2 newVel = new Vector2(rb.velocity.x, jumpStrength);

        rb.velocity = newVel;
        jumped = true;
        onGround = false;

        onJumpEvent.Invoke();
    }

    public bool IsOnGround()
    {
        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, Vector2.down, 0.51f, whatIsGround);
        return hit.collider != null;
    }


}
