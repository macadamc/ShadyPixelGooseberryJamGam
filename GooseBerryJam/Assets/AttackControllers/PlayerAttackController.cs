using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : AttackController {

    public override void OnAttack()
    {
        CreateProjectile(Vector2.down);
    }
}
