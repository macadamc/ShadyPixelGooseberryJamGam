using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : InputController
{
    private void Update()
    {
        move.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        action = Input.GetButton("Fire1");
    }
}
