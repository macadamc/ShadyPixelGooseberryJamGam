using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyAttackController : AttackController
{
    public GameObject target;

    public void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    public override void OnAttack()
    {
        if(target != null)
            CreateProjectile((target.transform.position - transform.position).normalized);
    }

    public override void Update()
    {
        base.Update();
    }
}
