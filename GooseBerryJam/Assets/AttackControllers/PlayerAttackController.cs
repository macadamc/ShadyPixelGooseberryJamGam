using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerAttackController : AttackController
{
    public float heat;
    public float overheatThreshhold = 25f;
    public float normalCooldown = 5f;
    public float overheatCooldown = 3f;
    public float attackHeat = 3f;
    public float attackJump = 3f;

    bool overheated;

    Slider slider;

    public UnityEvent onAttackEvent;

    public UnityEvent onOverheatStart;
    public UnityEvent onOverheatEnd;

    PlatformMovementController pmc;
    bool buttonPressed;

    private void Start()
    {
        slider = GameObject.FindGameObjectWithTag("StaminaBar").GetComponent<Slider>();
        slider.maxValue = overheatThreshhold;
        pmc = GetComponent<PlatformMovementController>();
    }

    public override void Update()
    {
        if (input.action)
        {
            if (isAttacking == false && !overheated & !buttonPressed)
            {
                if(pmc.onGround == false)
                {
                    isAttacking = true;
                    OnAttack();
                }
            }

            buttonPressed = true;


        }
        else
        {
            buttonPressed = false;

            if(isAttacking)
                isAttacking = false;
        }


        if (heat >= overheatThreshhold && !overheated)
        {
            overheated = true;
            onOverheatStart.Invoke();
        }

        if(heat > 0)
        {
            if (!overheated)
            {
                heat -= normalCooldown * Time.deltaTime;
            }
            else
            {
                heat -= overheatCooldown * Time.deltaTime;

                if (heat <= 0 && overheated == true)
                {
                    overheated = false;
                    heat = 0;
                    onOverheatEnd.Invoke();
                }
            }
        }

        slider.value = heat;
    }

    public override void OnAttack()
    {
        CreateProjectile(Vector2.down);
        onAttackEvent.Invoke();
        heat += attackHeat;

        if(pmc.onGround == false)
            pmc.Jump(attackJump);
    }
}
