using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetAnimationValues : SetAnimationValues {

    InputController ic;
    AttackController ac;
    PlatformMovementController pmc;


    public string moveBoolName = "isMoving";
    public string attackTriggerName = "attack";

    bool attackTrigger;
    SpriteRenderer rend;

    public void Start()
    {
        ic = GetComponent<InputController>();
        ac = GetComponent<AttackController>();
        pmc = GetComponent<PlatformMovementController>();
        rend = GetComponent<SpriteRenderer>();
        
    }

    public override void UpdateValues()
    {
        anim.SetBool(moveBoolName, ic.move.magnitude > 0.0f || pmc.IsOnGround() == false);

        if(ic.move.x > 0)
        {
            rend.flipX = false;
        }

        if(ic.move.x < 0)
        {
            rend.flipX = true;
        }

        if(ac.isAttacking)
        {
            if(attackTrigger != true)
            {
                anim.SetTrigger(attackTriggerName);
                attackTrigger = true;
            }
        }
        else
        {
            attackTrigger = false;
        }
    }
}
