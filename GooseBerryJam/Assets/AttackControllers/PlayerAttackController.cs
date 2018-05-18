using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAttackController : AttackController {

    public UnityEvent onAttackEvent;

    public override void OnAttack()
    {
        CreateProjectile(Vector2.down);
        onAttackEvent.Invoke();
    }
}
