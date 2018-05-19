using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySetAnimationValues : SetAnimationValues {

    InputController ic;

    SpriteRenderer rend;

    public void Start()
    {
        ic = GetComponent<InputController>();
        rend = GetComponent<SpriteRenderer>();
        
    }

    public override void UpdateValues()
    {

        if(ic.move.x > 0)
        {
            rend.flipX = false;
        }

        if(ic.move.x < 0)
        {
            rend.flipX = true;
        }
    }
}
