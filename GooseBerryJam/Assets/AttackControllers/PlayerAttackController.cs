﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerAttackController : AttackController
{
    public float heat;
    public float overheatThreshhold = 25f;
    public float warningThresholdOn = 20f;
    public float warningThresholdOff = 18f;
    public float normalCooldown = 5f;
    public float overheatCooldown = 3f;
    public float attackHeat = 3f;
    public float attackJump = 3f;

    bool overheated;
    bool warning;

    Slider slider;

    public UnityEvent onAttackEvent;

    public UnityEvent onWarningStart;
    public UnityEvent onWarningEnd;

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
                if(pmc.IsOnGround() == false && pmc.onGround == false)
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


        if(!overheated)
        {
            if (heat >= warningThresholdOn && !warning)
            {
                warning = true;
                onWarningStart.Invoke();
            }

            if (heat <= warningThresholdOff && warning)
            {
                warning = false;
                onWarningEnd.Invoke();
            }

            if (heat >= overheatThreshhold)
            {
                overheated = true;
                onOverheatStart.Invoke();

                warning = false;
                onWarningEnd.Invoke();
            }
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
        pmc.Jump(attackJump);
        CreateProjectile(Vector2.down);
        onAttackEvent.Invoke();
        heat += attackHeat;
    }
}
