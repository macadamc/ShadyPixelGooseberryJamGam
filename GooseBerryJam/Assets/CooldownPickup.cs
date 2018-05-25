using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownPickup : Pickup
{
    public override void ActivatePickup()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttackController>().heat = .001f;

        // destroys the pickup!! CALL THIS LAST
        base.ActivatePickup();
    }
}
