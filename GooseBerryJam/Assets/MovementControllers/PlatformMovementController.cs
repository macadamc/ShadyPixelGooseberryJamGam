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

    public bool onGround;
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
        if (inputController.action == true && onGround && !jumped)
            Jump(jumpStrength);

        Vector2 newVel = new Vector2(inputController.move.x * moveSpeed, rb.velocity.y);


        if(!onGround && inputController.action == false && rb.velocity.y > 0 && jumpCancel == false)
        {
            newVel.y /= 2.0f;
            jumpCancel = true;
        }

        rb.velocity = newVel;

        if(IsOnGround())
        {
            if(inputController.action == false)
                jumped = false;

            if(!onGround && rb.velocity.y <= 0)
            {
                jumpCancel = false;
                onGround = true;

                onLandEvent.Invoke();
            }
        }
    }

    public void Jump(float str)
    {
        Vector2 newVel = new Vector2(rb.velocity.x, str);

        rb.velocity = newVel;
        jumped = true;
        onGround = false;

        onJumpEvent.Invoke();
    }

    public bool IsOnGround()
    {
        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, Vector2.down, 0.55f, whatIsGround);
        return hit.collider != null;
    }


}
