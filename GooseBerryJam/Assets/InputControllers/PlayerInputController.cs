using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : InputController
{
    private void Update()
    {
        move.Set(Input.GetAxis("Horizontal"), 0f);
        action = Input.GetButtonDown("Fire1");
    }
}
