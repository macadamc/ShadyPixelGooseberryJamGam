using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterXWithFlash : DestroyAfterXSeconds
{
    float halfLife;
    Flash flash;

    private void Awake()
    {
        halfLife = lifeSpan / 2f;
        flash = GetComponent<Flash>();
    }
    public override void Update()
    {
        base.Update();

        if(lifeSpan <= halfLife && flash.enabled == false)
        {
            flash.enabled = true;
        }
    }
}
